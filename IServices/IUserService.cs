using bbl_dev_fest_2026_sirasith_klinfuengfu.Models;

namespace bbl_dev_fest_2026_sirasith_klinfuengfu.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User? GetById(long id);

        User Create(UserRequest request);

        User? Update(long id, UserRequest request);

        bool Delete(long id);
    }
}
