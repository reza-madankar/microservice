﻿namespace Basket.Api.Entities
{
    public class OrderDetails
    {
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }
}