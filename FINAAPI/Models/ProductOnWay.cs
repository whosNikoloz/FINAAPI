namespace FINAAPI.Models
{
    public class ProductOnWay
    {
         public int Id { get; set; }
         public DateTime Date { get; set; }
         public decimal Quantity { get; set; }
    }

    public class ProductsOnWayResponse
    {
        public List<ProductOnWay> On_Way { get; set; }
        public string Ex { get; set; }
    }
}
