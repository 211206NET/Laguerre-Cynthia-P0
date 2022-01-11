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
        List<Order> allOrders = CurrentCustomer.Orders!;

        bool exit = false;

        while(!exit)
        {
            if(allOrders.Count == 0)
            {
                Console.WriteLine("There are no orders available");
            }
            else
            {
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
                        foreach(Order order in allOrders)
                        {
                            Console.WriteLine($"{order.ToString()}");
                            Console.WriteLine("-----------Orders------------");
                            foreach(LineItem item in order.LineItems!)
                            {
                                Console.WriteLine($"{item.ToString()}");
                            }
                        }
                        
                    break;

                    case "2":
                        Console.WriteLine(" for older orders to newer orders");
                    break;

                    case "3":
                        Console.WriteLine(" for least expensive orders to most expensive orders");
                    break;

                    case "4":
                        Console.WriteLine(" for most expensive to least expensive orders");
                    break;

                    case "x":
                        exit = true;
                    break;
                }
            }

        }

    }
}