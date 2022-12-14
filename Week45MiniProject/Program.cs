
using System.Text.RegularExpressions;

string mainMenuOption = "";
bool showMainMenuAgain = true;
string option = "";
bool showAssetMenuAgain = true;

// Some assets to the list
Assets p1 = new Phone("Phone", "Iphone", "8", "Spain", "12/29/2018", 970, "EUR", 801.65);
Assets c1 = new Computer("Computer", "HP", "Elitebook", "Spain", "06/01/2019", 1423, "EUR", 1176.03);
Assets p2 = new Phone("Phone", "Iphone", "11", "USA", "09/25/2020", 990, "USD", 990);
Assets p3 = new Phone("Phone", "Iphone", "X", "Sweden", "07/15/2018", 1245, "SEK", 10375);

// Create the list
List<Assets> assets = new List<Assets>();
assets.Add(p1);
assets.Add(c1);
assets.Add(p2);
assets.Add(p3);


// Main menu 
void ShowMainMenu()
{
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Asset Tracking Menu");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("To Add a New Asset - enter \"N\"");
    Console.WriteLine("To See Asset List Sorted By Type - enter \"T\"");
    Console.WriteLine("To See Asset List Sorted By Office - enter \"O\"");
    Console.WriteLine("To Exit - enter \"Q\"");
    mainMenuOption = Console.ReadLine();
}

// Asset menu
void ShowAddAssetMenu()
{
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Add New Asset");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Select Type: \"P\" for Phone, \"C\" for Computer or \"Q\" to Exit");
    option = Console.ReadLine();
}

// Add New Phone to List
void CreateNewPhone()
{
    string type = "Phone";

    Console.WriteLine("Enter Phone Brand:");
    string brand = Console.ReadLine();

    Console.WriteLine("Enter Phone Model:");
    string model = Console.ReadLine();

    Console.WriteLine("Enter Purchase Date (MM/DD/YYYY):");
    string purchaseDate = Console.ReadLine();
    Regex dateFormat = new Regex(@"((([0][1-9])|([1][0-2]))\/(([0-2][0-9])|([3][0-1]))\/([1-2][0,1,9][0-9][0-9]))$");
    if (!dateFormat.IsMatch(purchaseDate))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wrong Date Format");
        Console.ResetColor();
        AddNewAsset();
    }

    Console.WriteLine("Enter Price in USD:");
    double price = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("In which office is the phone in?");
    Console.WriteLine("Enter \"Sw\" for Sweden, \"Sp\" for Spain or \"U\" for USA" );
    double localPrice = 0;
    string currency = "";
    string office = Console.ReadLine();
        if (office.ToLower().Trim() == "sw")
        {
            office = "Sweden";
            currency = "SEK";
            localPrice = price * 10.89;
        }
        else if (office.ToLower().Trim() == "sp")
        {
            office = "Spain";
            currency = "EUR";
            localPrice = price * 0.99;
        }
        else if (office.ToLower().Trim() == "u")
        {
            office = "USA";
            currency = "USD";
            localPrice = price;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not a valid office");
            Console.ResetColor();
            AddNewAsset();
        }

    assets.Add(new Phone(type, brand, model, office, purchaseDate, price, currency, localPrice));

    ShowAddAssetMenu();
}

// Add New Computer to List
void CreateNewComputer()
{
    string type = "Computer";

    Console.WriteLine("Enter Computer Brand:");
    string brand = Console.ReadLine();

    Console.WriteLine("Enter Computer Model:");
    string model = Console.ReadLine();

    Console.WriteLine("Enter Purchase Date (MM/DD/YYYY):");
    string purchaseDate = Console.ReadLine();
    Regex dateFormat = new Regex(@"((([0][1-9])|([1][0-2]))\/(([0-2][0-9])|([3][0-1]))\/([1-2][0,1,9][0-9][0-9]))$");
    if (!dateFormat.IsMatch(purchaseDate))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wrong Date Format");
        Console.ResetColor();
        AddNewAsset();
    }

    Console.WriteLine("Enter Price in USD:");
    double price = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("In which Office is the Computer in?");
    Console.WriteLine("Enter \"Sw\" for Sweden, \"Sp\" for Spain or \"U\" for USA");
    double localPrice = 0;
    string currency = "";
    string office = Console.ReadLine();
    if (office.ToLower().Trim() == "sw")
    {
        office = "Sweden";
        currency = "SEK";
        localPrice = price * 10.89;
    }
    else if (office.ToLower().Trim() == "sp")
    {
        office = "Spain";
        currency = "EUR";
        localPrice = price * 0.99;
    }
    else if (office.ToLower().Trim() == "u")
    {
        office = "USA";
        currency = "USD";
        localPrice = price;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Not a valid office");
        Console.ResetColor();
        AddNewAsset();
    }

    assets.Add(new Computer(type, brand, model, office, purchaseDate, price, currency, localPrice));

    ShowAddAssetMenu();
}

