using System.ComponentModel.DataAnnotations;

namespace Shop.DTOs
{
    public class ShopItemInternal
    {
        public int Item_Id { get; set; }
        public string Item_Name { get; set; }

        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Price should be more than 0.01.")]
        public decimal Price { get; set; }
        public string Created_On { get; set; }

        public ShopItemInternal(int id, string name, decimal price, string created_on)
        {
            Item_Id = id;
            Item_Name = name;
            Price = price;
            Created_On = created_on;
        }

        public static ShopItemInternal ConvertToInternal(ShopItemResponse request)
        {
            ShopItemInternal result = new(request.Item_Id, request.Item_Name, request.Price, request.Created_On);
            return result;
        }
    }


}
