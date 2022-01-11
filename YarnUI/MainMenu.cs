using System.Text.RegularExpressions;
using CustomExceptions;

namespace UI;

public class MainMenu : IMenu
{

    private IBL _bl;

    public MainMenu(IBL bl)
    {
        _bl = bl;
    }
    public void Start ()
    {
        bool exit = false;

        while(!exit)
        {
            Console.WriteLine("Welcome to Cynthia's Yarn Festival!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("~If you are a new customer, to sign up enter [1]~");
            Console.WriteLine("~If you are a returning customer, to sign in enter [2]~");
            Console.WriteLine("~Manager please press [3]~");
            Console.WriteLine("~To leave, enter [x]~");
            string input = Console.ReadLine() ?? "";

            string? password, email, managerName, managerName1; int managerID, id; 
            managerID = 12334;
            managerName = "Zoella";
            Customer CurrentCustomer = new Customer();

            if(!string.IsNullOrWhiteSpace(input))
            {
                switch(input)
                {
                    case "1":
                        Console.WriteLine("Please enter your name: ");
                        string name = Console.ReadLine() ?? "";
                        Console.WriteLine("Please enter your email: ");
                        email = Console.ReadLine();
                        Console.WriteLine("Please enter a password: ");
                        password = Console.ReadLine();

                        try
                        {
                            _bl.GetAllCustomers();
                            Random ran = new Random();
                            id = ran.Next(100000);
                            Customer newCustomer = new Customer {
                                ID = id,
                                Name = name,
                                Email = email,
                                Password = password,
                            };

                            _bl.AddCustomer(newCustomer);
                            CurrentCustomer = newCustomer;

                            Console.WriteLine("You've successfully signed up!");

                            CustomerStoreMenu menu = (CustomerStoreMenu) MenuFactory.GetMenu("customerstore");
                            menu.CurrentCustomer = CurrentCustomer;
                            menu.Start();
                        }
                        catch(InputInvalidException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Log.Error(ex.Message);
                        }
            
                    break;
                    case "2":
                        MenuFactory.GetMenu("login").Start();
                    break;
                    case "3":
                        Console.WriteLine("Please enter your name: ");
                        managerName1 = Console.ReadLine();
                        Console.WriteLine("Please enter your manager code: ");
                        string? managerid1 = Console.ReadLine();
                        int managerID1;
                        bool parseSuccess = Int32.TryParse(managerid1, out managerID1);

                        if(managerName == managerName1 && managerID == managerID1)
                        {
                            Console.WriteLine(" \nWelcome back Zoella");

                            MenuFactory.GetMenu("manager").Start();
                        }
                        else
                        {
                            Console.WriteLine("Sorry you entered the wrong name or code, please try again.");
                        }
                    break;
                    case "x":
                        exit = true;
                        Console.WriteLine("Thank you for visiting CYF today!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Please enter valid input");
            }
        }

    }
}
