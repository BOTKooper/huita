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

        public void Print()
        {
            Console.WriteLine("Name: {0}" +
                              "Size: {1}" +
                              "Owner: {2}" +
                              "Creation: {3}" +
                              "Editing: {4}", name, size, owner, timeOfCreation, timeOfEditing);
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public void setSize(int size)
        {
            this.size = size;
        }

        public int getSize()
        {
            return size;
        }

        public void setOwner(int owner)
        {
            this.owner = owner;
        }

        public int getOwner()
        {
            return owner;
        }

        public void setTimeOfCreation(DateTime timeOfCreation)
        {
            this.timeOfCreation = timeOfCreation;
        }

        public DateTime getTimeOfCreation()
        {
            return timeOfCreation;
        }

        public void setTimeOfEditing(DateTime timeOfEditing)
        {
            this.timeOfEditing = timeOfEditing;
        }

        public DateTime getTimeOfEditing()
        {
            return timeOfEditing;
        }
    }
}