using OrnekSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Models
{
    public class Cart
    {
        private List<Cartline> _cartLines = new List<Cartline>(); //kullanıcıya özel cart oluşturuldu
        public List<Cartline> CartLines
        {
            get { return _cartLines; }
        }
        public void AddProduct(product product ,int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.product.Id == product.Id);  //sepetdeki ürünlerin kontrolü
           if (line==null)        //ürün sepetde yok ise sepete ekle
            {
                _cartLines.Add(new Cartline() { product=product ,Quantity=quantity});
            }
            else //sepette eklemek istediğimiz ürün zaten var ise ürünü artırsın 
            {
                line.Quantity += quantity;
            }
                       
        }
        public void DeleteProduct (product product) //sepetten ürün silme işlemi
        {
            _cartLines.RemoveAll(i => i.product.Id == product.Id);
        }
        public double Total()          //sepetdeki ürünlerin toplam fiyatını hesaplama işlemi
        {
            return _cartLines.Sum(i => i.product.Price * i.Quantity);
        }
        public void Clear()  //tüm ürünleri sil işlemi
        {
            _cartLines.Clear(); 
        }
            }

    public class Cartline
    {
        public  product product { get; set; }
        public int Quantity { get; set; } //sepetde ki ürün adedi
    }
}
