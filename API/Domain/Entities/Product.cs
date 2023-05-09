using API.Domain.Common;

namespace API.Domain.Entities
{
    public class Product :BaseEntity
    {
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category? Category { get; set; }
    }
}
