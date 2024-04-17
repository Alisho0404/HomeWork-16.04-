using _001GroupBy;
using _005.DataAnnotation.Data;
using _001GroupBy.Migrations;


await using var dataContext = new DataContext();


Console.WriteLine("Good look  😊😊😊");

//1
//Получить количество заказов для каждого клиента
//Get the number of orders for each customer
var result = from o in dataContext.Orders
           group o by o.CustomerId into g
           select new
           {
               g.Key,
               Count=g.Count(),
           };
foreach (var item in result)
{
    Console.WriteLine($"Customer: {item.Key} OrderCount:{item.Count}");
}

//2
//Получить общую стоимость заказов для каждого клиента
//Get the total cost of orders for each customer
var res = from o in dataContext.OrderItems
          group o by o.OrderId into g
          select new
          {
              g.Key,
              Sum = g.Sum(x=>x.Price)
          };
foreach (var item in res)
{
    Console.WriteLine($"Customer:{item.Key} Sum:{item.Sum}");
}
Console.WriteLine();
//3
//Получить среднюю стоимость заказов для каждого клиента
//Get the average order value for each customer
var query = from o in dataContext.OrderItems
            group o by o.OrderId into g
            select new
            {
                g.Key,
                Average = g.Average(x => x.Price)
            };
foreach (var item in query)
{
    Console.WriteLine($"Customer:{item.Key} Average:{item.Average}");
}


