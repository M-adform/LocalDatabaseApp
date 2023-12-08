using System.ComponentModel.DataAnnotations;

namespace Shop.DTOs
{
    public class ShopItemRequest
    {
        [Key]
        public string Item_Name { get; set; }

        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Price should be more than 0.01.")]
        public decimal Price { get; set; }
    }
}
