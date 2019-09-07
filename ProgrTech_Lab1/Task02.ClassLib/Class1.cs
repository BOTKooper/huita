using System;
namespace Ozerov.Lab01.Task02.ClassLib
{
    public class File
    {
        private string name;
        private int size;
        private int owner;
        private DateTime timeOfCreation;
        private DateTime timeOfEditing;
        
        public void Print(){
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Size: {0}", size);
            Console.WriteLine("Owner: {0}", owner);
            Console.WriteLine("Creation: {0}", timeOfCreation);
            Console.WriteLine("Editing: {0}", timeOfEditing);
        }

        public void setName(string Name)
        {
            name = Name;
        }

        public string getName()
        {
            return name;
        }

        public void setSize(int Size)
        {
            size = Size;
        }

        public int getSize()
        {
            return size;
        }

        public void setOwner(int Owner)
        {
            owner = Owner;
        }

        public int getOwner()
        {
            return owner;
        }

        public void setTimeOfCreation(DateTime time)
        {
            timeOfCreation = time;
        }

        public void setTimeOfEditing(DateTime time){
            timeOfEditing = time;
        }

        public DateTime getTimeOfCreation()
        {
            return timeOfCreation;
        }

        public DateTime getTimeOfEditing()
        {
            return timeOfEditing;
        }
    }
}