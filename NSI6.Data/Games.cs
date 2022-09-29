using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Data
{
    [Table("games")]
    public class Games
    {
        [Column("game_id")]
        public int Id { get; set; }
        [Column("price")]
        public double price { get; set; }
        public int? quantity { get; set; }
        //[Column("base_game_id")]
        //public int? base_game_id { get; set; }
        public ICollection<GamesTranslation> GamesTranslation { get; set; } = new List<GamesTranslation>();
        public ICollection<Order> OrderItems { get; set; } = new List<Order>();
        public ICollection<Developers> Developers { get; set; } = new List<Developers>();
    }
}
