using DevFramework.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.Entities.ComplexType;

namespace DevFramework.Northwin.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<Users>
    {
        List<UserRoleItem> GetUserRoles(Users user);
    }
}
