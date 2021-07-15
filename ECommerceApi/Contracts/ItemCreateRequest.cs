namespace ECommerceApi.Contracts
{
    public class ItemCreateRequest
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}