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
    public interface IProductsRepository : IBaseRepository<GamesTranslation>
    {
        List<GamesTranslation> GetAll(string culture_code);
        GamesTranslation GetOne(int id, string culture_code);

    }
    public class ProductsRepository : BaseRepository<GamesTranslation>, IProductsRepository
    {
        public ProductsRepository(IConfiguration configuration) : base(configuration)
        {
        }

        List<GamesTranslation> IProductsRepository.GetAll(string culture_code)
        {
            string sql = $"SELECT " +
                    "games_translation.translation_id as Id," +
                    "games_translation.name as name," +
                    "games_translation.description as description," +
                    "games.game_id as Id," +
                    "games.price as price " +
                "FROM " +
                    "games " +
                "INNER JOIN " +
                    "games_translation ON games.game_id = games_translation.game_id " +
                "WHERE " +
                    "LOWER(games_translation.culture_code) = LOWER('" + culture_code + "')";

            var result = connection.Query<GamesTranslation, Games, GamesTranslation>(
                sql,
                (translated, game) => { translated.Games = game; return translated; },
                splitOn: "Id, Id",
                commandType: System.Data.CommandType.Text
            );

            return result.ToList();

        }

        GamesTranslation IProductsRepository.GetOne(int id, string culture_code)
        {
            string sql = $"SELECT games.game_id as Id, games.price as price, games_translation.translation_id as Id, games_translation.name as name, games_translation.description as description, users.user_id as Id, users.first_name as first_name, users.last_name as last_name, users.username as username, developed_by.developer_code as Id, developed_by.role as role FROM games INNER JOIN games_translation ON games.game_id = games_translation.game_id INNER JOIN developed_by ON developed_by.game_id = games.game_id INNER JOIN developers ON developers.developer_code = developed_by.developer_code INNER JOIN users ON users.user_id = developers.user_id WHERE LOWER(culture_code) = LOWER('{culture_code}') AND games.game_id = {id}";

            var result = connection.Query<Games, GamesTranslation, User, Developers, GamesTranslation>(
                sql,
                (game, translate, user, developer) =>
                {

                    translate.Games = game;
                    developer.User = user;
                    translate.Games.Developers.Add(developer);

                    return translate;
                },
                splitOn: "Id",
                commandType: System.Data.CommandType.Text
            );

            var rezultat = result.GroupBy(x => x.Id).Select(g =>
            {
                var prvaGrupa = g.First();
                prvaGrupa.Games.Developers = g.Select(asd => asd.Games.Developers.First()).ToList();

                return prvaGrupa;
            }); 
                
            return rezultat.FirstOrDefault();
        }
    }
}
