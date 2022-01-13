using System.Collections.Generic;

namespace pizza.delivery.Domain.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }    
        public string Email { get; set;}
        public string Phone { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}