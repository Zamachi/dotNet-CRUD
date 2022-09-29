using Dapper;
using Microsoft.Extensions.Configuration;
using NSI6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        List<Order> GetAllOrders();
        Order Get(int id, string culture_code);
    }

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Order Get(int id, string culture_code)
        {
            string sql = $"SELECT games_translation.translation_id AS Id, games_translation.name AS name, games.game_id AS Id, games.price AS price, order_item.quantity AS quantity, order_item.item_id AS Id FROM orders INNER JOIN order_item ON orders.order_id = order_item.order_id INNER JOIN games ON order_item.game_id = games.game_id INNER JOIN games_translation ON games_translation.game_id = games.game_id INNER JOIN users ON users.user_id = orders.user_id WHERE LOWER(culture_code) = LOWER('{culture_code}') AND order_item.order_id = {id}";

            var result = connection.Query<GamesTranslation, Games, Order, Order>(sql, (translation, game, order) => {
                translation.Games = game;
                order.Items.Add(translation);

                return order;
            }, splitOn: "Id",
            commandType: System.Data.CommandType.Text);

            return result.FirstOrDefault();

        }

        public List<Order> GetAllOrders()
        {
            string sql = "SELECT order_id AS Id, orders.created_at AS created_at, users.user_id AS Id, users.username as username FROM orders INNER JOIN users ON orders.user_id = users.user_id";

            var result = connection.Query<Order, User, Order>(sql, (order, user) => {
                order.Owner = user;
                return order;
            }, splitOn: "Id",
            commandType: System.Data.CommandType.Text);

            return result.ToList();

        }
    }
}
