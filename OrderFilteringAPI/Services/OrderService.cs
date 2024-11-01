using OrderFilteringAPI.Abstractions.IServices;
using OrderFilteringAPI.Models;
using System.Text.Json;

namespace OrderFilteringAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly string _filePath = "Data/orders.json";

        public List<Order> LoadOrdersFromFile()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"Файл не найден: {_filePath}");
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Order>>(json);
        }

        public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime)
        {
            return orders.Where(order =>
                order.DeliveryDistrict == district &&
                order.DeliveryTime >= firstDeliveryTime &&
                order.DeliveryTime <= firstDeliveryTime.AddMinutes(30)).ToList();
        }
    }
}
