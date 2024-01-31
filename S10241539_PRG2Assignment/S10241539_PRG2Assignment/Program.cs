using S10241539_PRG2Assignment;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Globalization;

//==========================================================
// Student Number : S10241539
// Student Name : Javier Lim
// Partner Name : Keshav P Chidambaram
//==========================================================

//Javier Basic Features 1, 3, 4.
//Keshav Basic Features 2, 5, 6.

Queue<Order> NormalOrders = new Queue<Order>();
Queue<Order> GoldOrders = new Queue<Order>();
List<Customer> customerList = new List<Customer>(); //Initializing list of customers

// Method to print the Menu and obtain a user defined option. This makes calling the Menu out again easier

// ==========
// Functions|
// ==========

int DisplayOutput()
{
    // Dislays the options.
    Console.WriteLine(
        "Menu\n" +
        "----\n" +
        "[1] Display All Customers\n" +
        "[2] List All Current Orders\n" +
        "[3] Register a New Customer\n" +
        "[4] Create a Customer's Order\n" +
        "[5] Display Order Details of a Customer\n" +
        "[6] Modify Order Details\n" +
        "[0] Exit\n----\n"
    );

    // Prompt the user to enter option.
    Console.Write("Please Enter Your Option: ");

    // Convert input to integer (as the default type is string).
    int option = Convert.ToInt32(Console.ReadLine());
    
    //Extra line for better readability
    Console.WriteLine();

    // Return the option user entered.
    return option;
}

// Initialise "customerList" for later use by program.
void InitialiseCustomerList(List<Customer> cs)
{
    // Reads from the "customers.csv" file.
    string[] customers = File.ReadAllLines("customers.csv");

    // Loops through the array created.
    for (int i = 1; i < customers.Length; i++)
    {
        // Create another array for each customer.
        string[] customerDetail = customers[i].Split(',');

        // Create the "Customer" object with name, ID, and date of birth.
        Customer currentCustomer = new Customer(customerDetail[0], Convert.ToInt32(customerDetail[1]), Convert.ToDateTime(customerDetail[2]));

        // Add this object into the array.
        cs.Add(currentCustomer);
    }
}

