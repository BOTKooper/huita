using System;
using Ozerov.Lab01.Task02.ClassLib;

namespace Task02.ConsoleApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            File file1 = new File();
            file1.setName("links1.txt");
            file1.setOwner(1);
            file1.setSize(654353);
            file1.setTimeOfCreation(DateTime.Now);
            file1.setTimeOfEditing(DateTime.Now);
            file1.Print();
            
            File file2 = new File();
            file2.setName("links2.txt");
            file2.setOwner(112);
            file2.setSize(353);
            file2.setTimeOfCreation(DateTime.Now);
            file2.setTimeOfEditing(DateTime.Now);
            file2.Print();

            File file3 = new File();
            file3.setName("links3.txt");
            file3.setOwner(1443);
            file3.setSize(6543);
            file3.setTimeOfCreation(DateTime.Now);
            file3.setTimeOfEditing(DateTime.Now);
            file3.Print();
        }
    }
}