using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime? created_at { get; set; }
        public UserModel Owner{ get; set; }
        public ICollection<GamesTranslationModel> Items { get; set; } = new List<GamesTranslationModel>();  
    }
}
