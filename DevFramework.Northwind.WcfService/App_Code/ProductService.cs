using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolves.Ninject;
using DevFramework.Northwind.Entities.Concrete;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService:IProductService
{
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private IProductService _productService = InstanceFactory.GetInstence<IProductService>();
    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public void TransectionalOperation(Product product1, Product product2)
    {
       _productService.TransectionalOperation(product1, product2);
    }

    public Product Update(Product product)
    {
       return  _productService.Update(product);
    }
}