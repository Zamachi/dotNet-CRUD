using AutoMapper;
using NSI6.Data;
using NSI6.Models;
using NSI6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Service
{
    public interface IOrderService : IBaseService
    {
        List<OrderModel> getAllOrders();
        OrderModel getOrderById(int id, string culture_code);

    }

    public class OrderService : BaseService, IOrderService
    {
        private IOrderRepository OrderRepository;
        public OrderService(IMapper mapper, IOrderRepository orderRepository) : base(mapper)
        {
            OrderRepository = orderRepository;
        }

        public List<OrderModel> getAllOrders()
        {
            return mapper.Map<List<OrderModel>>(OrderRepository.GetAllOrders());
        }

        public OrderModel getOrderById(int id, string culture_code)
        {
            return mapper.Map<OrderModel>(OrderRepository.Get(id, culture_code));
        }
    }
}
