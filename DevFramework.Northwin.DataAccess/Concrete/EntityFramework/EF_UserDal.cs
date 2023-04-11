using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwin.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.EntityFramework
{
    public class EF_UserDal : EF_EntityRepositoryBase<Users, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(Users user)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                var result = from userrole in context.UserRoles
                             join role in context.Roles
                             on userrole.Id equals user.Id
                             where userrole.UserId == user.Id
                             select new UserRoleItem { RolesName = role.Name};
                return result.ToList();
            }
        }
    }
}
