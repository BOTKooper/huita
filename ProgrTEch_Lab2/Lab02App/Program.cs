/*****************************************************/
/* Лабораторная работа № 2 */
/* Абстрактные сущности и связи между ними */
/* Задание 2 */
/* Выполнил студент гр. 525Б Озеров А.И. */
/* Project: Lab02App
 * File: Program.cs */
/****************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using HomeAppliances;
namespace Lab02App
{
    class Program
    {
        static void Main(string[] args)
        {
            // arraylist of machines
            List<YogurtMaker> makers = new List<YogurtMaker>();
            
            //main loop
            while (true)
            {
                //writing list of machines
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("List of your YogurtMakers:");
                Console.WriteLine("-----------------");
                for (int j = 0; j < makers.Count; j++)
                {
                    Console.WriteLine("ID: {0}", makers[j].Id);
                    Console.WriteLine("Mode: {0}", makers[j].CurrentMode);
                    Console.WriteLine("Power: {0}", makers[j].PowerOn);
                    Console.WriteLine("Brand: {0}", makers[j].Brand);
                    Console.WriteLine("Model: {0}", makers[j].Model);
                    Console.WriteLine("-----------------");
                }

                // menu
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("List of commands:\n" +
                    "1 - create new YogurtMaker (max 5);\n" +
                    "2 - delete specified machine;\n" +
                    "3 - turn off/on specified machine;\n" +
                    "4 - change mode of specified machine.");

                Console.WriteLine("Type number of command you want to run:");
                int command = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                //command handler
                if (command == 1) //creater
                {
                    if (makers.Count < 5) //checking count of active machines 
                    {
                        Console.WriteLine("Do you want to specify brand? (1- y, 2- n)");
                        int ans = Convert.ToInt32(Console.ReadLine());
                        if (ans == 1)
                        {
                            Console.WriteLine("Write it:");
                            string brand = Console.ReadLine();

                            Console.WriteLine("Do you want to specify model? (1- y, 2- n)");
                            ans = Convert.ToInt32(Console.ReadLine());
                            if (ans == 1)
                            {
                                Console.WriteLine("Write it:");
                                string model = Console.ReadLine();
                                makers.Add(new YogurtMaker(brand, model));
                            }
                            else
                                makers.Add(new YogurtMaker(brand));

                        }
                        else
                            makers.Add(new YogurtMaker());

                        Console.WriteLine("Success!");
                    }
                    else
                        Console.WriteLine("You already have maximum amount of machines! <--------------------------------");
                }
                else if (command == 2) //deleting
                {
                    Console.WriteLine("Type ID of YogurtMaker you want to move to trash:");
                    int toRemove = Convert.ToInt32(Console.ReadLine());

                    bool flag = true;
                    for (int i = 0; i < makers.Count; i++)
                    {
                        if (makers[i].Id == toRemove)
                        {
                            makers.RemoveAt(toRemove - 1);
                            Console.WriteLine("Success!");
                            flag = !flag;
                        }
                    }
                    if (flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something weng wrong...");
                    }
                }
                else if (command == 3) // on/off switch
                {
                    Console.WriteLine("Type ID of YogurtMaker you want to turn off/on (triggering):");
                    int toTurn = Convert.ToInt32(Console.ReadLine());
                    bool flag = true;
                    for (int i = 0; i < makers.Count; i++)
                    {
                        if (makers[i].Id == toTurn)
                        {
                            makers[i].OffOn();
                            Console.WriteLine("Success!");
                            flag = !flag;
                        }
                    }
                    if (flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something weng wrong...");
                    }
                }
                else if (command == 4) // working with specified machine
                {
                    Console.WriteLine("Type ID of YogurtMaker you want to work with:"); // machine picker
                    int toTurn = Convert.ToInt32(Console.ReadLine());
                    bool flag = true;
                    for (int i = 0; i < makers.Count; i++)
                    {
                        if (makers[i].Id == toTurn)
                        {

                            if (makers[i].PowerOn == 0)
                                makers[i].OffOn();

                            // modes menu
                            Console.WriteLine("Choose what to do:\n" +
                                "1 - yogurt;\n" +
                                "2 - cheese;\n" +
                                "3 - sourCream;\n" +
                                "4 - curd");
                            int mode = Convert.ToInt32(Console.ReadLine());

                            makers[i].ModeSet(mode);
                            Console.WriteLine("Success!");
                            flag = !flag;
                        }
                    }
                    if (flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something weng wrong...");
                    }
                }
                else if (command == 5) // brand/model changer
                {
                    Console.WriteLine("Type ID of YogurtMaker you want to work with:");
                    int toTurn = Convert.ToInt32(Console.ReadLine());
                    bool flag = true;
                    for (int i = 0; i < makers.Count; i++)
                    {
                        if (makers[i].Id == toTurn)
                        {
                            Console.WriteLine("Success!");
                            flag = !flag;
                            Console.WriteLine("Choose what to do:\n" +
                                "1 - Change brand;\n" +
                                "2 - Change model.");
                            int cmd = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Now type data:");
                            string data = Console.ReadLine();

                            if (cmd == 1)
                                makers[i].Brand = data;
                            else
                                makers[i].Model = data;
                        }
                    }
                    if (flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something weng wrong...");
                    }
                }
            }
            
                
            
        }
    }
}
