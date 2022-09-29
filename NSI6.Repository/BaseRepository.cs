using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Repository
{
    public interface IBaseRepository<TEntety>
    {
        List<TEntety> ReadAll();

        TEntety ReadOne(int primarniKljuc);

        int? Create(TEntety obj);

        void Update(TEntety obj);

        void Delete(TEntety obj);
    }

    public class BaseRepository<TEntety> : IBaseRepository<TEntety>
    {
        #region Dependecy injection

        private readonly IConfiguration configuration;
        private readonly string connString;
        public readonly NpgsqlConnection connection;

        #endregion Dependecy injection

        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="configuration"></param>
        public BaseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            connString = configuration.GetConnectionString("PostgresSql");
            connection = new NpgsqlConnection(connString);
        }

        #endregion Constructors

        #region Functions

        /// <summary>
        ///     Create method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int? Create(TEntety obj)
        {
            return connection.Insert(obj);
        }

        /// <summary>
        ///     Delete method
        /// </summary>
        /// <param name="obj"></param>
        public void Delete(TEntety obj)
        {
            connection.Delete(obj);
        }

        /// <summary>
        ///     Read all method
        /// </summary>
        /// <returns></returns>
        public List<TEntety> ReadAll()
        {
            return connection.GetList<TEntety>().ToList();
        }

        /// <summary>
        ///     Read one method
        /// </summary>
        /// <param name="primarniKljuc"></param>
        /// <returns></returns>
        public TEntety ReadOne(int primarniKljuc)
        {
            return connection.Get<TEntety>(primarniKljuc);
        }

        /// <summary>
        ///     Update
        /// </summary>
        /// <param name="obj"></param>
        public void Update(TEntety obj)
        {
            connection.Update(obj);
        }

        #endregion Functions
    }
}