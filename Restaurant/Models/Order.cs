namespace Restaurant.Models
{
    public class Order
    {
          public int Id { get; set; }
        public int Uid { get; set; }
        public string FoodItemName { get; set; }
         public bool IsOrderAccepted { get; set; }
    }
}
