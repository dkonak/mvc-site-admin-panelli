using OrnekSite.Entity;
using OrnekSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekSite.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext(); //veritabanı ile bağlantı sağlama 
        // GET: Cart
        public ActionResult Index()
        {
            return View( GetCart());
        }
        public void SaveOrder(Cart cart ,ShippingDetails model)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Adres = model.Adres;
            order.Sehir = model.Şehir;
            order.Semt = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.PostaKodu;
            order.OrdeLines = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.product.Price;
                orderline.ProductId = item.product.Id;
                order.OrdeLines.Add(orderline);
            }
            db.Orders.Add(order); //siparişleri veritabanındaki orders a ekleyecktir
            db.SaveChanges(); //siparişleri kaydeder
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();
            if (cart.CartLines.Count==0) //sepetde herhangi bir ürün yok ise uyarı ver
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde ürün bulunmamaktadır");
            }
            if (ModelState.IsValid)  //sepete ürün var ve kullanıcı zorunlu adres bilgilerini girip siparişi tamamlayınca sepet boşalsın
            {
                SaveOrder(cart, model); //siparişleri veritabanına kaydetmiş olur
                cart.Clear();
                return View("SiparisTamamlandi");
            }
            else // sipariş onayı için kullanıcı gerekli alanları doldurmadıysa
            {
                return View(model);
            }
          
        }


        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public PartialViewResult Summary1()
        {
            return PartialView(GetCart());
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id); //silinecek ürün bulunur
            if (product!=null) //silinecek ürün sepet içerisindemi kontrol et öyle ise sil
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index"); //silme işleminden sonra ındex sayfasına dön
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product!=null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public Cart  GetCart()  //kullanıcıya ait özel cart
        {
            var cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
      }
}