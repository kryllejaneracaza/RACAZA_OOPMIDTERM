using System;
using StudentManagementSystem.StudentInformation;
using StudentManagementSystem.Nodes;


namespace StudentManagementSystem.DoublyLinkedList
{
    public class LinkedList
    {
        private Node head;

        public void AddStudent()
        {
            Console.WriteLine("Where to insert? (1=Beginning, 2=End, 3=Position): ");
            int choice = int.Parse(Console.ReadLine());

            Student student = new Student();
            Node newNode = new Node { Student = student, Prev = null, Next = null };

            if (choice == 1)
            {
                newNode.Next = head;
                if (head != null)
                    head.Prev = newNode;
                head = newNode;
            }
            else if (choice == 2)
            {
                if (head == null)
                    head = newNode;
                else
                {
                    Node current = head;
                    while (current.Next != null)
                        current = current.Next;

                    current.Next = newNode;
                    newNode.Prev = current;
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter Position: ");
                int pos = int.Parse(Console.ReadLine());
                int index = 1;
                Node current = head;

                while (current != null && index < pos)
                {
                    current = current.Next;
                    index++;
                }

                if (current == null)
                {
                    Console.WriteLine("Invalid position.");
                    return;
                }
                else
                {
                    newNode.Prev = current.Prev;
                    newNode.Next = current;

                    if (current.Prev != null)
                        current.Prev.Next = newNode;
                    else
                        head = newNode;

                    current.Prev = newNode;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Console.WriteLine("Enter Student ID: ");
            student.Id = int.Parse(Console.ReadLine());

            Node temp = head;
            while (temp != null)
            {
                if (temp != newNode && temp.Student.Id == student.Id)
                {
                    Console.WriteLine("Duplicate ID not allowed.");
                    if (newNode.Prev != null)
                        newNode.Prev.Next = newNode.Next;
                    else
                        head = newNode.Next;

                    if (newNode.Next != null)
                        newNode.Next.Prev = newNode.Prev;

                    return;
                }
                temp = temp.Next;
            }

            Console.WriteLine("Enter Name: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter Course: ");
            student.Course = Console.ReadLine();
            Console.WriteLine("Enter Year Level: ");
            student.YearLevel = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter GPA: ");
            student.GPA = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter School ID: ");
            student.SchoolId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter School Name: ");
            student.SchoolName = Console.ReadLine();
            Console.WriteLine("Enter School Address: ");
            student.SchoolAddress = Console.ReadLine();

            Console.WriteLine("Student added successfully!");
        }

        public void DeleteStudent()
        {
            Console.WriteLine("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Node current = head;
            while (current != null && current.Student.Id != id)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                head = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;

            Console.WriteLine("Student deleted successfully!");
        }

        public void SearchStudent()
        {
            Console.WriteLine("Search by (1=ID, 2=Name): ");
            int choice = int.Parse(Console.ReadLine());
            bool found = false;

            if (choice == 1)
            {
                Console.WriteLine("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Node current = head;

                while (current != null)
                {
                    if (current.Student.Id == id)
                    {
                        Console.WriteLine("Student Found:");
                        DisplayDetails(current.Student);
                        found = true;
                        break;
                    }
                    current = current.Next;
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter Student Name: ");
                string name = Console.ReadLine();
                Node current = head;

                Node matchesHead = null;
                Node matchesTail = null;

                while (current != null)
                {
                    if (current.Student.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;

                        Node newNode = new Node { Student = current.Student, Next = null, Prev = matchesTail };

                        if (matchesHead == null)
                            matchesHead = newNode;
                        else
                            matchesTail.Next = newNode;

                        matchesTail = newNode;
                    }
                    current = current.Next;
                }

                current = matchesHead;
                while (current != null)
                {
                    DisplayDetails(current.Student);
                    Console.WriteLine("Options: 1=Next, 2=Prev, 3=Exit");
                    int option = int.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        if (current.Next != null)
                            current = current.Next;
                        else
                            Console.WriteLine("No more records.");
                    }
                    else if (option == 2)
                    {
                        if (current.Prev != null)
                            current = current.Prev;
                        else
                            Console.WriteLine("Already at first record.");
                    }
                    else if (option == 3)
                    {
                        Console.WriteLine("Exiting search...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        current = current.Next;
                    }
                }
            }

            if (!found)
                Console.WriteLine("No matching record found.");
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Node current = head;
            while (current != null && current.Student.Id != id)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Enter New Name: ");
            current.Student.Name = Console.ReadLine();
            Console.WriteLine("Enter New Course: ");
            current.Student.Course = Console.ReadLine();
            Console.WriteLine("Enter New Year Level: ");
            current.Student.YearLevel = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New GPA: ");
            current.Student.GPA = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter New School ID: ");
            current.Student.SchoolId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New School Name: ");
            current.Student.SchoolName = Console.ReadLine();
            Console.WriteLine("Enter New School Address: ");
            current.Student.SchoolAddress = Console.ReadLine();

            Console.WriteLine("Student updated successfully!");
        }

        public void DisplayStudents()
        {
            if (head == null)
            {
                Console.WriteLine("No student records available.");
                return;
            }

            Node current = head;
            while (current != null)
            {
                Console.WriteLine("--------------------------------");
                DisplayDetails(current.Student);
                Console.WriteLine("Options: (1=Next, 2=Prev, 3=Exit)");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    if (current.Next != null)
                        current = current.Next;
                    else
                        Console.WriteLine("Already at last record.");
                }
                else if (choice == 2)
                {
                    if (current.Prev != null)
                        current = current.Prev;
                    else
                        Console.WriteLine("Already at first record.");
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Exiting student display...");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

            Console.WriteLine("End of student records.");
        }

        private void DisplayDetails(Student s)
        {
            Console.WriteLine($"ID: {s.Id}\nName: {s.Name}\nCourse: {s.Course}\nYear: {s.YearLevel}\nGPA: {s.GPA}\n");
            Console.WriteLine($"School ID: {s.SchoolId}\nSchool Name: {s.SchoolName}\nAddress: {s.SchoolAddress}\n");
        }
    }
}
