namespace UI;

public class CustomerMenu : IMenu
    {
        internal StoreFront CurrentStore { get; set; }
        internal Customer CurrentCustomer { get; set; }

        private IBL _bl;
        public CustomerMenu(IBL bl)
        {
            _bl = bl;
        }
    public void Start()
    {
                Console.WriteLine("\nThis is the Customer Main Menu");
        bool leave = false;

        while(!leave)
        {
            List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
            List<Customer> allCustomers = _bl.GetAllCustomers();
            //List<Inventory> allInventories = _bl.GetAllInventories();
            List<LineItem> allLineItems = _bl.GetAllLineItems();
            //List<Order> currOrder = new List<Order>();
            List<LineItem> shoppingCart = new List<LineItem>();
            List<Order> storeOrders = CurrentCustomer.Orders!;
            List<Order> CustOrders = CurrentCustomer.Orders!;
            List<Inventory> allInventories = CurrentStore.Inventories!;

            //Console.WriteLine($"{CurrentStore.Name}");
            //Console.WriteLine($"{CurrentCustomer.Name}");

                Console.WriteLine("How can I assist you today?!");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Enter [1] if you want to purchase from our collection");
                Console.WriteLine("Enter [x], if you want to return to the Main Menu");

                string? input = Console.ReadLine();

                switch(input)
                {
                    case "1":

                    // Order newOrder = new Order();
                    // Random ran = new Random();
                    // int id = ran.Next(100000);
                    // newOrder.ID = id;
                    // newOrder.OrderDate = DateTime.Now;
                    
                    bool checkOut = false; 

                    while(!checkOut)
                    {

                        int i = 0;
                        foreach(Inventory invent in allInventories)
                        {
                            Console.WriteLine($"\n[{i}] Product: {invent.ProductColor} {invent.ProductName}  \nDescription {invent.ProductDescription} \nPrice: {invent.ProductPrice} Quantity: {invent.Quantity}");
                            i++;
                        }
                        string? selection1 = Console.ReadLine();
                        int selectedprod;
                        Boolean selectionparse = Int32.TryParse(selection1, out selectedprod);
                        if(selectedprod < 0 || selectedprod > allInventories.Count)
                        {
                            Console.WriteLine("Please pick a number within the range");
                        }
                        else
                        {
                        // Inventory ProdAdded = new Inventory();
                        LineItem prelimCart = new LineItem();

                        prelimCart.ProductName = allInventories[selectedprod].ProductName;
                        prelimCart.ProductPrice = allInventories[selectedprod].ProductPrice;
                        prelimCart.ProductColor = allInventories[selectedprod].ProductColor;
                        prelimCart.ProductID = allInventories[selectedprod].ProductID;

                        Console.WriteLine($"Youve choosen {prelimCart.ProductColor} {prelimCart.ProductName} at the price of ${prelimCart.ProductPrice}. ");
                        Console.WriteLine($"How many {prelimCart.ProductColor} {prelimCart.ProductName} do you wish to add?");
                        string? selection2 = Console.ReadLine();
                        int quantityToAdd; 
                        Boolean selectionparse2 = Int32.TryParse(selection2, out quantityToAdd);
                        Console.WriteLine($"You've added {quantityToAdd} of {prelimCart.ProductColor} {prelimCart.ProductName}");

                        prelimCart.Quantity = quantityToAdd;
                        prelimCart.OrderID = 0;
                        Random cartran = new Random();
                        int cartid = cartran.Next(10000);
                        prelimCart.ID = cartid; 
                        prelimCart.InventoryID = allInventories[selectedprod].ID;
                        decimal totalProdPrice = (allInventories[selectedprod].ProductPrice)*(prelimCart.Quantity);
                        Console.WriteLine($"Cart: \nBaricode: {prelimCart.ID} Product: {prelimCart.ProductColor} {prelimCart.ProductName} qty: {prelimCart.Quantity} product total: {totalProdPrice}");
                        shoppingCart.Add(prelimCart);
                        _bl.AddLineItem(prelimCart);

                        foreach(LineItem item in shoppingCart)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("Would you like to add more to your order? Enter yes. If you want to check out enter no.");
                        string? moreToCart = Console.ReadLine();
                        if(moreToCart == "no")
                            {
                                Order newOrder = new Order();
                                Random ran = new Random();
                                int id = ran.Next(100000);
                                newOrder.ID = id;
                                newOrder.OrderDate = DateTime.Now;
                                Console.WriteLine($"{newOrder.OrderDate}");
                                foreach(LineItem item in shoppingCart)
                                {
                                    _bl.EditLineItem(item.ID, newOrder.ID);
                                }

                                newOrder.LineItems = shoppingCart;
                                
                                newOrder.Total = newOrder.CalculateTotal();
                                Console.WriteLine($"You're total is {newOrder.Total}");
                                //newOrder.OrderDate = DateTime.Now;
                                newOrder.CustomerID = CurrentCustomer.ID;
                                newOrder.StoreFrontID = CurrentStore.ID;
                                CurrentStore.Orders!.Add(newOrder);
                                CurrentCustomer.Orders!.Add(newOrder);
                                _bl.AddOrder(newOrder);
                                checkOut = true;
                            }

                        //CurrentCustomer.Orders = currOrder;
                        
                        }
                    }
                    
                    
                    break;

                    case "x":
                        leave = true;
                    break;

                }
        }    
    }
}
    

        

