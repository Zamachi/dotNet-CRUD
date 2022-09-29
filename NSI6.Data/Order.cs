using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Data
{
    [Table("orders")]
    public class Order
    {
        [Column("order_id")]
        public int Id { get; set; }
        [Column("created_at")]
        public DateTime? created_at { get; set; }
        public User Owner{ get; set; }
        public ICollection<GamesTranslation> Items { get; set; } = new List<GamesTranslation>();
    }
}