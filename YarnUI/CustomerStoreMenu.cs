namespace UI;

public class CustomerStoreMenu : IMenu
{
    internal Customer CurrentCustomer { get; set; }

    private IBL _bl;

    public CustomerStoreMenu(IBL bl)
    {
            _bl = bl;
    }
    
    public void Start()
    {
        //To select a restaurant
        bool exit = false;
        List<Customer> allCustomers = _bl.GetAllCustomers();
        List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();

        while(!exit)
        {
            Console.WriteLine("\nWhat is the purpose of your visit?");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter [1] to browse CYF's collection");
            Console.WriteLine("Enter [2] if you would like to view existing orders");
            Console.WriteLine("Enter [r] to return to the main menu");
            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.WriteLine(" Please select a store");
                    if(allStoreFronts.Count == 0)
                    {
                        Console.WriteLine("Sorry! There are no CYF stores available");

                    }
                    else if(allStoreFronts.Count > 0)
                    {
                        for(int i = 0; i < allStoreFronts.Count; i++)
                        {
                            Console.WriteLine($"[{i}] Name: {allStoreFronts[i].Name} Address: {allStoreFronts[i].Address} City: {allStoreFronts[i].City} State: {allStoreFronts[i].State} ");
                        }
                        string? selection1 = Console.ReadLine(); 
                        int selection;
                        Boolean selectionparse = Int32.TryParse(selection1, out selection);
                        StoreFront selectedStoreFront = allStoreFronts[selection];

                        Console.WriteLine($"Thank you for choosing {selectedStoreFront.Name}");
                        CustomerMenu menu = (CustomerMenu) MenuFactory.GetMenu("customer");
                        menu.CurrentStore = selectedStoreFront;
                        menu.CurrentCustomer = CurrentCustomer; 
                        menu.Start();
                    }
                break;

                case "2":
                //From here they will got to CustomerOrders
                    try{
                        if(CurrentCustomer.Orders!.Count == 0 || CurrentCustomer.Orders == null)
                            {
                                Console.WriteLine($"Sorry! There are no orders for {CurrentCustomer.Name} available");

                            }
                            else if(CurrentCustomer.Orders.Count > 0)
                            {
                                CustomerOrdersMenu menu = (CustomerOrdersMenu) MenuFactory.GetMenu("customerorder");
                                // menu.CurrentStore = selectedStoreFront;
                                menu.CurrentCustomer = CurrentCustomer; 
                                menu.Start();
                                MenuFactory.GetMenu("customerorder").Start();
                            }
                    }
                    catch(NullReferenceException nullReferenceException)
                    {
                        Console.WriteLine($"Error: {nullReferenceException}");
                    }

                    break;

                case "r":
                    exit = true;
                break;

                default:
                break;
            }
        }
    }
}
