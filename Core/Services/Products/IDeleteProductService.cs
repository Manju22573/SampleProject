using BusinessEntities;

namespace WebApi.Controllers
{
    public interface IDeleteProductService
    {
        void Delete(Product user);
        void DeleteAll();
    }
}