// List Sorted by Office
void ShowListByOffice()
{
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");
    Console.WriteLine("----".PadRight(15) + "-----".PadRight(15) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(15) + "------------".PadRight(15) + "--------".PadRight(15) + "-----------------");

    List<Assets> sortedByOffice = assets.OrderBy(asset => asset.Office).ThenBy(asset => Convert.ToDateTime(asset.PurchaseDate)).ToList();

    foreach (Assets asset in sortedByOffice)
    {
        DateTime today = DateTime.Now;
        DateTime pDate = Convert.ToDateTime(asset.PurchaseDate);
        TimeSpan diff = today - pDate;
        double years = diff.Days / 365.25;

        if (years >= 3.75)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);
            Console.ResetColor();
        }
        else if (years >= 3.5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);
        }
    }

    ShowMainMenu();
}

// List Sorted by Type
void ShowListByType()
{
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");
    Console.WriteLine("----".PadRight(15) + "-----".PadRight(15) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(15) + "------------".PadRight(15) + "--------".PadRight(15) + "-----------------");

    List<Assets> sortedByType = assets.OrderBy(asset => asset.Type).ThenBy(asset => Convert.ToDateTime(asset.PurchaseDate)).ToList();

    foreach (Assets asset in sortedByType)
    {
        DateTime today = DateTime.Now;
        DateTime pDate = Convert.ToDateTime(asset.PurchaseDate);
        TimeSpan diff = today - pDate;
        double years = diff.Days / 365.25;

        if (years >= 3.75)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);
            Console.ResetColor();
        }
        else if (years >= 3.5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);
        }
    }

    ShowMainMenu();
}

// Asset Menu Options
void AddNewAsset()
{
    ShowAddAssetMenu();

    while (showAssetMenuAgain)
    {
        switch (option.ToLower().Trim())
        {
            case ("p"):
                CreateNewPhone();
                break;

            case ("c"):
                CreateNewComputer();
                break;

            case ("q"):
                MainMenu();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option");
                Console.ResetColor();
                ShowAddAssetMenu();
                break;
        }
    }
}

// Main Menu Options
void MainMenu()
{
    ShowMainMenu();

    while (showMainMenuAgain)
    {
        switch (mainMenuOption.ToLower().Trim())
        {
            case "n":
                showAssetMenuAgain = true;
                AddNewAsset();
                break;
            case "o":
                ShowListByOffice();
                break;

            case "t":
                ShowListByType();
                break;

            case "q":
                Environment.Exit(0);
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option");
                Console.ResetColor();
                ShowMainMenu();
                break;
        }
    }
}

// Call the Main Menu the first time
MainMenu();



class Assets
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Office { get; set; }
    public string PurchaseDate { get; set; }
    public double Price { get; set; }
    public string Currency { get; set; }
    public double LocalPrice { get; set; }

}

class Phone : Assets
{
    public Phone(string type, string brand, string model, string office, string purchaseDate, double price, string currency, double localPrice)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        PurchaseDate = purchaseDate;
        Price = price;
        Currency = currency;
        LocalPrice = localPrice;
    }
}

class Computer : Assets
{
    public Computer(string type, string brand, string model, string office, string purchaseDate, double price, string currency, double localPrice)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        PurchaseDate = purchaseDate;
        Price = price;
        Currency = currency;
        LocalPrice = localPrice;
    }
}


