using S10241539_PRG2Assignment;
using System.Diagnostics.Tracing;
using System.Globalization;

//==========================================================
// Student Number : S10241539
// Student Name : Javier Lim
// Partner Name : Keshav P Chidambaram
//==========================================================


Queue<Order> NormalOrders = new Queue<Order>();
Queue<Order> GoldOrders = new Queue<Order>();
List<Customer> customerList = new List<Customer>(); //Initializing list of customers

// Method to print the Menu and obtain a user defined option. This makes calling the Menu out again easier
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

//Feature 5: lists customers and depending on the user's selection displays all information on a customer's order
void DisplayOrderDetails()
{
    /*
    for (int i = 0; i < customerList.Count; i++)
    {
        List<Order> orderHistory = customerList[i].OrderHistory;
        DateTime timeFulfilled = DateTime.Now;
        Console.WriteLine($"Order ID: {orderHistory[i].Id}\nTime Order Recieved: {orderHistory[i].TimeReceived.ToLongTimeString}\n Order Fulfilled: {timeFulfilled.ToLongTimeString()}");
    }
    */
}

/*
list the customers
 prompt user to select a customer and retrieve the selected customer
 retrieve all the order objects of the customer, past and current
 for each order, display all the details of the order including datetime received, datetime
fulfilled (if applicable) and all ice cream details associated with the order
*/

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
                                Console.WriteLine($"[{i}] {iceCreams[i]}");
                            }
                            //Asks the user which Ice Cream they want to modify
                            Console.Write("\nEnter the number of the Ice Cream that you want to modify: ");
                            int modice = Convert.ToInt32(Console.ReadLine());
                            latestord.ModifyIceCream(modice);
                            
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
            Console.WriteLine("Please enter a valid integer value.");
        }
    }
}

/*
list the customers
 prompt user to select a customer and retrieve the selected customer’s current order +
 list all the ice cream objects contained in the order +
 prompt the user to either [1] choose an existing ice cream object to modify, [2] add an 
entirely new ice cream object to the order, or [3] choose an existing ice cream object to 
delete from the order +
o if [1] is selected, have the user select which ice cream to modify then prompt the user 
for the new information for the modifications they wish to make to the ice cream
selected: option, scoops, flavours, toppings, dipped cone (if applicable), waffle flavour 
(if applicable) and update the ice cream object’s info accordingly
o if [2] is selected prompt the user for all the required info to create a new ice cream 
object and add it to the order
o if [3] is selected, have the user select which ice cream to delete then remove that ice 
cream object from the order. But if this is the only ice cream in the order, then simply 
display a message saying they cannot have zero ice creams in an order
 display the new updated order
*/

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