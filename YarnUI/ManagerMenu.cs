namespace UI;

public class ManagerMenu : IMenu
{
        private IBL _bl;

        public ManagerMenu(IBL bl)
        {
                _bl = bl;
        }


        public void Start()
        {
                List<Inventory> allInventories = _bl.GetAllInventories();
                List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
                Console.WriteLine("");
                Console.WriteLine("This is the Manager's Menu");
                bool exit = false;

                while(!exit)
                {
                        Console.WriteLine("How can I assist you today?!");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("~Enter [1] if you want to open a new location for CYF~");
                        Console.WriteLine("~Enter [2] if you want to review existing CYF stores~");
                        Console.WriteLine("~Enter [3] to view inventory of all stores~");
                        Console.WriteLine("~Enter [4] if you want update a store's inventory");
                        Console.WriteLine("~Enter [5] if you want to view a store's orders~");
                        Console.WriteLine("~Enter [return], if you want to return to the Main Menu~");
                        
                        string? name, address, city, state;
                        int id;
                        string? input = Console.ReadLine();
                
                        switch(input)
                        {
                                case "1":
                                Console.WriteLine("Please enter the store's name: ");
                                name = Console.ReadLine();
                                Console.WriteLine("Please enter the store's address: ");
                                address = Console.ReadLine();
                                Console.WriteLine("Please enter the store's city: ");
                                city = Console.ReadLine();
                                Console.WriteLine("Please enter the store's state: ");
                                state = Console.ReadLine();

                                Random ran = new Random();
                                id = ran.Next(100000);

                                StoreFront newStore = new StoreFront
                                {
                                        ID = id,
                                        Name = name,
                                        Address = address,
                                        City = city,
                                        State = state,
                                };

                                _bl.AddStoreFront(newStore);

                                Console.WriteLine($"You've successfully added {newStore.Name}'s store!");

                                break;

                                case "2":
                                _bl.GetAllStoreFronts();
                                if(allStoreFronts.Count == 0)
                                {
                                        Console.WriteLine("Im sorry there are no stores available");
                                }
                                else
                                {
                                        foreach(StoreFront stores in _bl.GetAllStoreFronts())
                                        {       
                                                Console.WriteLine(" \n -----------------------");
                                                Console.WriteLine($"Store ID: {stores.ID} \nName: {stores.Name} \nAddress: {stores.Address} \nCity: {stores.City} \nState: {stores.State}");
                                                Console.WriteLine("-----------------------");
                                                Console.WriteLine(" ");

                                        } 

                                }
                                break;

                                case "3":
                                allStoreFronts = _bl.GetAllStoreFronts();
                                if(allStoreFronts.Count == 0)
                                {
                                        Console.WriteLine("\nThere are no StoreFronts");
                                }
                                else{
                                        Console.WriteLine("\nHere are the inventories for the CYF Storefronts \n");
                                        foreach(StoreFront stores in allStoreFronts)
                                        {
                                                Console.WriteLine(stores.ToString());
                                                if(stores.Inventories != null && stores.Inventories.Count > 0)
                                                {
                                                        Console.WriteLine("------------Inventory---------");
                                                        foreach(Inventory invent in stores.Inventories)
                                                        {
                                                                Console.WriteLine($"\n{invent.ToString()} \n");
                                                        }
                                                }
                                                else
                                                {
                                                        Console.WriteLine("\nThis store has no inventory \n");
                                                }
                                        }
                                }
                                break;

                                case "4":
                                        Console.WriteLine(" Please Select a StoreFront");
                                        _bl.GetAllStoreFronts();
                                        if(allStoreFronts.Count == 0)
                                        {
                                                Console.WriteLine($"Sorry! There are no CYF stores available \n----------------------------");
                                        }
                                        else if(allStoreFronts.Count > 0)
                                        {
                                                for(int i = 0; i < allStoreFronts.Count; i++)
                                                {
                                                Console.WriteLine($"[{i}] Name: {allStoreFronts[i].Name} Address: {allStoreFronts[i].Address}  City: {allStoreFronts[i].City}  State: {allStoreFronts[i].State}");
                                                }
                                                string? selection1 = Console.ReadLine();
                                                int selection;
                                                Boolean selectionparse = Int32.TryParse(selection1, out selection);
                                                StoreFront selectedStoreFront = allStoreFronts[selection];
                                                int storeID = (int) allStoreFronts[selection].ID;
                                                Console.WriteLine($"You've choosen {selectedStoreFront.Name}");
                                                
                                                InventoryMenu menu = (InventoryMenu) MenuFactory.GetMenu("inventory");
                                                menu.CurrentStore = selectedStoreFront;
                                                // menu.CurrentCustomer = currentCustomer; 
                                                menu.Start();
                                        }
                                break;

                                case "5":
                                        Console.WriteLine("Please select a StoreFront");
                                        if(allStoreFronts.Count > 0)
                                        {
                                                for(int i = 0; i < allStoreFronts.Count; i++)
                                                {
                                                        Console.WriteLine($"[{i}] Store ID: {allStoreFronts[i].ID} Name: {allStoreFronts[i].Name} Address: {allStoreFronts[i].Address} City: {allStoreFronts[i].City} State: {allStoreFronts[i].State} ");
                                                }
                                                string? selection1 = Console.ReadLine();
                                                int selection;
                                                Boolean selectionparse = Int32.TryParse(selection1, out selection);
                                                StoreFront selectedStoreFront = allStoreFronts[selection];
                                                Console.WriteLine($"You've choosen {selectedStoreFront.Name}");
                                                MenuFactory.GetMenu("storeorder").Start();
                                                
                                        }
                                break;

                                case "return":
                                        exit = true;
                                break;

                                default:
                                break;
                        }
                }
        }
}