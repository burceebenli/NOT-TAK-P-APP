using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTakipApp
{
    public class Todo : Not
    {
        private Öncelik öncelik;
        private DateTime bitisTarih;

        public Todo(string baslik, string icerik, DateTime tarih, DateTime bitisTarih, Öncelik öncelik)
        {
            this.öncelik = öncelik;
            this.bitisTarih = bitisTarih;
            base.Baslik = baslik;
            base.Icerik = icerik;
            base.Tarih = tarih;
        }

        public Todo(string baslik, string icerik, DateTime bitisTarih, Öncelik öncelik)
        {
            this.öncelik = öncelik;
            this.bitisTarih = bitisTarih;
            base.Baslik = baslik;
            base.Icerik = icerik;
            base.Tarih = base.getTarih();
        }
        // özel fonksiyonlar
        public override void info()
        {
            Console.WriteLine("\nBaşlık: " + base.Baslik);
            Console.WriteLine("İçerik: " + base.Icerik);
            Console.WriteLine("Öncelik Düzeyi: " + this.Oncelik);
            Console.WriteLine("Bitiş Tarih: " + tarihToString(this.BitisTarih));
            Console.WriteLine("Tarih: " + tarihToString(base.Tarih));
        }
        // getter setter
        public DateTime BitisTarih
        {
            get { return bitisTarih; }
            set { bitisTarih = value; }
        }

        public Öncelik Oncelik
        {
            get { return this.öncelik; }
            set { this.öncelik = value; }
        }
    }
}