using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Data
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public int Id { get; set; }

        [Column("username")]
        public string username { get; set; }

        [Column("password")]
        public string password { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("first_name")]
        public string first_name { get; set; }
        [Column("last_name")]
        public string last_name { get; set; }
        //[Column("created_at")]
        //public DateOnly? created_at { get; set; }
        [Column("country")]
        public string country { get; set; }
    
        public ICollection<Order> orders { get; set; }
    }
}