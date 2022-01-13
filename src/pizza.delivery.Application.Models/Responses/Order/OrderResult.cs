using System;
using System.Text.Json.Serialization;
using pizza.delivery.Application.Models.Interfaces;

namespace pizza.delivery.Application.Models.Responses
{
    public class OrderResult : IResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        [JsonPropertyName("client")]
        public virtual ClientResult ClientResult { get; set; } 
    }
}