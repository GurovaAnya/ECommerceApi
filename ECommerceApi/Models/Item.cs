using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sku")]
        public string Sku { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("type")]
        public string Type { get; set; }
        
        [Column("price")]
        public decimal Price { get; set; }
    }
}