using AutoMapper;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsft;
using DevFramework.Northwin.DataAccess.Abstract;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;


namespace DevFramework.Northwind.Business.Concrete.Managers
{
    // [LogAspect(typeof(FileLogger))] // burada bütün yapılan işlemleri loglamak için kullanıyoruz. 
    // bunun dışında loglama yapmak için properties kısmında AssemblyInfo kısmında loglama attribute'ünü ekliyoruz. 

    // klas seviyesinde de performance aspecti kullanmak istersek
    // [PerformanceCounterAspect()] 
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        // [LogAspect(typeof(FileLogger))] burada sadece metotları loglamak için kullanıyoruz. ama dosyaya loglamak için 
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        // [LogAspect(typeof(DatabaseLogger))]

        // [LogAspect(typeof(FileLogger))]

        // bu methodun performansı bizim için önemliyse methot seviyesinde bu şekilde kullanabiliriz. 
        [PerformanceCounterAspect(2)]

        // autorize gibi bir işlemi aspectler ile bu şekilde tanımlayabiliriz.  
        // [SecuredOperation(Roles="Admin,Editor")] // getall operasyonunu sadece admin ve editör olanlar yapabilsin. 
        public List<Product> GetAll()
        {
            // Thread.Sleep(3000); 
            //return _productDal.GetList().Select(p => new Product // bu kısım manual mapping
            //{
            //    CategoryId = p.CategoryId,
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    UnitPrice = p.UnitPrice,
            //    Discontinued = p.Discontinued,
            //    QuantityPerUnit = p.QuantityPerUnit,
            //    ReorderLevel = p.ReorderLevel,
            //    UnitsInStock = p.UnitsInStock,
            //    UnitsOnOrder = p.UnitsOnOrder
            //}).ToList();

            // manual automapper kullanarak mapping 
            // List<Product> products = AutoMapperHelper.MapToSameTypeList(_productDal.GetList());

            // automapper kullanarak mapping 
            List<Product> products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }

        // automapping refactoring
        //private List<T> MapToSameTypeList<T>(List<T> list)
        //{
        //    Mapper.Initialize(c =>
        //    {
        //        c.CreateMap <T, T>();
        //    });

        //    List<T> result = Mapper.Map<List<T>, List<T>>(list);
        //    return result;
        //}

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [TransactionScopeAspect]
        public void TransectionalOperation(Product product1, Product product2)
        {
                    _productDal.Add(product1);
                    // iş kodları
                    _productDal.Update(product2);

        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
