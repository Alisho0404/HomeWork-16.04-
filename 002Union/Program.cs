using _001GroupBy;
using _005.DataAnnotation.Data;

await using var dataContext = new DataContext();


Console.WriteLine("Good look  😊😊😊");

//1
//Получить все заказы, сделанные клиентом с именем "Ahmad", а также все заказы, в которых был заказан товар с названием "Water"
//Retrieve all orders placed by a customer named "Ahmad" as well as all orders that included a product named "Water"
//var query =(from x in dataContext.Orders where x.Customer.Name == "Ahmad" select x )
//    .Union(from x in dataContext.Orders where x.OrderItems.Where(z => z.ProductName == "Water").Any() select x).ToList();
    




//foreach (var item in query)
//{
//    Console.WriteLine($"Name: {item.Id} {item.OrderDate}");
//}


//2
//Получить все заказы, сделанные клиентом с именем "Akmal", а также все заказы, в которых был заказан товар с названием "Banana"
//Retrieve all orders placed by a customer named "Akmal" as well as all orders that included a product named "Banana"
var query1 = from o in dataContext.Orders
             join c in dataContext.Customers on o.CustomerId equals c.Id
             where (c.Name == "Akmal")
             join orders in dataContext.OrderItems on o.Id equals orders.OrderId
             where (orders.ProductName == "Banana")
             select new
             {
                 Name = c.Name,
                 ProductName = orders.ProductName
             };
foreach (var item in query1)
{
    Console.WriteLine($"Name: {item.Name} Product: {item.ProductName}");
}
dataContext.Database.EnsureDeleted();