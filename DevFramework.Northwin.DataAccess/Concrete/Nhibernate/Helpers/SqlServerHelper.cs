﻿using DevFramework.Core.DataAccess.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwin.DataAccess.Concrete.Nhibernate.Helpers
{
    public class SqlServerHelper : NhibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c=>c.FromConnectionStringWithKey("NorthwindContext"))) // burada connection string veriyoruz. 
                .Mappings(t=>t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory(); // burada mapping tanımlıyoruz. 
        }
    }
}
