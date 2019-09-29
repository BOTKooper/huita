/*****************************************************/
/* Лабораторная работа № 2 */
/* Абстрактные сущности и связи между ними */
/* Задание 2 */
/* Выполнил студент гр. 525Б Озеров А.И. */
/* Project: HomeAppliances
 * File: YogurtMaker.cs */
/****************************************************/
using System;
namespace HomeAppliances
{
    // Status
    public enum Status
    {
        powerOn = 0,
        yogurt = 0,
        cheese = 0,
        sourCream = 0,
        curd = 0,
    };
    // YogurtMaker class
    public class YogurtMaker
    {
        // id of current YogurtMaker
        public int id;
        // id getter
        public int Id{get => id;}
        // id setter and blank constructor
        public static int ID = 0;
        public YogurtMaker()
        {
            id = ++ID;
        }
        // branded constructor
        public YogurtMaker(string brand)
        {
            id = ++ID;
            this.brand = brand;
        }
        // full constructor
        public YogurtMaker(string brand, string model)
        {
            id = ++ID;
            this.brand = brand;
            this.model = model;
        }
        // powerOn field and it's getter/setter
        private int powerOn = 0;
        public int PowerOn
        {
            get => powerOn;
            set => powerOn = value;
        }
        // currentMode field and it's getter/setter
        public int currentMode = 0;
        public int CurrentMode
        {
            get => currentMode;
            set => currentMode = value;
        }
        // brand field and it's getter/setter
        private string brand = "NoName";
        public string Brand
        {
            get => brand;
            set => brand = value;
        }
        // model field and it's getter/setter
        private string model = "Unknown";
        public string Model
        {
            get => model;
            set => model = value;
        }
        // OnOff switch
        public void OffOn()
        {
            if (this.PowerOn == 1)
            {
                this.PowerOn = 0;
                this.CurrentMode = 0;
            }
            else
            {
                this.PowerOn = 1;
            }
        }
        // Mode picker
        public void ModeSet(int currentMode)
        {
            if (currentMode > 4)
                currentMode %= 4;
            if (currentMode == 0)
                currentMode++;
            this.currentMode = currentMode;
        }

    }
}
