namespace UI;

public class LoginMenu : IMenu
{
    private IBL _bl;

    public LoginMenu(IBL bl)
    {
        _bl = bl;
    }

    public void Start()
    {

        List<Customer> allCustomers = _bl.GetAllCustomers();
        Customer CurrentCustomer = new Customer();

        if(allCustomers.Count == 0)
        {
            Console.WriteLine(" \n There are no Customers found");
        }
        else
        {
            Console.WriteLine("Please enter your email: ");
            string? email = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string? password = Console.ReadLine();

            foreach(Customer custs in _bl.GetAllCustomers())
            {
                if(email == custs.Email && password == custs.Password)
                {
                    Console.WriteLine(" \n Login successful!");
                    Console.WriteLine(" ");

                    CurrentCustomer = custs;

                    CustomerStoreMenu menu = (CustomerStoreMenu) MenuFactory.GetMenu("customerstore");
                    menu.CurrentCustomer = CurrentCustomer;
                    menu.Start();
                }
                else if(email != custs.Email || password != custs.Password)
                {
                    Console.WriteLine(" \n Either your email or password is wrong, please try again!");
                }
            }
            
        }
    }
}