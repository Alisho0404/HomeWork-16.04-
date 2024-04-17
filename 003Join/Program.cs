using _005.DataAnnotation.Data;

await using var dataContext = new DataContext();

Console.WriteLine("Good look  😊😊😊");

//1
//Получите все заказы с указанием имени клиента и количества заказа клиента.
//Get all orders with customer name and customer order quantity
var result = from order in dataContext.Orders
             join customer in dataContext.Customers on order.CustomerId equals customer.Id
             join orderName in dataContext.OrderItems on order.Id equals orderName.OrderId
             group order by order.Customer into g
             select new
             {
                 g.Key.Name,
                 Count = g.Count()
             };
foreach (var item in result)
{
    Console.WriteLine($"Name:{item.Name} Count:{item.Count}");
}
Console.WriteLine();

//2
//Получить все заказы с именем клиента и стоимостью заказа
//Get all orders with customer name and order value
var result2= from order in dataContext.Orders
             join customer in dataContext.Customers on order.CustomerId equals customer.Id
             join orderName in dataContext.OrderItems on order.Id equals orderName.OrderId
             group orderName by order.Customer into g
             select new
             {
                 g.Key,
                 Sum = g.Sum(x=>x.Price)
             };
foreach (var item in result2)
{
    Console.WriteLine($"Name:{item.Key} Count:{item.Sum}");
}

//3
//Получите все заказы с указанием имени клиента и количества продукции
//Get all orders with customer name and product quantity:
var result3 = from order in dataContext.Orders
              join customer in dataContext.Customers on order.CustomerId equals customer.Id
              join orderName in dataContext.OrderItems on order.Id equals orderName.OrderId
              group customer by order.Customer into g
              select new
              {
                  g.Key.Name,
                  Count = g.Count()
              };
foreach (var item in result3)
{
    Console.WriteLine($"Name:{item.Name} Count:{item.Count}");
}


//var res=from order in dataContext.Orders select order;  