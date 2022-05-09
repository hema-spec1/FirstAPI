using FirstAPI.Data;
using FirstAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Repository
{
    public class ProdRepo : IProduct
    {
        public readonly ProductContext _context;
        public ProdRepo(ProductContext Context)
        {
            _context = Context;

        }
        public Product AddNewProduct(Product p)
        {
            _context.Product.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void DeleteProduct(int id)
        {
            Product p = _context.Product.Find(id);
            _context.Product.Remove(p);
            _context.SaveChanges();

        }


        public Product GetProductById(int id)
        {
            return (_context.Product.Find(id));
        }

        public List<Product> GetProducts()
        {
            return _context.Product.ToList();
        }

        public Product UpdateProduct(int id, Product P)
        {
            //Product p1 = _context.Product.Find(id);
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.Entry(P).State = EntityState.Modified;
            _context.SaveChanges();
            return P;

        }
        public bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.PrId == id);
        }
        public bool checkquality(int id, int qty)
        {
            Product p = GetProductById(id);
            int qoh = p.QtyonHand;
            if (qty > qoh)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
