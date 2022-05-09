using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Model
{
    public class Product
    {
        [Key]
        public int PrId { get; set; }
        public string Prname { get; set; }
        public int QtyonHand { get; set; }
        public float Price { get; set; }
        public Product()
        {

        }
        public Product(int Prid,String Pname,int qoh,float price)
        {
            PrId = Prid;
            Prname = Pname;
            QtyonHand = qoh;
            Price = price;


        }
    }
}
