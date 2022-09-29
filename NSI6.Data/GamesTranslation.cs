using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Data
{
    [Table("games_translation")]
    public class GamesTranslation
    {

        [Column("translation_id")]
        public int Id { get; set; }
        //[Column("game_id")]
        //public int game_id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("culture_code")]
        public string? culture_code { get; set; }
        public Games Games { get; set; }
    }
}
