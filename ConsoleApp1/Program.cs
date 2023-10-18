using Newtonsoft.Json;

Products table = Factory.Create("table", 1, 10, 1, true);
Products piano = Factory.Create("piano", 1, 100, 1, true);
Products computer = Factory.Create("computer", 1, 15, 1, true);
Products bag = Factory.Create("bag", 1, 2, 1, true);
Products phone = Factory.Create("phone", 1, 1, 1, true);
Products chair = Factory.Create("chair", 1, 3, 1, true);
Products desk = Factory.Create("desk", 1, 9, 1, true);
Products book = Factory.Create("book", 1, 4, 1, true);
Products note = Factory.Create("note", 1, 19, 1, true);
Products pen = Factory.Create("pen", 1, 13, 1, true);


List<Products> products = new List<Products>()
{
    table, piano, computer, bag, phone, chair, desk, book, note, pen
};

Console.WriteLine("Норм список");
Print(jsonConvert(products));

Console.WriteLine("\nСортировка по весу");
SortByWeigth(products);


List<string> jsonConvert(List<Products> products)
{
    List<string> list = new List<string>();
    foreach (Products product in products)
    {
        string json = JsonConvert.SerializeObject(product);
        list.Add(json);
    }
    return list;
}

void Print(List<string> list)
{
    foreach (string item in list)
    {
        Console.WriteLine(item);
    }
}

void SortByWeigth(List<Products> products)
{
    for (int j = 0; j < products.Count; j++)
    {
        for (int i = 0; i < products.Count; i++)
        {
            if (i < 9 && products[i].weight < products[i + 1].weight)
            {
                var temp = products[i];
                products[i] = products[i + 1];
                products[i + 1] = temp;
            }
        }
    }
    Print(jsonConvert(products));
}
class Products
{
    public string name;
    public int price;
    public int weight;
    public int size;
    public bool delicate;

    public Products(string name, int price, int weight, int size, bool delicate)
    {
        this.name = name;
        this.price = price;
        this.weight = weight;
        this.size = size;
        this.delicate = delicate;
    }
}

static class Factory
{
    public static Products Create(string name, int price, int weight, int size, bool delicate)
    {
        return new Products(name, price, weight, size, delicate);
    }

}