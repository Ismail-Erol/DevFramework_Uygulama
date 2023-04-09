using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwin.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.EntityFramework
{
    public class EF_CategoryDal : EF_EntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
