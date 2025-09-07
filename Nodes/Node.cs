using System;
using StudentManagementSystem.Nodes;
using StudentManagementSystem.StudentInformation;


namespace StudentManagementSystem.Nodes
{
    public class Node
    {
        public Student Student { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }
}
