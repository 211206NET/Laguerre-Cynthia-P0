using System.Linq;
using System.Collections.Generic;

namespace UI;

public class CustomerOrdersMenu : IMenu
{

    internal Customer CurrentCustomer { get; set; }
    private IBL _bl;

        public CustomerOrdersMenu(IBL bl)
        {
            _bl = bl;
        }
    public void Start(){
        _bl.GetAllOrders();
        _bl.GetAllLineItems();
        List<Order> allOrders = CurrentCustomer.Orders!;
        //List<Order> allOrders = _bl.GetAllOrders();


        bool exit = false;

        while(!exit)
        {
            if(allOrders.Count == 0)
            {
                Console.WriteLine("There are no orders available");
            }
            else
            {
                foreach(Order order in allOrders)
                {
                    Console.WriteLine($"{order.OrderDate} ");
                    Console.WriteLine($"{order.ID}");
                    foreach(LineItem item in order.LineItems!)
                    {
                        Console.WriteLine($"Name {item.ProductName} Price: {item.ProductPrice} Quantity: {item.Quantity}");
                    }
                    Console.WriteLine($"{order.Total}");
                    Console.WriteLine("-----------------------");
                }
                Console.WriteLine(" ");
                Console.WriteLine("How would you like to view the your's orders?");
                Console.WriteLine("Enter [1] for newer orders to older orders");
                Console.WriteLine("Enter [2] for older orders to newer orders");
                Console.WriteLine("Enter [3] for least expensive orders to most expensive orders");
                Console.WriteLine("Enter [4] for most expensive orders orders to least expensive orders");
                Console.WriteLine("Enter [x] to return to the Customer Menu");
                
                string? input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        Console.WriteLine("\nHere are all your Orders");
                        allOrders.Sort((x, y) => y.OrderDate.CompareTo(x.OrderDate));

                    break;

                    case "2":
                        Console.WriteLine(" for older orders to newer orders");
                        allOrders.Sort((x, y) => x.OrderDate.CompareTo(y.OrderDate));
                    break;

                    case "3":
                        Console.WriteLine(" for least expensive orders to most expensive orders");

                        allOrders.Sort((x, y) => x.Total.CompareTo(y.Total));
                    break;

                    case "4":
                        Console.WriteLine(" for most expensive to least expensive orders");
                        allOrders.Sort((x, y) => y.Total.CompareTo(x.Total));
                    break;

                    case "x":
                        exit = true;
                    break;

                    default:
                        Console.WriteLine("Im sorry that input is not valid");
                    break;
                }
            }

        }

    }
}