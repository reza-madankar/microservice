namespace Basket.Api.Entities
{
    public class Order
    {
        public Order(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
        public List<OrderDetails> Items { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;

                if (Items != null  && Items.Any())
                {
                    foreach (var item in Items)
                    {
                        total += item.Price * item.Quantity;
                    }
                }
                return total;
            }

        }
    }
}
