using pizza.delivery.Application.Models.Interfaces;

namespace pizza.delivery.Application.Models.Responses
{
    public  class ClientResult : IResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}