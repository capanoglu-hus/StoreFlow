namespace StoreFlow.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Boolean CategoryStatus { get; set; }

        public List<Product> Products { get; set; } //1e çok ilişki 
    }
}
