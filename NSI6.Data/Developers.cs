using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSI6.Data
{
    [Table("developers")]
    public class Developers
    {
        //[Column("user_id")]
        //public int user_id { get; set; }
        [Key, Required, Column("developer_code")]
        public string developer_code { get; set; }

        public ICollection<Games> games { get; set; } = new List<Games>();
        public User User { get; set; } 
        public string? role { get; set; }
    }
}
