
Phone p1 = new Phone("Iphone", "8", "Spain", 12292018, 970, "EUR", 801.65);
Computer c1 = new Computer("HP", "Elitebook", "Spain", 06012019, 1423, "EUR", 1176.03);
Phone p2 = new Phone("Iphone", "11", "Spain", 09252020, 990, "EUR", 818.18);
Phone p3 = new Phone("Iphone", "X", "Sweden", 07152018, 1245, "SEK", 10375);

List<Assets> assets = new List<Assets>();
assets.Add(p1);
assets.Add(c1);
assets.Add(p2);
assets.Add(p3);


Console.WriteLine("Type".PadRight(20) + "Brand".PadRight(20) + "Model".PadRight(20) + "Office".PadRight(20) + "Purchase Date".PadRight(20) + "Price in USD".PadRight(20) + "Currency".PadRight(20) + "Local price today");
Console.WriteLine("----".PadRight(20) + "-----".PadRight(20) + "-----".PadRight(20) + "------".PadRight(20) + "-------------".PadRight(20) + "------------".PadRight(20) + "--------".PadRight(20) + "-----------------");

foreach (Assets asset in assets)
{
    
    
}

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


