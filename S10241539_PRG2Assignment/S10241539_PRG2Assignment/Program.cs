using S10241539_PRG2Assignment;


List<Customer> customerList = new List<Customer>(); //Initializing list of customers

int DisplayOutput() // Method to print the Menu and obtain a user defined option. This makes calling the Menu out again easier
{
    Console.WriteLine(" Menu\n----\n" +
        "[1] Display All Customers\n" +
        "[2] List All Current Orders\n" +
        "[3] Register a New Customer\n" +
        "[4] Create a Customer's Order\n" +
        "[5] Display Order Details of a Customer\n" +
        "[6] Modify Order Details\n" +
        "[0] Exit\n----\n");
    Console.Write("Please Enter Your Option: \n");
    int option = Convert.ToInt32(Console.ReadLine());
    return option;
}

void Option1(List<Customer> cs) //method to implement 
{
    foreach(Customer customer in cs)
    {
        Console.WriteLine(customer.ToString() + "\n");
    }
}
