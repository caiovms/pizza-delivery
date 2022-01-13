using System;

namespace pizza.delivery.Application.Models.Requests
{
    public class UpdateOrderRequest
    {
        public int ClientId{ get; set; }
        public string Description { get; set; }
    }
}