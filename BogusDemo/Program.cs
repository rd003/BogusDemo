using Bogus;
namespace BogusDemo;


public class Program
{
    static void GenerateRandomData()
    {
        Faker faker = new();
        string randomText = faker.Lorem.Text();
        int randomNUmber = faker.Random.Int(1, 100);
        DateTime randomDate = faker.Date.Recent();
        string name = faker.Name.FullName();

        Console.WriteLine($"text: {randomText}");
        Console.WriteLine($"number: {randomNUmber}");
        Console.WriteLine($"randomDate: {randomDate}");
        Console.WriteLine($"name: {faker.Name.FullName()}");
    }

    static void GenerateRandomOrder()
    {

        //var faker = new Faker();
        //var order = new Order
        //{
        //    OrderId = faker.Random.Number(1, 100),
        //    Item = faker.Commerce.Product(),
        //    Quantity = faker.Random.Number(1, 5),
        //    UnitPrice = Convert.ToDouble(faker.Commerce.Price(10, 100))
        //};

        //var faker = new Faker<Order>()
        //    .StrictMode(false)
        //    .RuleFor(o => o.OrderId, f => f.Random.Number(1, 100))
        //    .RuleFor(o => o.Item, f => f.Commerce.Product())
        //    .RuleFor(o => o.Quantity, f => f.Random.Number(1, 5))
        //    .RuleFor(o => o.UnitPrice, f => Convert.ToDouble(f.Commerce.Price(10, 100)));

        var faker = new Faker<Order>()
        .StrictMode(false)
        .Rules((f, o) =>
        {
            o.OrderId = f.Random.Number(1, 100);
            o.Item = f.Commerce.Product();
            o.Quantity = f.Random.Number(1, 5);
            o.UnitPrice = Convert.ToDouble(f.Commerce.Price(10, 100));
        });


        var order = faker.Generate();

        Console.WriteLine($"Order ID: {order.OrderId}");
        Console.WriteLine($"Item: {order.Item}");
        Console.WriteLine($"Unit Price: {order.UnitPrice}");
        Console.WriteLine($"Quantity: {order.Quantity}");
    }

    static void GeneratePersonData()
    {

        var faker = new Faker<Person>()
             .StrictMode(false)
             .Rules((f, p) =>
             {
                 p.FirstName = f.Person.FirstName;
                 p.LastName = f.Person.LastName;
                 p.Gender = f.Person.Gender.ToString();
                 p.Email = f.Internet.Email(p.FirstName, p.LastName);
                 p.Age = f.Random.Number(18, 65);
                 p.Country = f.Address.Country();
             });

        var people = faker.Generate(10);

        foreach (var person in people)
        {

            Console.WriteLine($"Name: {person.FirstName} {person.LastName},Gender: {person.Gender}, Email: {person.Email}, Age: {person.Age}, Country: {person.Country}");
            Console.WriteLine();
        }

    }
    static void Main()
    {
        // GenerateRandomData();
        // GenerateRandomOrder();
        GeneratePersonData();
    }
}
