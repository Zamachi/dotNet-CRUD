using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Service
{
    public interface IBaseService
    {
    }

    public class BaseService : IBaseService
    {
        public readonly IMapper mapper;

        public BaseService(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}