void InitialiseOrderlist(List<Order> orders)
{
    using (StreamReader reader = new StreamReader("orders.csv"))
    {
        // Skip the header line
        string[] header = reader.ReadLine().Split(',');

        //gets a bool value that indicates if the current stream position is at the end of the stream so that loop only stops when at end of csv
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            string[] values = line.Split(',');

            int id = Convert.ToInt32(values[0]);
            DateTime timeReceived = Convert.ToDateTime(values[2]);
            DateTime timeFulfilled = Convert.ToDateTime(values[3]);

            List<Flavour> flavours = new List<Flavour>();
            List<Topping> toppings = new List<Topping>();
            IceCream iceCream = null;
            Topping topping = null;
            Flavour flavour = null;
            string option = values[4];
            int scoops = Convert.ToInt32(values[5]);
            if (option == "Cup")
            {
                for (int i = 1; 1 <= scoops; i++)
                {
                    bool premium = false;
                    if (values[7 + i].ToUpper() == "DURIAN" || values[8].ToUpper() == "UBE" || values[8].ToUpper() == "SEA SALT")
                    {
                        premium = true;
                        flavour = new Flavour(values[7 + i], premium, 1);
                        flavours.Add(flavour);
                    }
                    else
                    {
                        premium = false;
                        flavour = new Flavour(values[7 + i], premium, 1);
                        flavours.Add(flavour);
                    }
                }
                foreach (string value in values)
                {
                    if (value.ToUpper() == "SPRINKLES" || value.ToUpper() == "MOCHI" || value.ToUpper() == "SAGO" || value.ToUpper() == "OREOS")
                    {
                        topping = new Topping(value);
                        toppings.Add(topping);
                    }
                }
                iceCream = new Cup(option, scoops, flavours, toppings);
            }
            //If order serving option is a Cone 
            else if (option == "Cone")
            {
                bool isdipped = false;
                for (int i = 1; 1 <= scoops; i++)
                {
                    bool premium = false;
                    if (values[7 + i].ToUpper() == "DURIAN" || values[8].ToUpper() == "UBE" || values[8].ToUpper() == "SEA SALT")
                    {
                        premium = true;
                        flavour = new Flavour(values[7 + i], premium, 1);
                        flavours.Add(flavour);
                    }
                    else
                    {
                        premium = false;
                        flavour = new Flavour(values[7 + i], premium, 1);
                        flavours.Add(flavour);
                    }
                }
                foreach (string value in values)
                {
                    if (value.ToUpper() == "SPRINKLES" || value.ToUpper() == "MOCHI" || value.ToUpper() == "SAGO" || value.ToUpper() == "OREOS")
                    {
                        topping = new Topping(value);
                        toppings.Add(topping);
                    }
                }
                if (values[6] == "TRUE")
                {
                    isdipped = true;
                }
                else
                {
                    isdipped = false;
                }
                iceCream = new Cone(option, scoops, flavours, toppings, isdipped);
            }
            else
            {
                string waffleflav = "";
                for (int i = 1; 1 <= scoops; i++)
                {
                    bool premium = false;
                    if (values[7 + i].ToUpper() == "DURIAN" || values[8].ToUpper() == "UBE" || values[8].ToUpper() == "SEA SALT")
                    {
                        premium = true;
                        flavour = new Flavour(values[7 + i], premium, 1);
                        flavours.Add(flavour);
                    }
                    else
                    {
                        premium = false;
                        flavour = new Flavour(values[7 + i], premium, 1);
                        flavours.Add(flavour);
                    }
                }
                foreach (string value in values)
                {
                    if (value.ToUpper() == "SPRINKLES" || value.ToUpper() == "MOCHI" || value.ToUpper() == "SAGO" || value.ToUpper() == "OREOS")
                    {
                        topping = new Topping(value);
                        toppings.Add(topping);
                    }
                }
                if (values[7].ToUpper() == "RED VELVET" || values[7].ToUpper() == "CHARCOAL" || values[7].ToUpper() == "PANDAN WAFFLE" || values[7].ToUpper() == "ORIGINAL")
                {
                    waffleflav = values[7];
                }
                else
                {
                    waffleflav = "Original";
                }
                iceCream = new Waffle(option, scoops, flavours, toppings, waffleflav);
            }

            // Check if order with the same id already exists
            Order existingOrder = orders.Find(o => o.Id == id);
            if (existingOrder != null)
            {
                existingOrder.IceCreamList.Add(iceCream);
            }
            else
            {
                Order newOrder = new Order(id, timeReceived);
                newOrder.TimeFulfilled = timeFulfilled;
                newOrder.IceCreamList.Add(iceCream);
                orders.Add(newOrder);
            }
        }
    }
}

// =========
// Features|
// =========

// Feature 1: List all customers
void DisplayCustomerInformation()
{
    // Creates an array based on the data in customer.csv.
    // Each item is a line from the csv file.
    string[] customers = File.ReadAllLines("customers.csv");

    // Since the heading is the first line, an array is created to get the first line and split it,
    // so that it can be displayed in tabular form.
    string[] heading = customers[0].Split(',');

    // Displays the header for the table.
    Console.WriteLine("\nCustomer Information");
    Console.WriteLine("--------------------");
    Console.WriteLine($"{heading[0],-15}{heading[1],-10}{heading[2],-15}{heading[3],-20}{heading[4],-20}{heading[5],-5}");

    // Loop through the array, starting from index '1', which is the second line of the csv file.
    for (int i = 1; i < customers.Length; i++)
    {
        // Since the each item in "customers" array represents a line in the csv, it has yet to be separated.
        // Hence, we have to loop through the array and split each line.
        string[] customerDetail = customers[i].Split(',');

        // Display the customer information.
        Console.WriteLine($"{customerDetail[0],-15}{customerDetail[1],-10}{customerDetail[2],-15}{customerDetail[3],-20}{customerDetail[4],-20}{customerDetail[5],-5}");
    }

    // Print a new line for ease of viewing.
    Console.WriteLine();
}

