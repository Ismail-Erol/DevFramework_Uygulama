using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public abstract class NhibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory; // factory design patterninden besleniyor. 

        public virtual ISessionFactory SessionFactory 
        { 
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); } 
        }

        // gönderilecek olan sessionfactory metodu belli olmadığı için onu Nhibernate kullanıcılarının kullanabilmesi için bu şekilde yazıyoruz. 
        // gönderilecek factory oracle, mysql yada mssql cinsinden olabilir. bunun için sınıfımızıda abstract sınıf yapıyoruz. Buna göre implementasyon oluşturuyoruz. 
        protected abstract ISessionFactory InitializeFactory(); 

        // burada kişi nasıl bir session gönderdiyse onu kullanarak bir session aç 
        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
