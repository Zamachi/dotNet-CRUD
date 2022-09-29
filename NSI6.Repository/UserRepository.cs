using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NSI6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}