//Feature 2: List all Orders from both gold and normal queue
void ListAllOrders()
{
    //Checks if there are no orders in Gold queue
    if (GoldOrders.Count == 0) 
    {
        Console.WriteLine("No orders in gold queue.");
    }
    //Prints out details of orders from the customers in the Gold queue
    else
    {
        foreach (Order o in GoldOrders)
        {
            Console.WriteLine($"Gold Members\n{o}\n");
        }
    }
    //Checks if there are no orders in Normal queue
    if (NormalOrders.Count == 0)
    {
        Console.WriteLine("No orders in normal queue.\n");
    }
    //Prints out details of orders from the customers in the Normal queue
    else
    {
        foreach (Order o in NormalOrders)
        {
            Console.WriteLine($"Normal Members\n{o}\n");
        }
    }
}

// Feature 3: Register new customer
void RegisterNewCustomer()
{
    // Enter customer's information
    Console.Write("Enter customer's name: ");
    string newCustomerName = Console.ReadLine();
    Console.Write("Enter customer's ID: ");
    int newCustomerID = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter customer's date of birth: ");
    DateTime newCustomerDOB = Convert.ToDateTime(Console.ReadLine());

    // Create new customer object.
    Customer newCustomer = new Customer(newCustomerName, newCustomerID, newCustomerDOB);

    // Create "PointCard" object, and assign it to customer.
    PointCard newPointCard = new PointCard(0, 0);
    newPointCard.Tier = "Ordinary";
    newCustomer.Rewards = newPointCard;

    // Create line to be appended by program.
    string data = newCustomerName + "," + newCustomerID + "," + newCustomerDOB + newPointCard.Tier + newPointCard.Points + newPointCard.PunchCard;

    // Append data to csv file.
    File.AppendAllText("customers.csv", $"\n{data}");
}

