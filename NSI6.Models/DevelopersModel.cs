using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Models
{
    public class DevelopersModel
    {
        public string developer_code { get; set; }
        public ICollection<GamesModel> games { get; set; }
        public UserModel User { get; set; } 
        public string? role { get; set; }
    }
}
