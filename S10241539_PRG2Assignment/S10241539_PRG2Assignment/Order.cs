using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Creating a method that allows the customer to edit every aspect of their order 
        public void ModifyIceCream(int id)
        {
            IceCream selectIceCream = IceCreamList[id];
            string serv = "";
            while (serv != "CUP" || serv.ToUpper() != "CONE" || serv.ToUpper() != "WAFFLE")
            {
                // Checking the user input to get a new value for serving option
                Console.Write("What would you like your serving option to be? (Cup/Cone/Waffle): ");
                try
                {
                    serv = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your input was too long. Please choose one of these three options (Cup/Cone/Waffle) and enter their name.");
                    continue;
                }
            }
            if (serv.ToUpper() == "CUP" || serv.ToUpper() == "CONE" || serv.ToUpper() == "WAFFLE")
            {
                Console.Write("What would you like to change your number of scoops to? (1/2/3 Scoops): ");
                // Checking the user input to get a new value for scoops
                try
                {
                    int scoops = Convert.ToInt32(Console.ReadLine());
                    // Checking if the user has entered a valid number of scoops
                    if (scoops == 1 || scoops == 2 || scoops == 3)
                    {
                        // Initializing new flavour list to add flavour objects later
                        List<Flavour> flavors = new List<Flavour>();
                        // Initializing a flavour object to make the creation and adding of flavour objects better 
                        Flavour flavour1 = new Flavour();
                        int flav = 0;
                        // Looping for as many times as there are scoops as each scoop needs a flavour
                        for (int i = 0; i < scoops; i++)
                        {
                            // Creating a while loop that is infinitely running until the user inputs a valid answer
                            while (true)
                            {
                                // Displaying menu for customer to choose flavour
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
                                // Get customer's flavour choice
                                try
                                {
                                    flav = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please enter a valid integer number for the flavour choice.");
                                    continue;
                                }
                                string flavour = "";
                                // Using flavour object from before to create a new flavour object to add later into the list of flavour objects
                                // When choosing regular flavours 
                                if (flav == 1)
                                {
                                    flavour = "Vanilla";
                                    flavour1 = new Flavour(flavour, false);
                                    break;
                                }
                                else if (flav == 2)
                                {
                                    flavour = "Chocolate";
                                    flavour1 = new Flavour(flavour, false);
                                    break;
                                }
                                else if (flav == 3)
                                {
                                    flavour = "Strawberry";
                                    flavour1 = new Flavour(flavour, false);
                                    break;
                                }
                                // When choosing Premimum flavours
                                else if (flav == 4)
                                {
                                    flavour = "Durian";
                                    flavour1 = new Flavour(flavour, true);
                                    break;
                                }
                                else if (flav == 5)
                                {
                                    flavour = "Ube";
                                    flavour1 = new Flavour(flavour, true);
                                    break;
                                }
                                else if (flav == 6)
                                {
                                    flavour = "Sea Salt";
                                    flavour1 = new Flavour(flavour, true);
                                    break;
                                }
                                // Telling user to pick a valid option
                                else
                                {
                                    Console.WriteLine("Please Choose a viable option.");
                                }
                            }
                        }
                        // Checking if the count of flavour objects is equal to the number of scoops to proceed to the next step in icecream creation
                        if (flavors.Count == scoops)
                        {
                            // Initializing new toppings list to add topping objects later 
                            List<Topping> toppings = new List<Topping>();
                            // Initializing a toping object to make the creation and adding of topping objects better 
                            Topping topping = new Topping();
                            // Creating a while loop that is infinitely running until the user says they do not want anymore toppings
                            while (true)
                            {
                                // Displaying the toppings menu
                                Console.Write("Toppings Menu (+$1/each)\n" +
                                    "-------------\n" +
                                    "[1] Sprinkles\n" +
                                    "[2] Mochi\n" +
                                    "[3] Sago\n" +
                                    "[4] Oreos\n" +
                                    "[5] I will not be having any toppings\n" +
                                    "[0] Finish Choices" +
                                    "Which toppings would you like: ");
                                int topchoice = 0;
                                // Checks for which option the user wants to choose and executes it
                                try
                                {
                                    topchoice = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please enter a valid integer number for the topping choice.");
                                    continue;
                                }
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
                                    // Ends loop when the user does not want anything or they want to complete their order
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
                                // If any input provided is not in the list of options is given a message will be outputted
                                else
                                {
                                    Console.WriteLine("Please choose from the given choices");
                                }
                            }
                            // Checking if customer wants a cup serving so that other choices that need to be made can be made
                            if (serv.ToUpper() == "CUP")
                            {
                                // Create and add an IceCream object
                                IceCream iceCream = new Cup(serv, scoops, flavors, toppings);
                                selectIceCream = iceCream;
                            }
                            // Checking if customer wants a cone serving so that other choices that need to be made can be made
                            else if (serv.ToUpper() == "CONE")
                            {
                                // Creating a while loop that is infinitely running until the user inputs a valid answer
                                while (true)
                                {
                                    // Checking if the customer wants their cone dipped in chocolate
                                    Console.Write("Do you want your cone dipped in chocolate (Y/N): ");
                                    // Get customers' answer
                                    string ans = Console.ReadLine();
                                    // Update using customers choice
                                    // Create and add an IceCream object based on the choice they made
                                    if (ans.ToUpper() == "Y" || ans.ToUpper() == "YES")
                                    {
                                        IceCream iceCream = new Cone(serv, scoops, flavors, toppings, true);
                                        selectIceCream = iceCream;
                                        break;
                                    }
                                    else if (ans.ToUpper() == "N" || ans.ToUpper() == "NO")
                                    {
                                        IceCream iceCream = new Cone(serv, scoops, flavors, toppings, false);
                                        selectIceCream = iceCream;
                                        break;
                                    }
                                    // If any input provided is not in the list of options is given a message will be outputted
                                    else
                                    {
                                        Console.WriteLine("Please answer with either Y/Yes or N/No.\n");
                                    }
                                }
                            }
                            // Checking if customer wants a waffle serving so that other choices that need to be made can be made
                            else
                            {
                                // Creating a while loop that is infinitely running until the user inputs a valid answer
                                while (true)
                                {
                                    // Menu to ask customer what flavour of waffle they want
                                    Console.Write("Waffle flavours\n" +
                                        "---------------\n" +
                                        "[1] Red Velvet (+$3)\n" +
                                        "[2] Charcoal (+$3)\n" +
                                        "[3] Pandan (+$3)\n" +
                                        "[0] Regular\n" +
                                        "What flavoured waffle would you like: ");
                                    // Get which option they chose
                                    int waffleflavour = 0;
                                    try
                                    {
                                        waffleflavour = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Please enter a valid integer number for the waffle flavour choice.");
                                        continue;
                                    }
                                    // Create and add an IceCream object based on the choice they made
                                    if (waffleflavour == 0)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Regular");
                                        selectIceCream = iceCream;
                                        break;
                                    }
                                    else if (waffleflavour == 1)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Red Velvet");
                                        selectIceCream = iceCream;
                                        break;
                                    }
                                    else if (waffleflavour == 2)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Charcoal");
                                        selectIceCream = iceCream;
                                        break;
                                    }
                                    else if (waffleflavour == 3)
                                    {
                                        IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Pandan");
                                        selectIceCream = iceCream;
                                        break;
                                    }
                                    // If any input provided is not in the list of options is given a message will be outputted
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
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid integer number for the number of scoops.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you entered is too large or too small.");
                }
            }
            else
            {
                Console.WriteLine("Please select from the given options: Cup/Cone/Waffle.");
            }
        }


        
        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }


        public void DeleteIceCream(int id)
        {
            try
            {
                IceCreamList.RemoveAt(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please enter a valid Id.");
            }
            catch (Exception)
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
            //Creating a tostring that prints out all neccessary details about the order
            string l = "";
            int num = 1;
            //to append every icecream object in the order
            foreach (IceCream I in IceCreamList)
            {
                l += $"[{num}] " + I + "Price: " + I.CalculatePrice() + "\n";
                num++;
            }
            if (TimeFulfilled != null)
            {
                l += ($"Id: {Id}\nTime Recieved: {TimeReceived}\nTime Fulfilled: {TimeFulfilled}\n");
            }
            else
            {
                l += ($"Id: {Id} Time Recieved: {TimeReceived}\n");
            }
            return l;
        }
    }
}
