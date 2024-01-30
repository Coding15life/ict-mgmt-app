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
            TimeFulfilled = DateTime.Now;
        }

        //Creating a method that allows the customer to edit every aspect of their order 
        public void ModifyIceCream(int i)
        {
            try
            {
                //Creating an ice cream object selectice to easily access the selected ice cream
                IceCream selectice = IceCreamList[i];

                //Displays a menu for the user to choose from and gets a string intput to allow for easier input handling
                Console.Write("---- Modify Ice Cream ----\n" +
                    "[1] Change Serving Option (Cup/Cone/Waffle)\n" +
                    "[2] Number of Scoops\n[3] Change Flavours\n" +
                    "[4] Change Toppings\n[0] Exit\n" +
                    "Please enter option: ");

                //reads user inputted option
                int opt = Convert.ToInt32(Console.ReadLine());

                // Checks if integer '1' is entered. 
                if (opt == 1)
                {
                    //Asking for the serving option the customer desires
                    Console.Write("What would you like to change your serving option to? (Cup/Cone/Waffle): ");
                    string serv = Console.ReadLine();
                    //Checking if a valid input was giving and giving a message if input was invalid
                    if (serv.ToUpper() == "CUP" || serv.ToUpper() == "CONE" || serv.ToUpper() == "WAFFLE")
                    {
                        selectice.Option = serv;
                        Console.WriteLine($"Updated ice cream details:\n{selectice}\n" +
                                $"New Price: ${selectice.CalculatePrice}");
                    }
                    else
                    {
                        Console.WriteLine("Please select from the given options: Cup/Cone/Waffle.");
                    }
                }
                // Checks if integer '2' is entered.
                else if (opt == 2)
                {
                    Console.Write("What would like to change your number of scoops to? (1/2/3 Scoops): ");
                    try
                    {
                        //Checking the user input to get a new modified value for scoops
                        int scoops = Convert.ToInt32(Console.ReadLine());

                        //Checking if the user has entered a valid number of scoops
                        if (scoops == 1 || scoops == 2 || scoops == 3)
                        {
                            selectice.Scoops = scoops;
                            Console.WriteLine($"Updated ice cream details:\n{selectice}\n" +
                                $"New Price: ${selectice.CalculatePrice}");
                        }
                        else if (scoops > 3)
                        {
                            Console.WriteLine("Maximum amount of scoops is 3");
                        }
                        else if (scoops < 1)
                        {
                            Console.WriteLine("Minimum amount of scoops is 1");
                        }
                        else
                        {
                            Console.WriteLine("Please choose an integer within the range 1 to 3.");
                        }

                    }
                    //Input Validation to catch and handle errors that are outputted by invalid inputs
                    //To check if the wrong format is entered into the input statement
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a integer number.");
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
                // Checks if integer '3' is entered.
                else if (opt == 3)
                {
                    //show the customer their current flavours
                    Console.WriteLine("Your current flavours are: ");
                    for (int s = 0; s < selectice.Flavours.Count; s++)
                    {
                        Console.WriteLine($"[{s + 1}] {selectice.Flavours[s]}");
                    }
                    //ask the customer which flavour they want to change
                    Console.Write("Which ice cream flavour do you want to edit (enter the number beside flavour): ");
                    int flav = Convert.ToInt32(Console.ReadLine());
                    //Checking if the number they input is a positive integer or a negative integer
                    if (flav <= 0)
                    {
                        Console.WriteLine("Please enter a positive integer value of the respective flavour.");
                    }
                    else
                    {
                        //minussing 1 here because C# starts counting from 0 
                        flav -= 1;
                        //Printing out a flavour menu where customer can choose which flavour they want
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
                            $"\nWhich Flavour do you want to change the flavour {selectice.Flavours[flav]} to: ");
                        int flavchg = Convert.ToInt32(Console.ReadLine());
                        //Checking if the number they input is a positive integer or a negative integer
                        if (flav > 0 && flav < 7)
                        {
                            //When changing to Regular flavours
                            if (flavchg == 1) { selectice.Flavours[flav].Type = "Vanilla"; }
                            else if (flavchg == 2) { selectice.Flavours[flav].Type = "Chocolate"; }
                            else if (flavchg == 3) { selectice.Flavours[flav].Type = "Strawberry"; }
                            //When changing to Premimum flavours
                            else if (flavchg == 4)
                            {
                                selectice.Flavours[flav].Type = "Durian";
                                selectice.Flavours[flav].Premium = true;
                            }
                            else if (flavchg == 5)
                            {
                                selectice.Flavours[flav].Type = "Ube";
                                selectice.Flavours[flav].Premium = true;
                            }
                            else if (flavchg == 6)
                            {
                                selectice.Flavours[flav].Type = "Sea Salt";
                                selectice.Flavours[flav].Premium = true;
                            }
                            //If their number goes above the range of flavours

                            Console.WriteLine($"Updated ice cream details:\n{selectice}\n" +
                                $"New Price: ${selectice.CalculatePrice}");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a positive integer value of the respective flavour.");
                        }
                    }
                }
                // Checks if integer '4' is entered.
                else if (opt == 4) 
                {
                    //Initialzing a toppings list using the IceCream object, selectice, for easier use later in the code
                    List<Topping> tlist = selectice.Toppings;
                    //tells the customer the toppings on the selected ice cream
                    Console.WriteLine("Your current toppings for this ice cream: ");
                    for (int s = 0; s < tlist.Count; s++)
                    {
                        Console.WriteLine($"[{s + 1}] {tlist[s]}");
                    }
                    //An extra choice if they want to add a new topping to thier ice cream
                    Console.WriteLine($"[{tlist.Count + 1}] Add a whole new topping");
                    Console.Write("Which topping do you want to change (Enter the number value for your desired topping): ");
                    int top = Convert.ToInt32(Console.ReadLine());
                    if (top > 0 && top <tlist.Count + 1)
                    {
                        //Since C# starts counting from 0, we need to minus one to get the actual index number
                        top -= 1;
                        //The menu for the customer to choose their topping
                        Console.Write("Toppings Menu\n" +
                            "-------------\n" +
                            "[1] Sprinkles\n" +
                            "[2] Mochi\n" +
                            "[3] Sago\n" +
                            "[4] Oreos\n" +
                            $"[0] Remove this topping: {tlist[top]}\n" +
                            "What do you want to change the topping to: ");
                        int topchoice = Convert.ToInt32(Console.ReadLine());
                        //Checks for which option the user wants to choose and executes it
                        if (topchoice == 1)
                        {
                            tlist[top].Type = "Sprinkes";
                        }
                        else if (topchoice == 2)
                        {
                            tlist[top].Type = "Mochi";
                        } 
                        else if (topchoice == 3)
                        {
                            tlist[top].Type = "Sago";
                        }
                        else if (topchoice == 4)
                        {
                            tlist[top].Type = "Oreos";
                        } 
                        else if (topchoice == 0)
                        {
                            tlist.RemoveAt(top);
                        }
                        //If any input not in the list of options is given a message will be outputted
                        else
                        {
                            Console.WriteLine("Please choose from the given choices");
                        }
                    } 
                    //To execute the option where ther topping is completely removed
                    else if (top == tlist.Count + 1)
                    {
                        //The menu for the customer to choose their topping
                        Console.Write("Toppings Menu\n" +
                            "-------------\n" +
                            "[1] Sprinkles\n" +
                            "[2] Mochi\n" +
                            "[3] Sago\n" +
                            "[4] Oreos\n" +
                            "What Topping would you like: ");
                        int newtop = Convert.ToInt32(Console.ReadLine());
                        //Checks for which option the user wants to choose and executes it
                        if (newtop == 1)
                        {
                            Topping topping = new Topping("Sprinkes");
                            tlist.Add(topping);
                        }
                        else if (newtop == 2)
                        {
                            Topping topping = new Topping("Mochi");
                            tlist.Add(topping);
                        }
                        else if (newtop == 3)
                        {
                            Topping topping = new Topping("Sago");
                            tlist.Add(topping);
                        }
                        else if (newtop == 4)
                        {
                            Topping topping = new Topping("Oreos");
                            tlist.Add(topping);
                        }
                        //If any input not in the list of options is given a message will be outputted
                        else
                        {
                            Console.WriteLine("Please choose from the given choices");
                        }
                    }
                    //If any input not in the list of options is given a message will be outputted
                    else
                    {
                        Console.WriteLine("Please choose from the given choices");
                    }
                    Console.WriteLine($"Updated ice cream details:\n{selectice}\n" +
                                $"New Price: ${selectice.CalculatePrice}");
                }
                // Checks if integer '0' is entered and exit the program when 0 is entered
                else if (opt == 0) {
                    Console.WriteLine($"Ice cream details:\n{selectice}\n" +
                                $"New Price: ${selectice.CalculatePrice}");
                }
                // If a non-integer object is given, a error is provided and breaks the for loop
                else
                {
                    Console.WriteLine("Please enter a valid option number.");
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

            return total;
        }
        public override string ToString()
        {
            string l = "";
            l += ($"Id: {Id} Time Recieved: {TimeReceived} Time Fulfilled: {TimeFulfilled}\n");
            foreach (IceCream I in IceCreamList)
            {
                l += (I.ToString() + "\n");
            }
            return l;
        }
    }
}
