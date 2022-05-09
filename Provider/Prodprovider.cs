using FirstAPI.Model;
using FirstAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Provider
{
    public class Prodprovider:IProvider
    {
            public readonly IProduct _repo ;
            public Prodprovider(IProduct repo)
            {
                _repo = repo;
            }
            public Product AddNewProduct(Product p)
            {
                _repo.AddNewProduct(p);
                return p;
            }

            public void DeleteProduct(int id)
            {
                _repo.DeleteProduct(id);

            }


            public Product GetProductById(int id)
            {
                return _repo.GetProductById(id);
            }

            public List<Product> GetProducts()
            {
                return _repo.GetProducts();
                
            }

            public Product UpdateProduct(int id, Product P)
            {
                _repo.UpdateProduct(id, P);
                return P;
                

            }
            public bool ProductExists(int id)
            {
                return _repo.ProductExists(id);
            }


        public bool checkquality(int id, int qty)
        {
            return _repo.checkquality(id, qty);
        }
    }
}
