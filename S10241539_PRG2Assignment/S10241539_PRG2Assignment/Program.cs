using S10241539_PRG2Assignment;
using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

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
        "[7] Advanced Features\n" +
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
        currentCustomer.Rewards = new PointCard(Convert.ToInt32(customerDetail[4]), Convert.ToInt32(customerDetail[5]));
        // Add this object into the array.
        cs.Add(currentCustomer);
    }
}

void InitialiseOrderlist(Queue<Order> GoldOrders, Queue<Order> NormalOrders)
{
    List<int> idlist = new List<int>();
    using (StreamReader reader = new StreamReader("orders.csv"))
    {
        // Skip the header line
        string[] header = reader.ReadLine().Split(',');

        //gets a bool value that indicates if the current stream position is at the end of the stream so that loop only stops when at end of csv
        while (!reader.EndOfStream)
        {
            string[] values = reader.ReadLine().Split(',');

            int id = Convert.ToInt32(values[0]);
            bool idexists = false;
            if (idlist.Contains(id))
            {
                idexists = true;
            }
            else
            {
                idexists = false;
                idlist.Add(id);
            }
            DateTime timeReceived = Convert.ToDateTime(values[2]);
            DateTime timeFulfilled = Convert.ToDateTime(values[3]);
            int memberId = Convert.ToInt32(values[1]);

            List<Flavour> flavours = new List<Flavour>();
            List<Topping> toppings = new List<Topping>();
            IceCream iceCream = null;
            Topping topping = null;
            Flavour flavour = null;
            string option = values[4];
            int scoops = Convert.ToInt32(values[5]);
            if (option == "Cup")
            {
                for (int i = 1; i < scoops; i++)
                {
                    bool premium = false;
                    if (values[7 + i].ToUpper() == "DURIAN" || values[7 + i].ToUpper() == "UBE" || values[7 + i].ToUpper() == "SEA SALT")
                    {
                        premium = true;
                        flavour = new Flavour(values[7 + i], premium);
                        flavours.Add(flavour);
                    }
                    else
                    {
                        premium = false;
                        flavour = new Flavour(values[7 + i], premium);
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
                for (int i = 1; i < scoops; i++)
                {
                    bool premium = false;
                    if (values[7 + i].ToUpper() == "DURIAN" || values[7 + i].ToUpper() == "UBE" || values[7 + i].ToUpper() == "SEA SALT")
                    {
                        premium = true;
                        flavour = new Flavour(values[7 + i], premium);
                        flavours.Add(flavour);
                    }
                    else
                    {
                        premium = false;
                        flavour = new Flavour(values[7 + i], premium);
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
                for (int i = 1; i < scoops; i++)
                {
                    bool premium = false;
                    if (values[7 + i].ToUpper() == "DURIAN" || values[7 + i].ToUpper() == "UBE" || values[7 + i].ToUpper() == "SEA SALT")
                    {
                        premium = true;
                        flavour = new Flavour(values[7 + i], premium);
                        flavours.Add(flavour);
                    }
                    else
                    {
                        premium = false;
                        flavour = new Flavour(values[7 + i], premium);
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
            foreach (Customer customer in customerList)
            {
                if (customer.MemberId == memberId)
                {
                    if (customer.Rewards.Tier == "Gold")
                    {
                        // Check if order with the same id already exists
                        if (idexists == true)
                        {
                            foreach (Order ord in customer.OrderHistory)
                            {
                                if (ord.TimeReceived == timeReceived)
                                {
                                    ord.IceCreamList.Add(iceCream);
                                }
                            }
                        }
                        else
                        {
                            Order newOrder = new Order(id, timeReceived);
                            newOrder.TimeFulfilled = timeFulfilled;
                            newOrder.IceCreamList.Add(iceCream);
                            customer.OrderHistory.Add(newOrder);
                        }
                    }
                    else
                    {
                        // Check if order with the same id already exists
                        if (idexists == true)
                        {
                            //Finds the order which is supposed to have ice creams with the same id
                            foreach (Order ord in customer.OrderHistory)
                            {
                                if (ord.TimeReceived == timeReceived)
                                {
                                    ord.IceCreamList.Add(iceCream);
                                }
                            }
                        }
                        Order newOrder = new Order(id, timeReceived);
                        newOrder.TimeFulfilled = timeFulfilled;
                        newOrder.IceCreamList.Add(iceCream);
                        customer.OrderHistory.Add(newOrder);
                    }
                }
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
            if (o.TimeFulfilled != null)
            {
                Console.WriteLine($"Gold Members\n{o}\n");
            }
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
    string newCustomerName = "";
    int newCustomerID = 0;
    // Enter customer's information
    Console.Write("Enter customer's name: ");
    newCustomerName = Console.ReadLine();
    Console.Write("Enter customer's ID: ");
    newCustomerID = Convert.ToInt32(Console.ReadLine());
    if (newCustomerID < 100000)
    {
        Console.WriteLine("Please enter a 6-digit Id that does not start with 0");
    }
    else
    {
        bool idfound = false;
        foreach (Customer customer in customerList)
        {
            if (newCustomerID == customer.MemberId)
            {
                idfound = true;
                break;
            }
        }
        if (idfound == true)
        {
            Console.WriteLine("ID already in use.");
        }
        else
        {
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
    }
}

// Feature 4: Create customer order
void CreateCustomerOrder()
{
    // Display the customer's information.
    DisplayCustomerInformation();

    try
    {
        string[] customers = File.ReadAllLines("customers.csv");
        bool idFound = false;
        
        // Ask user to choose customer.
        Console.Write("Enter your customer ID: ");
        int customerID = Convert.ToInt32(Console.ReadLine());

        // Create the order object.
        Order newOrder = new Order(customerID, DateTime.Now);


        // Get the serving option from the user.
        Console.Write("What would you like your serving option to be? (Cup/Cone/Waffle): ");
        string serv = Console.ReadLine();
        if (serv.ToUpper() == "CUP" || serv.ToUpper() == "CONE" || serv.ToUpper() == "WAFFLE")
        {

            Console.Write("What would like to change your number of scoops to? (1/2/3 Scoops): ");
            //Checking the user input to get a new value for scoops
            int scoops = Convert.ToInt32(Console.ReadLine());

            //Checking if the user has entered a valid number of scoops
            if (scoops < 1 && scoops > 3)
            {
                Console.WriteLine("Please select from the given options: (1/2/3).");
            }
            else
            {
                //initialzing new flavour list to add flavour objects later
                List<Flavour> flavors = new List<Flavour>();
                //initializing a flavour object to make the creation and adding of flavour objects better 
                Flavour flavour1 = new Flavour();
                int flav = 0;
                //looping for as many times as there are scoops as each scoop needs a flavour
                for (int i = scoops; i > 0; i--)
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
                            $"\nWhich Flavours do you want (You have {i - 1} choices remaining): ");
                        //get customer's flavour choice
                        flav = Convert.ToInt32(Console.ReadLine());
                        string flavour = "";
                        //using flavour object from before to create a new flavour object to add later into the list of flavour objects
                        //When choosing regular flavours 
                        if (flav == 1)
                        {
                            flavour = "Vanilla";
                            flavour1 = new Flavour(flavour, false);
                            flavors.Add(flavour1);
                            break;
                        }
                        else if (flav == 2)
                        {
                            flavour = "Chocolate";
                            flavour1 = new Flavour(flavour, false);
                            flavors.Add(flavour1);
                            break;
                        }
                        else if (flav == 3)
                        {
                            flavour = "Strawberry";
                            flavour1 = new Flavour(flavour, false);
                            break;
                        }
                        //When choosing Premimum flavours
                        else if (flav == 4)
                        {
                            flavour = "Durian";
                            flavour1 = new Flavour(flavour, true);
                            flavors.Add(flavour1);
                            break;
                        }
                        else if (flav == 5)
                        {
                            flavour = "Ube";
                            flavour1 = new Flavour(flavour, true);
                            flavors.Add(flavour1);
                            break;
                        }
                        else if (flav == 6)
                        {
                            flavour = "Sea Salt";
                            flavour1 = new Flavour(flavour, true);
                            flavors.Add(flavour1);
                            break;
                        }
                        //telling user to pick a valid option
                        else
                        {
                            Console.WriteLine("Please Choose a viable option.");
                        }
                    }
                }

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
                        "[0] Finish Choices\n" +
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
                    newOrder.AddIceCream(iceCream);
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
                        if (ans.ToUpper() == "Y")
                        {
                            IceCream iceCream = new Cone(serv, scoops, flavors, toppings, true);
                            newOrder.AddIceCream(iceCream);
                            break;
                        }
                        else if (ans.ToUpper() == "N")
                        {
                            IceCream iceCream = new Cone(serv, scoops, flavors, toppings, false);
                            newOrder.AddIceCream(iceCream);
                            break;
                        }
                        //If any input provided is not in the list of options is given a message will be outputted
                        else
                        {
                            Console.WriteLine("Please answer with either Y or N.\n");
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
                            newOrder.AddIceCream(iceCream);
                            break;
                        }
                        else if (waffleflavour == 1)
                        {
                            IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Red Velvet");
                            newOrder.AddIceCream(iceCream);
                            break;
                        }
                        else if (waffleflavour == 2)
                        {
                            IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Charcoal");
                            newOrder.AddIceCream(iceCream);
                            break;
                        }
                        else if (waffleflavour == 3)
                        {
                            IceCream iceCream = new Waffle(serv, scoops, flavors, toppings, "Pandan");
                            newOrder.AddIceCream(iceCream);
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
            Console.WriteLine("Please select from the given options: Cup/Cone/Waffle.");
        }

        // If true, order summary will be displayed.
        Console.WriteLine("Order Summary: \n" + newOrder + "\n");
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input type!");
    }
}

//Feature 5: lists customers and depending on the user's selection displays all information on a customer's order
void DisplayOrderDetails()
{
    try
    {
        //displays customer information
        DisplayCustomerInformation();
        Console.Write("Which Customer's order history would you like to access (Enter Member Id): ");
        //get user input for which user they want to access
        int DispOrder = Convert.ToInt32(Console.ReadLine());
        // Search customerList for selected Customer
        foreach (Customer customer in customerList)
        {
            if (customer.MemberId == DispOrder)
            {
                if (customer.OrderHistory.Count > 0)
                {
                    //Prints out details of every order in the selected customer's OrderHistory
                    foreach (Order ord in customer.OrderHistory)
                    {
                        Console.WriteLine(ord);
                    }
                }
                else
                { Console.WriteLine("This customer has no orders!"); }
            }
        }
    }
    //Input Validation to catch and handle errors that are outputted by invalid inputs
    //To check if the wrong format is entered into the input statement
    catch (FormatException)
    {
        Console.WriteLine("Please enter a integer number corresponding to the Member Id of your desired customer.");
    }
    //To check if the user did not give any input and provided a null input
    catch (ArgumentNullException)
    {
        Console.WriteLine("Please enter a Member Id that belongs to your chosen customer.");
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
    DisplayCustomerInformation();

    while (true)
    {
        int search = 0;
        try
        {
            Console.Write("Select a Customer (Enter Id of desired Customer): ");
            search = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid integer number.");
            continue; // Skip the rest of the loop iteration and start over
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number you entered is too large or too small.");
            continue; // Skip the rest of the loop iteration and start over
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("No input entered");
            continue; // Skip the rest of the loop iteration and start over
        }

        if (search < 100000)
        {
            Console.WriteLine("Input is too short. Please enter Member Id length of 6");
        }
        else if (search > 999999)
        {
            Console.WriteLine("Input is too long. Please enter Member Id length of 6");
        }
        else
        {
            foreach (Customer customer in customerList)
            {
                if (search == customer.MemberId)
                {
                    if (customer.OrderHistory.Count == 0)
                    {
                        Console.WriteLine("This customer hasn't made any orders yet!\n");
                        break;
                    }
                    else
                    {
                        Order latestOrder = customer.OrderHistory.LastOrDefault();

                        Console.WriteLine("\nLatest Order Summary: \n" + latestOrder + "\n");

                        if (latestOrder.TimeFulfilled != null)
                        {
                            Console.WriteLine("This order has already been fulfilled. Unable to modify this order");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Options:\n" +
                                          "[1] Modify an existing Ice Cream\n" +
                                          "[2] Add a new Ice Cream\n" +
                                          "[3] Delete an existing Ice Cream\n" +
                                          "[0] Exit");

                            Console.Write("Enter Your Choice: ");
                            int option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    ModifyExistingIceCream(latestOrder);
                                    break;
                                case 2:
                                    AddNewIceCream(latestOrder);
                                    break;
                                case 3:
                                    DeleteExistingIceCream(latestOrder);
                                    break;
                                case 0:
                                    return;
                                default:
                                    Console.WriteLine("Invalid option. Please enter a valid choice.");
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A member with this member Id does not exist.");
                    break;
                }
            }
        }
    }
}


void ModifyExistingIceCream(Order latestOrder)
{
    // Modify existing Ice Cream logic
    //initializes a list called ice creams that stores all 
    List<IceCream> iceCreams = latestOrder.IceCreamList;

    //Prints out every icecream in the latest order
    for (int i = 0; i < iceCreams.Count; i++)
    {
        Console.WriteLine($"[{i + 1}] {iceCreams[i]}");
    }
    int modice = 0;
    try
    {
        //Asks the user which Ice Cream they want to modify
        Console.Write("\nEnter the number of the Ice Cream that you want to modify: ");
        modice = Convert.ToInt32(Console.ReadLine());
    } catch (FormatException)
    {
        Console.WriteLine("Please enter a integer of the correponding option");
    } catch(OverflowException)
    {
        Console.WriteLine("Input was longer that 32 bits. Please choose an option from the menu and enter its corressponding option number");
    }
    //Calling the ModifyIceCream method in the Order Class to modify the ice cream
    latestOrder.ModifyIceCream(modice - 1); // minussing one here to offset C#'s counting from 0
    Console.WriteLine("Order Summary: \n" + latestOrder + "\n");
}

void AddNewIceCream(Order latestOrder)
{
    CreateCustomerOrder();
    Console.WriteLine("Order Summary: \n" + latestOrder + "\n");
}

void DeleteExistingIceCream(Order latestOrder)
{
    // Delete existing Ice Cream logic
    try
    {
        Console.Write("Which Ice Cream do you want to delete: ");
        int ice = Convert.ToInt32(Console.ReadLine());
        latestOrder.DeleteIceCream(ice - 1);// minussing one here to offset C#'s counting from 0
    }
    catch (Exception)
    {
        Console.WriteLine("Please enter a valid Ice Cream.");
    }
}


//==================
//Advanced features|
//==================

int AdvancedMenu()
{
    Console.Write("\n=================\n" +
        "Advanced Features\n" +
        "=================\n" +
        "[1] Process an order and checkout\n" +
        "[2] Display total charged amounts for the year and monthly charged amounts breakdown\n" +
        "[0] Exit\n" +
        "Please enter your option: ");
    int option = Convert.ToInt32(Console.ReadLine());
    return option;
}
void DisplayChargedAmts()
{
    //initializing a list variable that stores order objects that are in the given time frame
    List<Order> validOrders = new List<Order>();
    int Year = 0;
    //gets user input for which year to showcase
    Console.Write("Enter the year: ");
    Year = Convert.ToInt32(Console.ReadLine());
    if(Year > 2024)
    {
        Console.WriteLine("You have specified a year in the far far future. Come back then to see the updated data. For now, enter a year after 1999 but before 2025.");
    }
    else if(Year < 2000)
    {
        Console.WriteLine("I am sorry but we did NOT exist then. For now, enter a year after 1999 but before 2025.");
    }
    else
    {
        foreach (Customer customer in customerList)
        {
            foreach (Order ord in customer.OrderHistory)
            {
                int ordYear = Convert.ToInt32(ord.TimeFulfilled?.Year);
                if (ordYear == Year)
                {
                    validOrders.Add(ord);
                }
            }
        }
        //dictonary of months and the total amount of money earned in each month
        Dictionary<string, double> datesortedorders = new Dictionary<string, double>
    {
        { "January", 0 },
        { "February", 0 },
        { "March", 0 },
        { "April", 0 },
        { "May", 0 },
        { "June", 0 },
        { "July", 0 },
        { "August", 0 },
        { "September", 0 },
        { "October", 0 },
        { "November", 0 },
        { "December", 0 }
    };

        //total for the specified year
        double yeartotal = 0;
        foreach (Order ord in validOrders)
        {
            datesortedorders[ord.TimeFulfilled?.ToString("MMMM")] += ord.CalculateTotal();
        }

        foreach (KeyValuePair<string, double> kvp in datesortedorders)
        {
            Console.WriteLine($"{kvp.Key} {Year}\t\t${kvp.Value}");
        }

    }
}
    

// Main Program
// Other features yet to be implemented.
// While loop to invoke user input infinitely.

while (true)
{
    // Display the main menu to show options.
    int userOption = DisplayOutput();

    // Initialise "customerList" for later use by program.
    InitialiseCustomerList(customerList);
    InitialiseOrderlist(GoldOrders, NormalOrders);
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
        CreateCustomerOrder();
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
    else if (userOption == 7)
    {
        //If it is, it will invoke DisplayAdvancedMenu function and asks the user which advanced option they want to execute
        int option = AdvancedMenu();
        if (option == 1)
        {

        }
        else if (option == 2)
        {
            try
            {
                DisplayChargedAmts();
            }
            catch(FormatException)
            {
                Console.WriteLine("Enter year in integers. The year must be after 1999 but before 2025.");
            } 
            catch(OverflowException) 
            {
                Console.WriteLine("Your Year is larger than a 32 bits please shorten it to a a 4-digit year that is after 1999 but before 2025.");
            }
        }
    }
    else if (userOption == 0)
    {
        // If it is, it exits the loop, and program will stop.
        Console.WriteLine("Program ended.");
        // Exit the program
        break;
    }
    else
    {
        // Print error message.
        Console.WriteLine("No valid option selected");
    }
}
/*
    catch (FormatException)
    {
        Console.WriteLine("Please enter a integer option number");
    }
    //To check if the user did not give any input and provided a null input
    catch (ArgumentNullException)
    {
        Console.WriteLine("Please enter a valid value that isn't null");
    }
    //Any other potentially unforseen input appears
    catch (Exception)
    {
        Console.WriteLine("Please enter a valid integer option value.");
    }
*/