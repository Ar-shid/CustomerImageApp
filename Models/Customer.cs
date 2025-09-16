using System.Collections.Generic;

namespace CustomerImageApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CustomerImage> Images { get; set; } = new List<CustomerImage>();
    }
}
