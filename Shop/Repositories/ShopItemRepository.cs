using Dapper;
using Shop.DTOs;
using Shop.Interfaces;
using System.Data;

namespace Shop.Repositories
{
    public class ShopItemRepository : IShopItemRepository
    {
        private readonly IDbConnection _dbConnection;
        public ShopItemRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<ShopItemInternal> GetAllShopItems()
        {
            // nenaudok * pakeisk i apribota
            string query = "SELECT * FROM shop;";
            var response = _dbConnection.Query<ShopItemResponse>(query).ToList();
            var internalShopItemData = response.Select(item => ShopItemInternal.ConvertToInternal(item)).ToList();
            return internalShopItemData;
        }

        public ShopItemInternal GetShopItem(int id)
        {
            string query = "SELECT * FROM shop WHERE item_id = @ItemId;";
            var response = _dbConnection.QueryFirstOrDefault<ShopItemResponse>(query, new { ItemId = id });
            var internalShopItemData = ShopItemInternal.ConvertToInternal(response);
            return (internalShopItemData);
        }

        public int InsertShopItem(string name, decimal price)
        {
            string query = "INSERT INTO shop (item_name, price, created_on) VALUES (@name, @price, NOW())";
            var queryArguments = new
            {
                name = name,
                price = price,
            };

            return _dbConnection.Execute(query, queryArguments);
        }

        public ShopItemResponse UpdateShopItem(int id, string name, string price)
        {
            string query = "UPDATE shop SET item_name = @name, price = @price WHERE item_id = @id";
            var queryArguments = new
            {
                name = name,
                price = price,
                id = id,
            };
            return _dbConnection.QueryFirst<ShopItemResponse>(query);
        }

        public int DeleteShopItem(int id)
        {
            string query = "DELETE FROM shop WHERE item_id = @Item_Id;";
            return _dbConnection.Execute(query);
        }
    }
}
