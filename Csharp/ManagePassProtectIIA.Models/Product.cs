using System.Text.Json.Serialization;

namespace ManagePassProtectIIA.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Label { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime? Updated_at { get; set; }
        public required int TypeId { get; set; }
        public required Type Type { get; set; }
        public Product() {}
    }
}