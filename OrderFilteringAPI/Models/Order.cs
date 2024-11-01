namespace OrderFilteringAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Weight { get; set; }
        public string DeliveryDistrict { get; set; }
        //public District DeliveryDistrict { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
