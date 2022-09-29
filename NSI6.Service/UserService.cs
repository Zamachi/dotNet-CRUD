using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using NSI6.Data;
using NSI6.Models;
using NSI6.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Service
{
    public interface IUserService : IBaseService
    {
        List<UserModel> ReadAll();

        UserModel ReadOne(int primarniKljuc);

        int? Create(UserModel obj);

        void Update(UserModel obj);

        void Delete(UserModel obj);
    }

    public class UserService : BaseService, IUserService
    {
        #region Dependecy Injection

        private readonly IUserRepository userRepository;
        private IMemoryCache cache;

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="userRepository"></param>
        public UserService(IMapper mapper, IUserRepository userRepository, IMemoryCache cache) : base(mapper)
        {
            this.userRepository = userRepository;
            this.cache = cache;
        }

        #endregion Dependecy Injection

        #region Functions

        /// <summary>
        ///     Create method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int? Create(UserModel obj)
        {
            return userRepository.Create(mapper.Map<User>(obj));
        }

        /// <summary>
        ///     Delete method
        /// </summary>
        /// <param name="obj"></param>
        public void Delete(UserModel obj)
        {
            userRepository.Delete(mapper.Map<User>(obj));
        }

        /// <summary>
        ///     Read all method
        /// </summary>
        /// <returns></returns>
        public List<UserModel> ReadAll()
        {
            //SEARCH FROM CACHE
            var usersCacheAlreadyExist = cache.TryGetValue($"users.{CultureInfo.CurrentCulture.Name}", out List<UserModel> usersCacheEntry);

            if (!usersCacheAlreadyExist)
            {
                var users = userRepository.ReadAll();
                var userModels = mapper.Map<List<UserModel>>(users);
                usersCacheEntry = userModels;

                var styleCacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(365));

                cache.Set($"users.{CultureInfo.CurrentCulture.Name}", usersCacheEntry, styleCacheEntryOptions);
            }

            return usersCacheEntry;
        }

        /// <summary>
        ///     Read one method
        /// </summary>
        /// <param name="primarniKljuc"></param>
        /// <returns></returns>
        public UserModel ReadOne(int primarniKljuc)
        {
            var user = userRepository.ReadOne(primarniKljuc);
            var userModel = mapper.Map<UserModel>(user);

            return userModel;
        }

        /// <summary>
        ///  Update method
        /// </summary>
        /// <param name="obj"></param>
        public void Update(UserModel obj)
        {
            userRepository.Delete(mapper.Map<User>(obj));
        }

        #endregion Functions
    }
}