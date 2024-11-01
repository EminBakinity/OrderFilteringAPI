using OrderFilteringAPI.Models;

namespace OrderFilteringAPI.Abstractions.IServices
{
    public interface IOrderService
    {
        public List<Order> LoadOrdersFromFile();
        public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime);
    }
}
