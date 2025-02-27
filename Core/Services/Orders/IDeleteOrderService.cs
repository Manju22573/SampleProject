using BusinessEntities;

namespace WebApi.Controllers
{
    public interface IDeleteOrderService
    {
        void Delete(Order order);
        void DeleteAll();
    }
}