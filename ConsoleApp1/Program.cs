using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(3, null);
            tree.Add(5);
            tree.Add(3);
            tree.Add(1);
            tree.Add(4);
            Tree<int> t = tree.serch(3);
            t = tree.serch(1);
            t = tree.serch(4);
            tree.print();
        }
    }
}
