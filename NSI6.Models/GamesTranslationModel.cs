using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Models
{
    public class GamesTranslationModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string? culture_code { get; set; }
        public GamesModel Games { get; set; }
    }
}
