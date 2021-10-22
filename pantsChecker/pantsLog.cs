using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace pantsChecker
{
    internal class pantsLog
    {
        private List<Pants> newPants = new List<Pants>();

        public pantsLog()
        {
            Pants pants1 = new Pants("Jeans");
            pants1.Size.Add(28);
            pants1.Size.Add(32);
            pants1.Size.Add(34);
            newPants.Add(pants1);
            Pants pants2 = new Pants("Joggers");
            pants2.Size.Add(36);
            newPants.Add(pants2);
            Pants pants3 = new Pants("Chinos");
            pants3.Size.Add(30);
            pants3.Size.Add(32);
            pants3.Size.Add(30);
            newPants.Add(pants3);
            Pants pants4 = new Pants("Slacks");
            pants4.Size.Add(24);
            pants4.Size.Add(34);
            newPants.Add(pants4);
        }

        public void welcome()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1: Add Pants");
            Console.WriteLine("2: Check Aailibility");
            Console.WriteLine("3: Delete A Style Of Pants");
            Console.WriteLine("4: View All Pants");
            Console.WriteLine("5: Leave The Store");
            Console.WriteLine("------------------------------");
            Console.Write("Enter a Number from above: ");
            bool waiting = true;
            while (waiting)
            {
                string answer = (Console.ReadLine());
                if (answer == "1")
                {
                    Console.WriteLine();
                    addPants();
                    waiting = false;
                }
                else if (answer == "2")
                {
                    Console.WriteLine();
                    checkPants();
                    waiting = false;
                }
                else if (answer == "3")
                {
                    Console.WriteLine();
                    removePants();
                    waiting = false;
                }
                else if (answer == "4")
                {
                    Console.WriteLine();
                    lookUp();
                    waiting = false;
                }
                else if (answer == "5")
                {
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                    waiting = false;
                }
                else
                {
                    Console.WriteLine("Please only enter a number from 1-5");
                }
            }
        }

        public void addPants()
        {
            Console.WriteLine("What style pants do you want to add?");
            string userStyleA = Console.ReadLine();
            Pants userP = new Pants(userStyleA);

            Console.WriteLine("\nHow many sizes are you adding?");
            bool testing3 = true;
            int uSizes;
            while (testing3)
            {
                string number3 = Console.ReadLine();

                bool parseSuccess3 = int.TryParse(number3, out uSizes);
                if (parseSuccess3)
                    for (int i = 0; i < uSizes; i++)
                    {
                        Console.WriteLine("\nEnter the size your adding: ");
                        int addSizesNow = Convert.ToInt32(Console.ReadLine());
                        userP.Size.Add(addSizesNow);
                        testing3 = false;
                    }
                else if (parseSuccess3 == false)
                {
                    Console.WriteLine("\nOnly enter a number.");
                }
            }

            newPants.Add(userP);
            Console.WriteLine();
            welcome();
        }

        public void checkPants()
        {
            Console.WriteLine("What is the style of the pants you want check?");
            string styleCheck = Console.ReadLine();
            Console.WriteLine("\nWhat size are you looking for in that style?");
            int sizeCheck;
            bool testing = true;
            while (testing)
            {
                string sizeCheck1 = Console.ReadLine();
                bool parseSuccess = int.TryParse(sizeCheck1, out sizeCheck);
                if (parseSuccess)
                {
                    Console.WriteLine("\nResults Below Results:");
                    foreach (var item in newPants)
                    {
                        if (item.Style == styleCheck)
                        {
                            foreach (var all in item.Size)
                            {
                                var exists = all.CompareTo(sizeCheck);
                                if (exists == 0)
                                {
                                    Console.WriteLine("\n>>Yes we do have those in stock<<");
                                    break;
                                }
                                else if (exists == -1)
                                {
                                    Console.WriteLine("\n>>No we do not have those in stock<<");
                                    break;
                                }
                            }
                        }
                    }
                    int count = 0;
                    foreach (var item in newPants)
                    {
                        if (item.Style == styleCheck)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("\n>>No we do not have those in stock<<");
                    }

                    Console.WriteLine();

                    welcome();
                }
                else if (parseSuccess == false)
                {
                    Console.WriteLine("Please only enter a number for the size.");
                }
            }
        }

        public void removePants()
        {
            Console.WriteLine("These are the current style pants we have: ");
            Console.WriteLine("-------------------------------------------");
            int i = 0;
            foreach (var item in newPants)
            {
                Console.WriteLine($"\tLocation #: {i} Style: { item.Style}");
                i++;
            }
            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("What style pants do you want to remove? (Enter the Location number)");
            int userStyleR;
            bool testing2 = true;
            while (testing2)
            {
                string userStyleR1 = Console.ReadLine();
                bool parseSuccess1 = int.TryParse(userStyleR1, out userStyleR);
                if (userStyleR <= newPants.Count && parseSuccess1)
                {
                    newPants.RemoveAt(userStyleR);
                    Console.WriteLine("\nThat syle has been remove!");
                    Console.WriteLine();
                    testing2 = false;
                    welcome();
                }
                else if (userStyleR > newPants.Count && parseSuccess1)
                {
                    Console.WriteLine("Please only enter a Location # listed above:");
                }
                else
                {
                    Console.WriteLine("Please only enter a Location # listed above:");
                }
            }
        }

        public void lookUp()
        {
            Console.WriteLine("These are all the pants we have:\n");
            foreach (var item in newPants)
            {
                Console.WriteLine($"Style: {item.Style}");

                foreach (var all in item.Size)
                {
                    Console.WriteLine($"Size: {all}");
                }
                Console.WriteLine();
            }
            welcome();
        }
    }
}