using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10241539
// Student Name : Javier Lim
// Partner Name : Keshav P Chidambaram
//==========================================================

namespace S10241539_PRG2Assignment
{
    internal class Order
    {
        //Creating private id, timeRecieved and timeFulfilled objects to ensure that the initialization code is only called when necessary
        private int id;
        private DateTime timeReceived;
        private DateTime? timeFulfilled;

        //Initializing the public points, punchcard and tier objects to get inputs that can be used later in the class
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList = new List<IceCream>();

        //constructors
        public Order() 
        {
            IceCreamList = new List<IceCream>();
        }
        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
            
        }

        //Creating a method that allows the customer to edit every aspect of their order 
        public void ModifyIceCream(int id)
        {
            try
            {
                IceCream selectice = IceCreamList[id];
                //Checking the user input get a new value 
                Console.Write("What would you like your serving option to be? (Cup/Cone/Waffle): ");
                string serv = Console.ReadLine();
                if (serv.ToUpper() == "CUP" || serv.ToUpper() == "CONE" || serv.ToUpper() == "WAFFLE")
                {

                    Console.Write("What would like to change your number of scoops to? (1/2/3 Scoops): ");
                    //Checking the user input to get a new value for scoops
                    int scoops = Convert.ToInt32(Console.ReadLine());

                    //Checking if the user has entered a valid number of scoops
                    if (scoops == 1 || scoops == 2 || scoops == 3)
                    {
                        //initialzing new flavour list to add flavour objects later
                        List<Flavour> flavors = new List<Flavour>();
                        //initializing a flavour object to make the creation and adding of flavour objects better 
                        Flavour flavour1 = new Flavour();
                        int flav = 0;
                        //looping for as many times as there are scoops as each scoop needs a flavour
                        for (int i = 0; i < scoops; i++)
                        {
                            //creating a while loop that is infinitely running until the user inputs a valid answer
                            while (true)
                            {
                                //displaying menu for customer to choose flavour
                                Console.Write("Flavour Menu\n" +
                                    "------------\n" +
                                    "Regular Flavours\n" +
                                    "[1] Vanilla\n" +
                                    "[2] Chocolate\n" +
                                    "[3] Strawberry\n" +
                                    "\nPremium Flavours (+$2)\n" +
                                    "[4] Durian\n" +
                                    "[5] Ube\n" +
                                    "[6] Sea Salt\n" +
                                    $"\nWhich Flavours do you want (You have {i} choices remaining): ");
                                //get customer's flavour choice
                                flav = Convert.ToInt32(Console.ReadLine());
                                string flavour = "";
                                //using flavour object from before to create a new flavour object to add later into the list of flavour objects
                                //When choosing regular flavours 
                                if (flav == 1)
                                {
                                    flavour = "Vanilla";
                                    flavour1 = new Flavour(flavour, false, 1);
                                    break;
                                }
                                else if (flav == 2)
                                {
                                    flavour = "Chocolate";
                                    flavour1 = new Flavour(flavour, false, 1);
                                    break;
                                }
                                else if (flav == 3)
                                {
                                    flavour = "Strawberry";
                                    flavour1 = new Flavour(flavour, false, 1);
                                    break;
                                }
                                //When choosing Premimum flavours
                                else if (flav == 4)
                                {
                                    flavour = "Durian";
                                    flavour1 = new Flavour(flavour, true, 1);
                                    break;
                                }
                                else if (flav == 5)
                                {
                                    flavour = "Ube";
                                    flavour1 = new Flavour(flavour, true, 1);
                                    break;
                                }
                                else if (flav == 6)
                                {
                                    flavour = "Sea Salt";
                                    flavour1 = new Flavour(flavour, true, 1);
                                    break;
                                }
                                //telling user to pick a valid option
                                else
                                {
                                    Console.WriteLine("Please Choose a viable option.");
                                }
                            }
                        }
                        //Checking if the count of flavour objects is equal to the number of scoops to proceed to the next step in icecream creation
                        if (flavors.Count == scoops)
                        {
                            //initialzing new toppings list to add topping objects later 
                            List<Topping> toppings = new List<Topping>();
                            //initializing a toping object to make the creation and adding of topping objects better 
                            Topping topping = new Topping();
                            //creating a while loop that is infinitely running until the user says they do not want anymore toppings
                            while (true)
                            {
                                //displaying the toppings menu
                                Console.Write("Toppings Menu (+$1/each)\n" +
                                    "-------------\n" +
                                    "[1] Sprinkles\n" +
                                    "[2] Mochi\n" +
                                    "[3] Sago\n" +
                                    "[4] Oreos\n" +
                                    "[5] I will not be having any toppings\n" +
                                    "[0] Finish Choices" +
                                    "Which toppings would you like: ");
                                int topchoice = Convert.ToInt32(Console.ReadLine());
                                //Checks for which option the user wants to choose and executes it
                                if (topchoice == 1)
                                {
                                    topping = new Topping("Sprinkes");
                                    toppings.Add(topping);
                                }
                                else if (topchoice == 2)
                                {
                                    topping = new Topping("Mochi");
                                    toppings.Add(topping);
                                }
                                else if (topchoice == 3)
                                {
                                    topping = new Topping("Sago");
                                    toppings.Add(topping);
                                }
                                else if (topchoice == 4)
                                {
                                    topping = new Topping("Oreos");
                                    toppings.Add(topping);

                                }
                                else if (topchoice == 5 || topchoice == 0)
                                {
                                    //ends loop When the user does not want anything or they want to complete their order
                                    if (topchoice == 5)
                                    {
                                        Console.WriteLine("No toppings chosen!\nNow finishing topping choices!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Now finishing topping choices!");
                                    }
                                    break;
                                }
                                //If any input provided is not in the list of options is given a message will be outputted
                                else
                                {
                                    Console.WriteLine("Please choose from the given choices");
                                }
                            }
                            //checking if customer wants a cup serving so that other choices that need to be made can be made
                            if (serv.ToUpper() == "CUP")
                            {
                                //create and add an IceCream object
                                IceCream iceCream = new Cup(serv, scoops, flavors, toppings);
                                selectice = iceCream;
                            }
                            //checking if customer wants a cone serving so that other choices that need to be made can be made
                            else if (serv.ToUpper() == "CONE")
                            {
                                //creating a while loop that is infinitely running until the user inputs a valid answer
                                while (true)
                                {
                                    //Checking if the customer wants their cone dipped in chocolate
                                    Console.Write("Do you want you cone dipped in chocolate (Y/N): ");
                                    //get customers' answer
                                    string ans = Console.ReadLine();
                                    //update using customers choice
                                    //create and add an IceCream object based on the choice they made
                                    if (ans.ToUpper() == "Y" || ans.ToUpper() == "YES")
                                    {
                                        IceCream iceCream = new Cone(serv, scoops, flavors, toppings, true);
                                        selectice = iceCream;
                                        break;
                                    }
                                    else if (ans.ToUpper() == "N" || ans.ToUpper() == "NO")
                                    {
                                        IceCream iceCream = new Cone(serv, scoops, flavors, toppings, false);
                                        selectice = iceCream;
                                        break;
                                    }
                                    //If any input provided is not in the list of options is given a message will be outputted
                                    else
                                    {
                                        Console.WriteLine("Please anser with either Y/Yes or N/No.\n");
                                    }
                                }

                            }
                            //checking if customer wants a waffle serving so that other choices that need to be made can be made
                            else
                            {
                                //creating a while loop that is infinitely running until the user inputs a valid answer
                                while (true)
                                {
                                    //menu to ask customer what flavour of waffle they want
                                    Console.Write("Waffle flavours\n" +
                                        "---------------\n" +
                                        "[1] Red Velvet (+$3)\n" +
                                        "[2] Charcoal (+$3)\n" +
                                        "[3] Pandan (+$3)\n" +
                                        "[0] Regular\n" +
                                        "What flavoured waffle would you like: ");
                                    //get which option they chose
                                    int waffleflavour = Convert.ToInt32(Console.ReadLine());
                                    //create and add an IceCream object based on the choice they made
                                    if (waffleflavour == 0)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Regular");
                                        selectice = iceCream;
                                        break;
                                    }
                                    else if (waffleflavour == 1)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Red Velvet");
                                        selectice = iceCream;
                                        break;
                                    }
                                    else if (waffleflavour == 2)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Charcoal");
                                        selectice = iceCream;
                                        break;
                                    }
                                    else if (waffleflavour == 3)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Pandan");
                                        selectice = iceCream;
                                        break;
                                    }
                                    //If any input provided is not in the list of options is given a message will be outputted
                                    else
                                    {
                                        Console.WriteLine("Please select a valid flavour option.\n");
                                    }

                                }

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select from the given options: (1/2/3).");
                    }
                }
                else
                {
                    Console.WriteLine("Please select from the given options: Cup/Cone/Waffle.");
                }
            }
            //Input Validation to catch and handle errors that are outputted by invalid inputs
            //To check if the wrong format is entered into the input statement
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer number");
            }
            //To check if the user did not give any input and provided a null input
            catch (ArgumentNullException)
            {
                Console.WriteLine("Please enter a valid value that isn't null");
            }
            //Any other potentially unforseen input appears
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid integer value.");
            }
        }


        //Creating a method, AddIceCream that adds an IceCream object into the IceCreamList
        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }


        public void DeleteIceCream(int id)
        {
            try
            {
                IceCreamList.RemoveAt(id);
            } catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please enter a valid Id.");
            } catch (Exception) 
            {
                Console.WriteLine("Please enter a valid input that is also an existing Id.");
            }
        }
         public double CalculateTotal()
        {
            double total = 0;
            foreach (IceCream ice in IceCreamList)
            {
                total += ice.CalculatePrice();
            }
            return total;
        }
        public override string ToString()
        {
            string l = "";
            l += ($"Id: {Id} Time Recieved: {TimeReceived} Time Fulfilled: {TimeFulfilled}\n");
            int num = 1;
            foreach (IceCream I in IceCreamList)
            {
                l += $"[{num}] "+ I + "Price: "+ I.CalculatePrice() + "\n";
                num++;
            }
            return l;
        }
    }
}
