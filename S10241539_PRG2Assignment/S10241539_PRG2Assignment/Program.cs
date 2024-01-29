using S10241539_PRG2Assignment;
using System.Diagnostics.Tracing;
using System.Globalization;

Queue<Order> NormalOrders = new Queue<Order>();
Queue<Order> GoldOrders = new Queue<Order>();
List<Customer> customerList = new List<Customer>(); //Initializing list of customers

// Method to print the Menu and obtain a user defined option. This makes calling the Menu out again easier
string DisplayOutput()
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
    string option = Console.ReadLine();
    
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

void ListAllOrders()
{
    if (GoldOrders.Count == 0) 
    {
        Console.WriteLine("No orders in gold queue.");
    }
    else
    {
        foreach (Order o in GoldOrders)
        {
            Console.WriteLine($"Gold Members\n{o.ToString()}\n");
        }
    }
    if (NormalOrders.Count == 0)
    {
        Console.WriteLine("No orders in normal queue.");
    }
    else
    {
        foreach (Order o in NormalOrders)
        {
            Console.WriteLine($"Normal Members\n{o.ToString()}\n");
        }
    }
}

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

void ModifyOrderDetails()
{
    DisplayCustomerInformation();
    Console.Write("Select a Customer");
    int search = Convert.ToInt32(Console.ReadLine());
}

/*
list the customers
 prompt user to select a customer and retrieve the selected customer’s current order
 list all the ice cream objects contained in the order
 prompt the user to either [1] choose an existing ice cream object to modify, [2] add an 
entirely new ice cream object to the order, or [3] choose an existing ice cream object to 
delete from the order
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
while (true)
{
    // Initialise "customerList" for later use by program.
    InitialiseCustomerList(customerList);
    // Display the main menu to show options.
    string userOption = DisplayOutput();

    // Checks if integer '1' is entered. 
    if (userOption == "1")
    {
        // If it is, it will invoke DisplayCustomerInformation function and displays detailed customer information.
        DisplayCustomerInformation();
    }
    else if (userOption == "2")
    {
        // If it is, it will invoke ListAllOrder function and displays detailed order information from both the Gold queue and the Normal Queue.
        ListAllOrders();
    }
    else if (userOption == "3")
    {

    }
    else if (userOption == "4")
    {

    }
    else if (userOption == "5")
    {
        // If it is, it will invoke DisplayCustomerInformation function and displays detailed customer information.
        DisplayOrderDetails();
    }
    else if (userOption == "6")
    {
        ModifyOrderDetails();
    }
    // Checks if integer '0' is entered.
    else if (userOption == "0")
    {
        // If it is, it exits the loop, and program will stop.
        break;
    }
    else 
    {
        Console.WriteLine("Please enter a valid option number.");
    }
}