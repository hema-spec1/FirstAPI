using FirstAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Provider
{
    public interface IProvider
    {
        public List<Product>GetProducts();
        public Product GetProductById(int id);
        public Product AddNewProduct(Product p);
        public void DeleteProduct(int p);
        public Product UpdateProduct(int p, Product P);
        public bool ProductExists(int id);
        public bool checkquality(int id, int qty);
    }
}

