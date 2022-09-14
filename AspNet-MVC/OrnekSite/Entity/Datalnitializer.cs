using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class Datalnitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {Name="KAMERA",Description="KAMERA ÜRÜNLERİ" },
                new Category() {Name="TELEFON",Description="TELEFON ÜRÜNLERİ" },
                new Category() {Name="BİLGİSAYAR",Description="BİLGİSAYAR ÜRÜNLERİ" }
            };
            foreach (var kategori in kategoriler)
            {
                context.Categoris.Add(kategori);
            }
            context.SaveChanges();
            var urunler = new List<product>()
            {
                new product() {Name="Canon",Description="kamera ürünleri",Price=2500 ,Stock=125,IsHome=true,IsApproved=true,IsFeatured=false,Slider=true,CategoryId=1,Image="1.jpg" },
                new product() {Name="Asus",Description="bilgisayar ürünleri",Price=2000 ,Stock=100,IsHome=true,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=3,Image="2.jpg" },
                new product() {Name="Lenova",Description="bilgisayar ürünleri",Price=3500 ,Stock=50,IsHome=false,IsApproved=true,IsFeatured=true,Slider=false,CategoryId=3,Image="3.jpg" },
                new product() {Name="Samsung 6S",Description="telefon ürünleri",Price=5000,Stock=150,IsHome=true,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=2,Image="4.jpg" }
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }

    }
}