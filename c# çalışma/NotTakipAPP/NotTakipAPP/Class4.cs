using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTakipApp
{
    public class Not
    {
        private string baslik;
        private string icerik;
        private DateTime tarih;

        public Not(string baslik, string icerik, DateTime tarih)
        {
            this.baslik = baslik;
            this.icerik = icerik;
            this.tarih = tarih;
        }

        public Not(string baslik, string icerik)
        {
            this.baslik = baslik;
            this.icerik = icerik;
            this.tarih = this.getTarih();
        }

        public Not()
        {
            this.baslik = "";
            this.icerik = "";
            this.tarih = this.getTarih();
        }

        // özel fonksiyonlar
        public DateTime getTarih()
        {
            return DateTime.Now;
        }

        public static string tarihToString(DateTime tarih)
        {
            return tarih.ToString("dd-MM-yyyy");
        }

        public virtual void info()
        {
            Console.WriteLine("\nBaşlık: " + this.Baslik);
            Console.WriteLine("İçerik: " + this.Icerik);
            Console.WriteLine("Tarih: " + tarihToString(this.Tarih));
        }

        // getter setter
        public string Baslik
        {
            get { return this.baslik; }
            set { this.baslik = value; }
        }

        public string Icerik
        {
            get { return this.icerik; }
            set { this.icerik = value; }
        }

        public DateTime Tarih
        {
            get { return this.tarih; }
            set { this.tarih = value; }
        }
    }
}