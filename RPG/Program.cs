using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace RPG
{
    public static class Program
    {
        static double money = 0;
        static double exp;
        static double level = 1;

        //Shop Items
        static bool intermediateFishingRod = false;
        static bool advancedFishingRod = false;
        static bool expertFishingRod = false;
        static bool legendaryFishingRod = false;
        static bool standardFishingHook = false;
        static bool premiumFishingHook = false;
        static bool deluxeFishingHook = false;
        static bool ultimateFishingHook = false;

        //Random
        static readonly Random rnd = new();
        public static void Main()
        {
            if (File.Exists("Money.txt"))
            {
                using StreamReader srMoney = new("Money.txt");
                money = Convert.ToDouble(srMoney.ReadLine());
            }
            if (File.Exists("Exp.txt"))
            {
                using StreamReader srExp = new("Exp.txt");
                exp = Convert.ToDouble(srExp.ReadLine());
            }
            if (File.Exists("Level.txt"))
            {
                using StreamReader srLevel = new("Level.txt");
                level = Convert.ToDouble(srLevel.ReadLine());
            }
            if (File.Exists("IntermediateFishingRod.txt"))
            {
                using StreamReader srIntermediateFishingRod = new("IntermediateFishingRod.txt");
                intermediateFishingRod = Convert.ToBoolean(srIntermediateFishingRod.ReadLine());
            }
            if (File.Exists("AdvancedFishingRod.txt"))
            {
                using StreamReader srAdvancedFishingRod = new("AdvancedFishingRod.txt");
                advancedFishingRod = Convert.ToBoolean(srAdvancedFishingRod.ReadLine());
            }
            if (File.Exists("ExpertFishingRod.txt"))
            {
                using StreamReader srExpertFishingRod = new("ExpertFishingRod.txt");
                expertFishingRod = Convert.ToBoolean(srExpertFishingRod.ReadLine());
            }
            if (File.Exists("LegendaryFishingRod.txt"))
            {
                using StreamReader srLegendaryFishingRod = new("LegendaryFishingRod.txt");
                legendaryFishingRod = Convert.ToBoolean(srLegendaryFishingRod.ReadLine());
            }
            if (File.Exists("StandardFishingHook.txt"))
            {
                using StreamReader srStandardFishingHook = new("StandardFishingHook.txt");
                standardFishingHook = Convert.ToBoolean(srStandardFishingHook.ReadLine());
            }
            if (File.Exists("PremiumFishingHook.txt"))
            {
                using StreamReader srPremiumFishingHook = new("PremiumFishingHook.txt");
                premiumFishingHook = Convert.ToBoolean(srPremiumFishingHook.ReadLine());
            }
            if (File.Exists("DeluxeFishingHook.txt"))
            {
                using StreamReader srDeluxeFishingHook = new("DeluxeFishingHook.txt");
                deluxeFishingHook = Convert.ToBoolean(srDeluxeFishingHook.ReadLine());
            }
            if (File.Exists("UltimateFishingHook.txt"))
            {
                using StreamReader srUltimateFishingHook = new("UltimateFishingHook.txt");
                ultimateFishingHook = Convert.ToBoolean(srUltimateFishingHook.ReadLine());
            }


            string playerName;
            bool fileExists = false;
            
            if (File.Exists("Name.txt"))
            {
                fileExists = true;
            }
            if (fileExists == false)
            {
                Console.WriteLine("Enter your name: ");
                playerName = Console.ReadLine();
                using (StreamWriter sw = new("Name.txt"))
                {
                    sw.WriteLine(playerName);
                }
                Thread.Sleep(500);
                Console.WriteLine("\nWelcome " + playerName + "!");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if(fileExists == true) 
            {
                using StreamReader sr = new("Name.txt");
                Console.WriteLine("Welcome Back " + sr.ReadLine() + "!");
                Thread.Sleep(2000);
                Console.Clear();
            }
            ListTasks();
        }

        static void ListTasks()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("What would you like to do: ");
                Console.WriteLine("\n(1) Go Fish");
                Console.WriteLine("(2) Sleep");
                Console.WriteLine("(3) Stats");
                Console.WriteLine("(4) Shop");
                Console.WriteLine("(5) Save And Exit");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    GoFish();
                }
                else if(choice == "2")
                {
                    GoSleep();
                }
                else if(choice == "3")
                {
                    GoStats();
                }
                else if(choice == "4")
                {
                    GoShop();
                }
                else if(choice == "5")
                {
                    SaveAndExit();
                }
                else
                {
                    Console.WriteLine("'" + choice + "' Is Not An Option");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }while(repeat == true);
            
        }

        static void GoFish()
        {
            int fishAmount;
            int bigFishAmount = 0;

            Console.Clear();
            Thread.Sleep(1000);
            if (legendaryFishingRod == false)
            {
                Console.WriteLine("...");
                Thread.Sleep(1000);
            }
            if (expertFishingRod == false)
            {
                Console.WriteLine("\n...");
                Thread.Sleep(1000);
            }
            if (advancedFishingRod == false)
            {
                Console.WriteLine("\n...");
                Thread.Sleep(1000);
            }
            if (intermediateFishingRod == false)
            {
                Console.WriteLine("\n...");
                Thread.Sleep(1000);
            }

            if (standardFishingHook == true && premiumFishingHook == false)
            {
                fishAmount = rnd.Next(2, 5);
                if (level >= 2)
                {
                    bigFishAmount = rnd.Next(0, 2);
                }
            }
            else if (premiumFishingHook == true && deluxeFishingHook == false)
            {
                fishAmount = rnd.Next(4, 9);
                if (level >= 2)
                {
                    bigFishAmount = rnd.Next(1, 4);
                }
            }
            else if (deluxeFishingHook == true && ultimateFishingHook == false)
            {
                fishAmount = rnd.Next(8, 17);
                if (level >= 2)
                {
                    bigFishAmount = rnd.Next(2, 6);
                }
            }
            else if (ultimateFishingHook == true)
            {
                fishAmount = rnd.Next(16, 33);
                if (level >= 2)
                {
                    bigFishAmount = rnd.Next(3, 8);
                }
            }
            else
            {
                fishAmount = rnd.Next(1, 3);
            }
            Console.WriteLine("\nYou Cought " + fishAmount +  " Fish!");
            if (level >= 2)
            {
                Console.WriteLine("You Cought " + bigFishAmount + " Big Fish!");
            }

            Console.WriteLine(" +" + (fishAmount + (3 * bigFishAmount)) + " Exp\n");


            exp += (1 * fishAmount);
            exp += (3 * bigFishAmount);

            if (exp >= 5 && exp < 15)
            {
                if (level == 1)
                {
                   Console.WriteLine("  You Are Now Level " + "2\n You Can Now Catch Big Fish!\n");
                }
                level = 2;
            }
            else if (exp >= 15 && exp < 50)
            {
                if (level == 2)
                {
                    Console.WriteLine(" You Are Now Level " + "3\n You Unlocked 'Advanced Fishing Rod', 'Premium Fishing Hook'\n");
                }
                level = 3;
            }
            else if (exp >= 50 && exp < 250)
            {
                if (level == 3)
                {
                    Console.WriteLine(" You Are Now Level " + "4\n Rerward: $100\n");
                    money += 100;
                    Console.WriteLine("Balance: $" + money);
                }
                level = 4;
            }
            else if (exp >= 250 && exp < 500)
            {
                if (level == 4)
                {
                    Console.WriteLine(" You Are Now Level " + "5\n You Unlocked 'Expert Fishing Rod', 'Deluxe Fishing Hook'\n");
                }
                level = 5;
            }
            else if (exp >= 500 && exp < 1000)
            {
                if (level == 5)
                {
                    Console.WriteLine(" You Are Now Level " + "6\n Reward: Nothing...\n");
                }
                level = 6;
            }
            else if (exp >= 1000)
            {
                if (level == 6)
                {
                    Console.WriteLine(" You Are Now Level " + "7\n You Unlocked 'Legendary Fishing Rod', 'Ultimate Fishing Hook'\n");
                }
                level = 7;
            }

            bool repeat = true;
            do
            {
                Thread.Sleep(500);
                Console.WriteLine("Do You Want To Sell It?");
                Console.WriteLine("(1) Yes");
                Console.WriteLine("(2) No");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    money += (1 * fishAmount);
                    money += (5 * bigFishAmount);
                    if (level >= 2)
                    {
                        Console.WriteLine("\nYou Sold " + fishAmount + " Fish And " + bigFishAmount + " Big Fish For $" + (fishAmount + (5 * bigFishAmount)) + "\nBalance: $" + money);
                    }
                    else
                    {
                        Console.WriteLine("\nYou Sold " + fishAmount + " Fish For $" + fishAmount + "\nBalance: $" + money);
                    }
                    
                    Thread.Sleep(2000);
                    repeat = false;
                    Console.Clear();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nYou Released " + fishAmount + " Fish And " + bigFishAmount + " Big Fish");
                    Thread.Sleep(2000);
                    repeat = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }while (repeat == true);
        }

        static void GoSleep()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("You Slept...");
            Thread.Sleep(2000);
            Console.Clear();
        }

        static void GoStats()
        {
            Console.Clear();
            Console.WriteLine("- STATS -");
            Console.WriteLine("\nBalance: $" + money);
            Console.WriteLine("EXP: " + exp);
            Console.WriteLine("LV: " + level + "");
            Console.WriteLine("\n(e) Exit");
            if (Console.ReadLine() == "e")
            {
                Console.Clear();
            }
        }

        static double intermediateFishingRodNum = 1;
        static double advancedFishingRodNum = 2;
        static double expertFishingRodNum = 3;
        static double legendaryFishingRodNum = 4;
        static double standardHookNum = 5;
        static double premiumHookNum = 6;
        static double deluxeHookNum = 7;
        static double ultimateHookNum = 8;
        static void GoShop()
        {
            bool repeat = true;



            do
            {
                Console.Clear();
                Console.WriteLine("- SHOP - Balance: $" + money);

                Console.WriteLine("\n-- Fishing Rods --");
                if (intermediateFishingRod == false)
                {
                    Console.WriteLine("\n(" + intermediateFishingRodNum + ")" + " Intermediate Fishing Rod [$5]");
                }
                if (level >= 3)
                {
                    if (advancedFishingRod == false)
                    {
                        Console.WriteLine("\n(" + advancedFishingRodNum + ")" + " Advanced Fishing Rod [$25]");
                    }
                    if (level >= 5)
                    {
                        if (expertFishingRod == false)
                        {
                            Console.WriteLine("\n(" + expertFishingRodNum + ")" + " Expert Fishing Rod [$100]");
                        }
                        if (level >= 7)
                        {
                            if (legendaryFishingRod == false)
                            {
                                Console.WriteLine("\n(" + legendaryFishingRodNum + ")" + " Legendary Fishing Rod [$500]");
                            }
                        }
                    }
                }


                Console.WriteLine("\n-- Fishing Hooks --");
                if (standardFishingHook == false)
                {
                    Console.WriteLine("\n(" + standardHookNum + ")" + " Standard Fishing Hook [$10]");
                }
                if (level >= 3)
                {
                    if (premiumFishingHook == false)
                    {
                        Console.WriteLine("\n(" + premiumHookNum + ")" + " Premium Fishing Hook [$50]");
                    }
                    if (level >= 5)
                    {
                        if (deluxeFishingHook == false)
                        {
                            Console.WriteLine("\n(" + deluxeHookNum + ")" + " Deluxe Fishing Hook [$250]");
                        }
                        if (level >= 7)
                        {
                            if (ultimateFishingHook == false)
                            {
                                Console.WriteLine("\n(" + ultimateHookNum + ")" + " Ultimate Fishing Hook [$1000]");
                            }
                        }
                    }
                }




                Console.WriteLine("\n(e) Exit");

                string choice = Console.ReadLine();
                //Intermediate Fishing Rod
                if (choice == "1" && money >= 5 && intermediateFishingRod == false)
                {
                    intermediateFishingRod = true;
                    Console.WriteLine("You Bought A Intermediate Fishing Rod!");
                    money -= 5;
                    advancedFishingRodNum--;
                    expertFishingRodNum--;
                    legendaryFishingRodNum--;
                    intermediateFishingRodNum--;
                    standardHookNum--;
                    premiumHookNum--;
                    deluxeHookNum--;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == "1" && money < 5 && intermediateFishingRod == false)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Advanced Fishing Rod
                else if (choice == Convert.ToString(advancedFishingRodNum) && money >= 25 && level >= 3)
                {
                    advancedFishingRod = true;
                    Console.WriteLine("You Bought An Advanced Fishing Rod!");
                    money -= 25;
                    advancedFishingRodNum--;
                    expertFishingRodNum--;
                    legendaryFishingRodNum--;
                    standardHookNum--;
                    premiumHookNum--;
                    deluxeHookNum--;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == Convert.ToString(advancedFishingRodNum) && money < 25 && level >= 3)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Expert Fishing Rod
                else if (choice == Convert.ToString(expertFishingRodNum) && money >= 100 && level >= 5)
                {
                    expertFishingRod = true;
                    Console.WriteLine("You Bought An Expert Fishing Rod!");
                    money -= 100;
                    expertFishingRodNum--;
                    legendaryFishingRodNum--;
                    standardHookNum--;
                    premiumHookNum--;
                    deluxeHookNum--;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == Convert.ToString(expertFishingRodNum) && money < 100 && level >= 5)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Legendary Fishing Rod
                else if (choice == Convert.ToString(legendaryFishingRodNum) && money >= 500 && level >= 7)
                {
                    legendaryFishingRod = true;
                    Console.WriteLine("You Bought A Legendary Fishing Rod!");
                    money -= 500;
                    legendaryFishingRodNum--;
                    standardHookNum--;
                    premiumHookNum--;
                    deluxeHookNum--;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == Convert.ToString(legendaryFishingRodNum) && money < 500 && level >= 7)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Standard Fishing Hook
                else if (choice == Convert.ToString(standardHookNum) && money >= 10)
                {
                    standardFishingHook = true;
                    Console.WriteLine("You Bought A Standard Fishing Hook!");
                    money -= 10;
                    standardHookNum--;
                    premiumHookNum--;
                    deluxeHookNum--;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == Convert.ToString(standardHookNum) && money < 10)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Premium Fishing Hook
                else if (choice == Convert.ToString(premiumHookNum) && money >= 50 && level >= 3)
                {
                    premiumFishingHook = true;
                    Console.WriteLine("You Bought A Premium Fishing Hook!");
                    money -= 10;
                    premiumHookNum--;
                    deluxeHookNum--;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == Convert.ToString(premiumHookNum) && money < 50 && level >= 3)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Deluxe Fishing Hook
                else if (choice == Convert.ToString(deluxeHookNum) && money >= 250 && level >= 5)
                {
                    deluxeFishingHook = true;
                    Console.WriteLine("You Bought A Standard Fishing Hook!");
                    money -= 10;
                    deluxeHookNum--;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == Convert.ToString(deluxeHookNum) && money < 250 && level >= 5)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Ultimate Fishing Hook
                else if (choice == Convert.ToString(ultimateHookNum) && money >= 1000 && level >= 7)
                {
                    ultimateFishingHook = true;
                    Console.WriteLine("You Bought A Ultimate Fishing Hook!");
                    money -= 1000;
                    ultimateHookNum--;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == Convert.ToString(ultimateHookNum) && money < 1000 && level >= 7)
                {
                    Console.WriteLine("You Don't Have Enough Money!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                //Exit
                else if (choice == "e")
                {
                    repeat = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("'" + choice + "' Is Not An Option");
                    Thread.Sleep(1000);
                }
            } while (repeat == true);
        }

        static void SaveAndExit()
        {
            using (StreamWriter swMoney = new("Money.txt"))
            {
                swMoney.WriteLine(money);
            }
            using (StreamWriter swExp = new("Exp.txt"))
            {
                swExp.WriteLine(exp);
            }
            using (StreamWriter swLevel = new("Level.txt"))
            {
                swLevel.WriteLine(level);
            }
            using (StreamWriter swIntermediateFishingRod = new("IntermediateFishingRod.txt"))
            {
                if (intermediateFishingRod == true) 
                {
                    swIntermediateFishingRod.WriteLine(intermediateFishingRod);
                }
            }
            using (StreamWriter swAdvancedFishingRod = new("AdvancedFishingRod.txt"))
            {
                if (advancedFishingRod == true)
                {
                    swAdvancedFishingRod.WriteLine(advancedFishingRod);
                }
            }
            using (StreamWriter swExpertFishingRod = new("ExpertFishingRod.txt"))
            {
                if (expertFishingRod == true)
                {
                    swExpertFishingRod.WriteLine(expertFishingRod);
                }
            }
            using (StreamWriter swLegendaryFishingRod = new("LegendaryFishingRod.txt"))
            {
                if (legendaryFishingRod == true)
                {
                    swLegendaryFishingRod.WriteLine(legendaryFishingRod);
                }
            }
            using (StreamWriter swStandardFishingHook = new("StandardFishingHook.txt"))
            {
                if (standardFishingHook == true)
                {
                    swStandardFishingHook.WriteLine(standardFishingHook);
                }
            }
            using (StreamWriter swPremiumFishingHook = new("PremiumFishingHook.txt"))
            {
                if (premiumFishingHook == true)
                {
                    swPremiumFishingHook.WriteLine(premiumFishingHook);
                }
            }
            using (StreamWriter swDeluxeFishingHook = new("DeluxeFishingHook.txt"))
            {
                if (deluxeFishingHook == true)
                {
                    swDeluxeFishingHook.WriteLine(deluxeFishingHook);
                }
            }
            using (StreamWriter swUltimateFishingHook = new("UltimateFishingHook.txt"))
            {
                if (ultimateFishingHook == true)
                {
                    swUltimateFishingHook.WriteLine(ultimateFishingHook);
                }
            }
            Environment.Exit(0);
        }
    }
}