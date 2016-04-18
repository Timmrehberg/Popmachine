using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Machine
    {
        public Inventory inventory = new Inventory();
        public Grape grapdesoda = new Grape();
        public Orange orangesoda = new Orange();
        public Meat meatsoda = new Meat();

        public Machine()
        {
            for (int i = 0; i < 20; i++)
            {
                inventory.machinesquarters.Add(new Quarter());
            }
            for (int i = 0; i < 10; i++)
            {
                inventory.machinedimes.Add(new Dime());
            }
            for (int i = 0; i < 20; i++)
            {
                inventory.machinenickels.Add(new Nickel());
            }
            for (int i = 0; i < 50; i++)
            {
                inventory.machinepennies.Add(new Penny());
            }

        }
        public void Buy()
        {

            Console.WriteLine("Which soda would you like to buy?1.Grape,2.Orange,3.Meat");
            string canchoice = Console.ReadLine();
            switch (canchoice)
            {
                case "1":
                    Console.WriteLine("Total is: " + grapdesoda.price);
                    CheckGrape();
                    Removechange(grapdesoda);
                    Buymore();
                    break;
                    
                case "2":
                    Console.WriteLine("Total is: " + orangesoda.price);
                    CheckOrange();
                    Removechange(orangesoda);
                    Buymore();
                    break;
                case "3":
                    Console.WriteLine("Total is: " + meatsoda.price);
                    CheckMeat();
                    Removechange(meatsoda);
                    Buymore();
                    break;
              
                default:
                    Console.WriteLine("Invalid Choice:Reenter");
                    Buy();
                    break;
                    

            }
        }
        public void Removechange(Soda can)
        {
            decimal change;
            Console.WriteLine("Enter money");
            decimal enterchange = Convert.ToDecimal(Console.ReadLine());
            if (enterchange > 1.00m)
            {
                Console.WriteLine("Sorry we only accept change and singles");
                Buy();
            }
            else if (enterchange.Equals(can.price))
            {
                can.ammountofCans -= 1;
                Console.WriteLine("No change");
                Console.WriteLine("Can dispensing");
                
            }
            else if (enterchange > can.price )
            {
                can.ammountofCans -= 1;
                Console.WriteLine("Change dispensing");
                Console.WriteLine("Change is " + (change = enterchange - can.price));
                for (int i = 0; i < 10; i++)
                {
                    if (change >= 0.25m && change > 0 && inventory.machinesquarters.Count > 0)
                    {
                        inventory.machinesquarters.RemoveAt(0); 
                        change -= 0.25m;
                    }
                    

                    if (change < 0.25m  && change >= 0.10m && inventory.machinedimes.Count > 0  && change > 0|| inventory.machinesquarters.Count <= 0)
                    {
                        inventory.machinedimes.RemoveAt(0);
                        change -= 0.10m;
                    }

                    if (change < 0.10m  && change >= 0.05m && change >0 && inventory.machinenickels.Count > 0 || inventory.machinedimes.Count <= 0)
                    {
                        inventory.machinenickels.RemoveAt(0);
                        change -= 0.05m;
                    }

                    if (change <= 0.05m  && change > 0 && inventory.machinepennies.Count > 0 || inventory.machinenickels.Count <= 0)
                    {
                        checkchange();
                        inventory.machinepennies.RemoveAt(0);
                        change -= 0.01m;
                    }
                    if(change <= 0)
                    {
                        break; 
                    }
                }
            }
        }

        public void CheckGrape()
        {
            if (grapdesoda.ammountofCans <= 0)
            {
                Console.WriteLine("Out of stock!");
                Environment.Exit(0);
            }
        }
        public void CheckOrange()
        {
            if (orangesoda.ammountofCans <= 0)
            {
                Console.WriteLine("Out of stock!");
                Environment.Exit(0);
            }
        }
        public void CheckMeat()
        {
            if (meatsoda.ammountofCans <= 0)
            {
                Console.WriteLine("Out of stock!");
                Environment.Exit(0);
            }
        }
        public void checkchange()
        {
            if(inventory.machinepennies.Count <= 0)
            {
                Console.WriteLine("Sorry for the inconvience but we have sadly ran out of change:Refund Dispensing");
                Environment.Exit(0);
            }
        }
        public void Buymore()
        {
            Console.WriteLine("Is your transaction complete?-1.No,2.Yes");
            string buymore = Console.ReadLine();
            if (buymore.Equals("1"))
            {
                Buy();
            } else
            {
                Console.WriteLine("Thanks for your service!");
                Environment.Exit(0);
            }
        }
    }
}
