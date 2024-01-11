using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTakipApp
{
    public abstract class NotdefteriIslemleri
    {
        // notdefteri classında yapılacak olan fonksiyonların soyut halleri burada yazılacak!

        //liste işlemleri
        public abstract void notEkle(string baslik, string icerik);

        public abstract void notCıkar(int index);

        public abstract void todoEkle(string baslik, string icerik, DateTime bitisTarih, int öncelikDegeri);

        public abstract void todoCıkar(int index);

        public abstract void notGöster();

        public abstract void todoGöster();

    }
}