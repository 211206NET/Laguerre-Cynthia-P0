using DL;

namespace UI;

public static class MenuFactory
{
    public static IMenu GetMenu(string menuString)
    {
        menuString = menuString.ToLower();

        string connectionString = File.ReadAllText("connectionString.txt");
        IRepo repo = new DBRepo(connectionString);
        //IRepo repo = new FileRepo();
        IBL bl = new CYFBL(repo);
        
        switch(menuString)
        {
            case "main":
                return new MainMenu(bl);

            case "customerorder":
                return new CustomerOrdersMenu(bl);

            case "customer":
            return new CustomerMenu(bl);

            case "customerstore":
                return new CustomerStoreMenu(bl);

            case "inventory":
                return new InventoryMenu(bl);

            case "manager":
                return new ManagerMenu(bl);

            //case "shoppingcart":
                //return new ShoppingCartMenu(bl);

            case "storeorder":
                return new StoreOrdersMenu(bl);

            case "mainy":
                return new MainMenu(bl);

            case "login":
                return new LoginMenu(bl);

            default:
            return new MainMenu(bl);
        }
    }
}
