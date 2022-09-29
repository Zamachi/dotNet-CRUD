using AutoMapper;
using NSI6.Data;
using NSI6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Service
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Games, GamesModel>().ReverseMap();
            CreateMap<GamesTranslation, GamesTranslationModel>().ReverseMap();
            CreateMap<Developers, DevelopersModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}