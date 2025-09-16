using System;

namespace CustomerImageApp.Models
{
    public class CustomerImage
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Base64Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
