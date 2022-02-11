using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete.BaseEntities;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfBaseRepository<User,DatabaseContext>,IUserDal
    {
    }
}
