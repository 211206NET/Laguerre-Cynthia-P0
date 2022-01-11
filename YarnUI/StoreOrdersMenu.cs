namespace UI;

public class StoreOrdersMenu : IMenu
{
    private IBL _bl;

    public StoreOrdersMenu(IBL bl)
    {
        _bl = bl;
    }

    public void Start()
    {
        Console.WriteLine(" ");
        Console.WriteLine("How would you like to view the Store's orders?");
        Console.WriteLine("Enter [1] for newer orders to older orders");
        Console.WriteLine("Enter [2] for older orders to newer orders");
        Console.WriteLine("Enter [3] for least expensive orders to most expensive orders");
        Console.WriteLine("Enter [4] for most expensive orders orders to least expensive orders");
        Console.WriteLine("Enter [x] to return to Manager Menu");

        bool exit = false;

        while(!exit)
        {

        Console.WriteLine(" ");
        Console.WriteLine("How would you like to view the Store's orders?");
        Console.WriteLine("Enter [1] for newer orders to older orders");
        Console.WriteLine("Enter [2] for older orders to newer orders");
        Console.WriteLine("Enter [3] for least expensive orders to most expensive orders");
        Console.WriteLine("Enter [4] for most expensive orders orders to least expensive orders");
        Console.WriteLine("Enter [x] to return to Manager Menu");

        string? input = Console.ReadLine();

        //select store then 
        // List<StoreOrder> allOrders = store.AllOrders;
        //if there are no orders state that
        //allStoreOrder.Sort

        switch(input)
        {
            case "1":
                Console.WriteLine("for newer orders to older orders");
                
            break;

            case "2":
                Console.WriteLine("for older orders to newer orders");
            break;

            case "3":
                Console.WriteLine("for least expensive orders to most expensive orders");
            break;

            case "4":
                Console.WriteLine("for most expensive orders orders to least expensive orders");
            break;

            case "x":
                exit = true;
            break;

            default:
                Console.WriteLine("Im sorry I don't understand what that means. Please try again");
            break;
        }
        }

    }
}