namespace UI;

public class InventoryMenu : IMenu
{
    internal StoreFront CurrentStore { get; set; }
    //internal Customer CurrentCustomer { get; set; }

    private IBL _bl;
    public InventoryMenu(IBL bl)
        {
            _bl = bl;
        }
    //Since it depends on the store its gonna need _bl for store and products

    //public void Start (int storeID)
    public void Start ()
    {
        bool going = false;
        //List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
        List<Inventory> allInventories = CurrentStore.Inventories!;
        //CurrentStore.Inventories = List<Inventory> allInventories;
        //List<Inventory> allInventories = _bl.GetAllInventories();
        List<Product> allProducts = _bl.GetAllProducts();
        List<Inventory> newInventory = new List<Inventory>();
        

        while(!going)
        {

        //int storeID = (int)allStoreFronts[selection].ID;
        

        Console.WriteLine("\nWelcome to Inventory Menu \n---------------------------");
        Console.WriteLine("Enter [1] to add a new product to the store");
        Console.WriteLine("Enter [2] to view Store's inventory");
        Console.WriteLine("Enter [3] to update Store's inventory quantities");
        Console.WriteLine("Enter [x] to return to Manager's Menu");
        
        string? input = Console.ReadLine();

        decimal price;
        int id, quantity;
        
            switch(input)
            {
                case "1":

                    Product newProduct = new Product();

                    Console.WriteLine($"What item to do you add to {CurrentStore.Name}");
                    string? productName = Console.ReadLine();
                    newProduct.ProductName = productName ?? "";
                    Console.WriteLine($"Please enter {productName}'s color");
                    string? color = Console.ReadLine();
                    newProduct.Color = color;
                    Console.WriteLine($"Please enter {productName}'s description");
                    string? description = Console.ReadLine();
                    newProduct.Description = description ?? "";
                    Console.WriteLine($"Please enter {productName}'s price");
                    // price = decimal.Parse(Console.ReadLine());
                    string? price1 = Console.ReadLine();
                    bool priceparse = decimal.TryParse(price1, out price);
                    newProduct.Price = price;
                    Random ran = new Random();
                    id = ran.Next(100000);
                    newProduct.ID =id;
                    _bl.AddProduct(newProduct);

                    Inventory newItem = new Inventory();
                    newItem.ID = id+1;

                    Console.WriteLine($"Enter the quantity of {newProduct.ProductName} you want to add");
                    string? quantity1 = Console.ReadLine();
                    Boolean quanityparse = Int32.TryParse(quantity1, out quantity);
                    newItem.Quantity = quantity;
                    newItem.StoreFrontID = CurrentStore.ID;
                    newItem.ProductID = newProduct.ID;
                    newItem.ProductName = newProduct.ProductName;
                    newItem.ProductPrice = newProduct.Price;
                    newItem.ProductDescription = newProduct.Description;
                    newItem.ProductColor = newProduct.Color;
                    
                    CurrentStore.Inventories!.Add(newItem);
                    _bl.AddInventory(newItem);

                    Console.WriteLine($"{newItem.ProductPrice}");

                    foreach (Inventory invent in  allInventories)
                    {
                        Console.WriteLine($"\n Product ID: {invent.ProductID}  Name: {invent.ProductColor} {invent.ProductName} Price: {invent.ProductPrice} Quantity: {invent.Quantity} \n----------------------------");
                    }


                break;

                case "2":
                    Console.WriteLine("View all inventories");
                    _bl.GetAllInventories();
                    
                    if(allInventories.Count == 0)
                    {
                        Console.WriteLine("Sorry this store has no inventory");
                    }
                    else
                    {
                        foreach (Inventory invent in  allInventories!)
                        {
                        Console.WriteLine($"\n{invent.ToString()}\n-----------------");
                        }   
                    }

                break;

                case "3":
                    
                    //do logging here
                    
                    try{
                        for(int i = 0; i < allInventories.Count; i++)
                        {
                            Console.WriteLine("Select a product");
                            Console.WriteLine($"[{i}] {allInventories[i].ToString()}");
                            
                        }
                        }
                    catch(IndexOutOfRangeException ex)
                    {
                        Log.Information("Going outside the selection range");
                        Console.WriteLine(ex.Message);
                        Log.Error(ex.Message);
                        goto case "3";
                        
                    }
                        
                        string? selection1 = Console.ReadLine();
                        int selection;
                        Boolean selectionparse = Int32.TryParse(selection1, out selection);
                        int inventoryID = (int) allInventories[selection].ID;
                        Console.WriteLine($"Youve choosen {allInventories[selection].ProductName}");
                        Console.WriteLine($"How many {allInventories[selection].ProductName} do you want in total?");
                        string? selection2 = Console.ReadLine();
                        int addQuantity; 
                        Boolean selectionparse2 = Int32.TryParse(selection2, out addQuantity);
                        _bl.AddMoreInventory(inventoryID, addQuantity);
                        _bl.GetAllInventories();
                        Console.WriteLine($"The new quantity of {allInventories[selection].ProductColor} {allInventories[selection].ProductName} is {addQuantity}");
                        
                        
                break;
                case "x":
                going = true;
                break;
            }
        
        
        }

    }
}