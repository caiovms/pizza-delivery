using System;

namespace pizza.delivery.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Client Client { get; set; }
    }
}