//Feature 5: lists customers and depending on the user's selection displays all information on a customer's order
void DisplayOrderDetails()
{
    try
    {
        //displays customer information
        DisplayCustomerInformation();
        Console.Write("Which Customer's order history would you like to access (Enter Member Id) : ");
        //get user input for which user they want to access
        int DispOrder = Convert.ToInt32(Console.ReadLine());
        // Search customerList for selected Customer
        for (int i = 0; i < customerList.Count; i++)
        {
            if (customerList[i].MemberId == DispOrder) 
            {
                //Prints out details of every order in the selected customer's OrderHistory
                foreach(Order ord in customerList[i].OrderHistory)
                {
                    Console.WriteLine(ord);
                }
            }
            else { Console.WriteLine("A customer with this member Id does not exist."); }
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
        Console.WriteLine("Please enter a valid value from the options given.");
    }
}

//Feature 6: manages customer orders, allowing selection, modification, addition, or deletion of ice cream objects, and displaying the updated order.
void ModifyOrderDetails()
{
    //caling the first feature for easier printing of customers
    DisplayCustomerInformation();
    while (true)
    {
        Console.Write("Select a Customer (Enter Id of desired Customer): ");
        try
        {
            //Getting a  value from the user to search for the customer whose latest order they want to modify
            int search = Convert.ToInt32(Console.ReadLine());
            //Looping through every customer in customer list to check if the memberId and the id entered in search is the same
            foreach (Customer customer in customerList)
            {
                //Checks if there is a customer with the memberId of "search"
                if (search == customer.MemberId)
                {
                    //To check if the selected customer has yet to make an order
                    if (customer.OrderHistory.Count == 0)
                    {
                        Console.WriteLine("This customer hasn't made any orders yet! Maybe you should convince them to order at our Ice Cream Shop! :)\n");
                    }
                    else
                    {
                        //calls the OrderHistory list from a Customer object's OrderHistory list
                        List<Order> ordlist = customer.OrderHistory;
                        Order latestord = ordlist[ordlist.Count - 1];
                        //displaying the selected customer's latest order
                        Console.WriteLine("\n" + latestord + "\n");

                        //displaying the options the customer can choose
                        Console.Write("What would you like to do with this order?\n------------------------------------------" +
                            "[1] Modify an existing Ice Cream\n" +
                            "[2] Add a new Ice Cream\n" +
                            "[3] Delete an existing Ice Cream\n" +
                            "[0] Exit" +
                            "\nEnter Your Choice: ");
                        //reads the option the user has selected and changes it into a integer object
                        int option = Convert.ToInt32(Console.ReadLine());
                        if (option == 1)
                        {
                            //initializes a list called ice creams that stores all 
                            List<IceCream> iceCreams = latestord.IceCreamList;
                            
                            //Prints out every icecream in the latest order
                            for (int i = 0; i < iceCreams.Count; i++)
                            {
                                Console.WriteLine($"[{i + 1}] {iceCreams[i]}");
                            }
                            //Asks the user which Ice Cream they want to modify
                            Console.Write("\nEnter the number of the Ice Cream that you want to modify: ");
                            int modice = Convert.ToInt32(Console.ReadLine());
                            //Calling the ModifyIceCream method in the Order Class to modify the ice cream
                            latestord.ModifyIceCream(modice - 1); // minussing one here to offset C#'s counting from 0
                            Console.WriteLine("Order Summary: \n" + latestord + "\n");
                            break;
                        } 
                        else if (option == 2)
                        {
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
                                            latestord.AddIceCream(iceCream);
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
                                                    latestord.AddIceCream(iceCream);
                                                    break;
                                                }
                                                else if (ans.ToUpper() == "N" || ans.ToUpper() == "NO")
                                                {
                                                    IceCream iceCream = new Cone(serv, scoops, flavors, toppings, false);
                                                    latestord.AddIceCream(iceCream);
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
                                                    latestord.AddIceCream(iceCream);
                                                    break;
                                                }else if (waffleflavour == 1)
                                                {
                                                    IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Red Velvet");
                                                    latestord.AddIceCream(iceCream);
                                                    break;
                                                }else if (waffleflavour == 2)
                                                {
                                                    IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Charcoal");
                                                    latestord.AddIceCream(iceCream);
                                                    break;
                                                }else if(waffleflavour == 3)
                                                {
                                                    IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Pandan");
                                                    latestord.AddIceCream(iceCream);
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
                            Console.WriteLine("Order Summary: \n" + latestord + "\n");
                        }
                        else if (option == 3)
                        {
                            Console.Write("Which Ice Cream do you want to delete: ");
                            int ice = Convert.ToInt32(Console.ReadLine());
                            latestord.DeleteIceCream(ice - 1);// minussing one here to offset C#'s counting from 0
                        } 
                        else if (option == 0)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A member with this member Id does not exist.");
                    //To break out of for loop since there is no need to continue to loop through every customer
                    break;
                }
            }
            //To break out of while loop after breaking out of for loop
            break;
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
            Console.WriteLine("Please enter a valid value from the options given.");
        }
    }
}



// Main Program
// Other features yet to be implemented.
// While loop to invoke user input infinitely.
try
{
    while (true)
    {
        // Initialise "customerList" for later use by program.
        InitialiseCustomerList(customerList);
        // Display the main menu to show options.
        int userOption = DisplayOutput();

        // Checks if integer '1' is entered. 
        if (userOption == 1)
        {
            // If it is, it will invoke DisplayCustomerInformation function and displays detailed customer information.
            DisplayCustomerInformation();
        }
        else if (userOption == 2)
        {
            // If it is, it will invoke ListAllOrder function and displays detailed order information from both the Gold queue and the Normal Queue.
            ListAllOrders();
        }
        else if (userOption == 3)
        {
            RegisterNewCustomer();
        }
        else if (userOption == 4)
        {

        }
        else if (userOption == 5)
        {
            // If it is, it will invoke DisplayOrderDetails function and displays detailed customer order information.
            DisplayOrderDetails();
        }
        else if (userOption == 6)
        {
            //If it is, it will invoke ModifyOrderDetails function and asks the user the id of the customer and get the order which will then modify the order based on the user's requiremets
            ModifyOrderDetails();
        }
        // Checks if integer '0' is entered.
        else if (userOption == 0)
        {
            // If it is, it exits the loop, and program will stop.
            break;
        }
        else
        {
            //Tells the user that they have entered an invalid option number
            Console.WriteLine("Please enter a valid option number.");
        }
    }
}
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