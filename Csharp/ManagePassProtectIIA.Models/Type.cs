using System.Text.Json.Serialization;

namespace ManagePassProtectIIA.Models
{
    public class Type
    {
        public int Id { get; set; }
        public required string Label { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime? Updated_at { get; set; }
        [JsonIgnore]
        public List<Product>? Products { get; set; }
        public Type() { }
    }
}