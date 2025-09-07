using System;
using StudentManagementSystem.DoublyLinkedList;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            int choice;

            do
            {
                Console.WriteLine("\n===== Student Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Display Students");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: list.AddStudent(); break;
                    case 2: list.DeleteStudent(); break;
                    case 3: list.SearchStudent(); break;
                    case 4: list.UpdateStudent(); break;
                    case 5: list.DisplayStudents(); break;
                    case 6: Console.WriteLine("Exiting..."); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            } while (choice != 6);
        }
    }
}
