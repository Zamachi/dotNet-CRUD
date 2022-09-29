using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Models
{
    public class GamesModel
    {

        public int Id { get; set; }
        public double price { get; set; }
        public int? quantity { get; set; }
        public ICollection<GamesTranslationModel> GamesTranslation { get; set; }
        public ICollection<OrderModel> OrderItems { get; set; }
        public ICollection<DevelopersModel> Developers { get; set; }
    }
}
