
string mainMenuOption = "";
bool showMainMenuAgain = true;
string option = "";
bool showAssetMenuAgain = true;


Assets p1 = new Phone("Phone", "Iphone", "8", "Spain", 12292018, 970, "EUR", 801.65);
Assets c1 = new Computer("Computer", "HP", "Elitebook", "Spain", 06012019, 1423, "EUR", 1176.03);
Assets p2 = new Phone("Phone", "Iphone", "11", "Spain", 09252020, 990, "EUR", 818.18);
Assets p3 = new Phone("Phone", "Iphone", "X", "Sweden", 07152018, 1245, "SEK", 10375);

List<Assets> assets = new List<Assets>();
assets.Add(p1);
assets.Add(c1);
assets.Add(p2);
assets.Add(p3);


void ShowMainMenu()
{
    Console.WriteLine("Asset Tracking Menu");
    Console.WriteLine("To Add a New Asset - enter \"N\"");
    Console.WriteLine("To See Asset List - enter \"L\"");
    Console.WriteLine("To Exit - enter \"Q\"");
    mainMenuOption = Console.ReadLine();
}

void ShowAddAssetMenu()
{
    Console.WriteLine("Add New Asset");
    Console.WriteLine("Select Type: \"P\" for Phone, \"C\" for Computer or \"Q\" to Exit");
    option = Console.ReadLine();
}

void CreateNewPhone()
{
    string type = "Phone";

    Console.WriteLine("Enter Phone Brand:");
    string brand = Console.ReadLine();

    Console.WriteLine("Enter Phone Model:");
    string model = Console.ReadLine();

    Console.WriteLine("Enter Purchase Date:");
    int purchaseDate = Convert.ToInt32(Console.ReadLine());

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
            Console.WriteLine("Not a valid office");
            AddNewAsset();
        }


    assets.Add(new Phone(type, brand, model, office, purchaseDate, price, currency, localPrice));

}


void CreateNewComputer()
{
    string type = "Computer";

    Console.WriteLine("Enter Computer Brand:");
    string brand = Console.ReadLine();

    Console.WriteLine("Enter Computer Model:");
    string model = Console.ReadLine();

    Console.WriteLine("In which Office is the Computer in?");
    string office = Console.ReadLine();

    Console.WriteLine("Enter Purchase Date:");
    int purchaseDate = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enter Price in USD:");
    double price = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Enter Local Currency ( EUR / SEK / USD )");
    string currency = Console.ReadLine();

    Console.WriteLine("Enter the Local Price Today:");
    double localPrice = Convert.ToDouble(Console.ReadLine());

    assets.Add(new Computer(type, brand, model, office, purchaseDate, price, currency, localPrice));
}

void ShowList()
{
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");
    Console.WriteLine("----".PadRight(15) + "-----".PadRight(15) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(15) + "------------".PadRight(15) + "--------".PadRight(15) + "-----------------");

    List<Assets> sortedAssets = assets.OrderBy(asset => asset.Office).ToList();

    foreach (Assets asset in sortedAssets)
    {
        Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);

    }

    ShowMainMenu();
}

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

            case ("s"):
                CreateNewComputer();
                break;

            case ("q"):
                ShowMainMenu();
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

ShowMainMenu();

while (showMainMenuAgain)
{
    switch (mainMenuOption.ToLower().Trim())
    {
        case "n":
            showAssetMenuAgain = true;
            AddNewAsset();
            break;
        case "l":
            ShowList();
            break;
        case "q":
            showMainMenuAgain = false;
            break;
    }
}


//Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");
//Console.WriteLine("----".PadRight(15) + "-----".PadRight(15) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(15) + "------------".PadRight(15) + "--------".PadRight(15) + "-----------------");

//foreach (Assets asset in assets)
//{
//    Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency.ToUpper().PadRight(15) + asset.LocalPrice);

//}

Console.ReadLine();

class Assets
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Office { get; set; }
    public int PurchaseDate { get; set; }
    public double Price { get; set; }
    public string Currency { get; set; }
    public double LocalPrice { get; set; }

}

class Phone : Assets
{
    public Phone(string type, string brand, string model, string office, int purchaseDate, double price, string currency, double localPrice)
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
    public Computer(string type, string brand, string model, string office, int purchaseDate, double price, string currency, double localPrice)
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


