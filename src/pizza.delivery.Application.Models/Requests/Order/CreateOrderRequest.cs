using System;

namespace pizza.delivery.Application.Models.Requests
{
    public class CreateOrderRequest
    {
        public int ClientId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}