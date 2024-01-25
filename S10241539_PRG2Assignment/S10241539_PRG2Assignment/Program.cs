using S10241539_PRG2Assignment;
using System.Diagnostics.Tracing;
using System.Globalization;


List<Customer> customerList = new List<Customer>(); //Initializing list of customers

// Method to print the Menu and obtain a user defined option. This makes calling the Menu out again easier
int DisplayOutput()
{
    // Dislays the options.
    Console.WriteLine("Menu");
    Console.WriteLine("----");
    Console.Write(
        "[1] Display All Customers\n" +
        "[2] List All Current Orders\n" +
        "[3] Register a New Customer\n" +
        "[4] Create a Customer's Order\n" +
        "[5] Display Order Details of a Customer\n" +
        "[6] Modify Order Details\n" +
        "[0] Exit\n----\n"
    );

    // Prints a new line for ease of viewing.
    Console.WriteLine();

    // Prompt the user to enter option.
    Console.Write("Please Enter Your Option: ");

    // Convert input to integer (as the default type is string).
    int option = Convert.ToInt32(Console.ReadLine());

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

void Option2()
{
    for (int i = 0; i < customerList.Count; i++)
    {
        List<Order> orderHistory = customerList[i].OrderHistory;
        DateTime timeFulfilled = DateTime.Now;
        Console.WriteLine($"Order ID: {orderHistory[i].Id}\nTime Order Recieved: {orderHistory[i].TimeReceived.ToLongTimeString}\n Order Fulfilled: {timeFulfilled.ToLongTimeString()}");
    }
}

// Main Program
// Other features yet to be implemented.
// While loop to invoke user input infinitely.
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
    // Checks if integer '0' is entered.
    else if (userOption == 0)
    {
        // If it is, it exits the loop, and program will stop.
        break;
    }
}