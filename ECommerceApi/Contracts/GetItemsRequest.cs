namespace ECommerceApi.Contracts
{
    public class GetItemsRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Type { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}