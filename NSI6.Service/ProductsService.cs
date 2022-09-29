using AutoMapper;
using NSI6.Models;
using NSI6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Service
{
    public interface IProductsService : IBaseService
    {
        List<GamesTranslationModel> readAll(string culture_code);
        GamesTranslationModel GetOne(int id, string culture_code);
    }
    public class ProductsService : BaseService, IProductsService
    {
        private IProductsRepository ProductsRepository;
        public ProductsService(IMapper mapper, IProductsRepository productsRepository) : base(mapper)
        {
            ProductsRepository = productsRepository;
        }

        public List<GamesTranslationModel> readAll(string culture_code)
        {
            return this.mapper.Map<List<GamesTranslationModel>>( ProductsRepository.GetAll(culture_code));
        }

        GamesTranslationModel IProductsService.GetOne(int id, string culture_code)
        {
            return this.mapper.Map<GamesTranslationModel>(ProductsRepository.GetOne(id,culture_code));
        }

    }
}
