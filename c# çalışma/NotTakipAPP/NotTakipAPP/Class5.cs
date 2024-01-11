using NotTakipApp;
using System.Security.Cryptography.X509Certificates;
using System.Media;
using System.Runtime.InteropServices;

class Program
{
    private const string DogruSifre = "12345";
    public static void Main(String[] args)
    {
        // Windows API'dan gelen metotları tanımlıyoruz.
        [DllImport("winmm.dll")]

        static extern long PlaySound(string lpszName, long hModule, long dwFlags);

        // Sabitler
        const int SND_FILENAME = 0x00020000;
        const int SND_ASYNC = 0x0001;


        // bu kısımda terminalde menü işlemleri yapılacak ve ilgili inputlar alınacak
        // eğer daha düzenli bir kodlama olsun istenirse Notdefteri yönetim gibi bir class açılıp 
        // tüm bu menü işlemleri orada erçekleştirilir ve main de sadece Notdefteri yönetim objesi oluşturulur
        // Notdefteri yönetim classında bu bahsedilen işlemleri gerçekleştiricek ana fonksiyon burada çağırılır ve olay tamamlanır....s
        {
            bool gecerliSifreGirildi = false;

            while (!gecerliSifreGirildi)
            {
                Console.WriteLine("Lütfen şifreyi giriniz:");
                string girilenSifre = Console.ReadLine();

                // Girilen şifrenin doğru olup olmadığını kontrol edin
                if (SifreDogrula(girilenSifre))
                {
                    Console.WriteLine("Giriş başarılı! Uygulamaya erişebilirsiniz.");
                    gecerliSifreGirildi = true; // Doğru şifre girildiğinde döngüden çık
                    Baslat();

                }
                else
                {
                    Console.WriteLine("Geçersiz şifre! Tekrar deneyin.");
                    // Şifre yanlış olduğunda tekrar deneme şansı vermek için döngü devam eder.
                    SesCikar();
                }
            }
        }


        static void SesCikar()
        {
            try
            {
                PlaySound(@"C:\Windows\Media\Windows Ding.wav", 0, SND_FILENAME | SND_ASYNC);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ses dosyası çalınamadı: " + ex.Message);
            }
        }


    }

    public static void Baslat()
    {
        Notdefteri notdefteri = new Notdefteri("Listem");
        Console.WriteLine("----- Todo APP -----");
        menü();

        while (true)
        {
            Console.WriteLine("\nSeçim Yapınız :");
            string input = Console.ReadLine();
            int number;
            if (!Int32.TryParse(input, out number))
            {
                Console.WriteLine("Hatalı Seçim Yaptınız");
                continue;
            }

            if (number < 0 || number > 6)
            {
                Console.WriteLine("Yanlış seçim yaptınız!");
                continue;
            }

            switch (number)
            {
                case 0:
                    Console.WriteLine("Program Kapatıldı!");
                    Environment.Exit(0);
                    break;

                case 1:
                    Console.Clear();
                    notdefteri.notGöster();
                    menü();
                    break;

                case 2:
                    Console.Clear();
                    notdefteri.todoGöster();
                    menü();
                    break;

                case 3:
                    Console.Clear();

                    Console.WriteLine("\nNot bilgilerini giriniz: ");
                    Console.WriteLine("Başlık: ");
                    string notBaslik = Console.ReadLine();
                    Console.WriteLine("İçerik: ");
                    string notIcerik = Console.ReadLine();
                    notdefteri.notEkle(notBaslik, notIcerik);

                    menü();
                    break;

                case 4:
                    Console.Clear();

                    Console.WriteLine("\nTodo bilgilerini giriniz: ");
                    Console.WriteLine("Başlık: ");
                    string todobaslik = Console.ReadLine();
                    Console.WriteLine("İçerik: ");
                    string todoIcerik = Console.ReadLine();

                    Console.WriteLine("Öncelik değeri(Düşük:0, Orta:1, Yüksek:2):");
                    int öncelikDegeri;
                    while (true)
                    {
                        öncelikDegeri = getInt();

                        if (öncelikDegeri < 0 || öncelikDegeri > 2)
                        {
                            Console.WriteLine("Öncelik değerini hatalı girdiniz! Tekrar Giriniz: ");
                            continue;
                        }
                        break;
                    }

                    Console.WriteLine("Bitiş Tarihini giriniz(Format: dd-MM-yyyy):");
                    DateTime bitisTarih = getDate();

                    notdefteri.todoEkle(todobaslik, todoIcerik, bitisTarih, öncelikDegeri);

                    Console.Clear();
                    menü();
                    break;

                case 5:
                    Console.WriteLine("-- Not Sil --\nSilinecek not indeksini giriniz: ");
                    int notIndex = getInt();
                    notdefteri.notCıkar(notIndex);

                    Console.Clear();
                    menü();
                    break;

                case 6:
                    Console.WriteLine("-- Todo Sil --\nSilinecek todo indeksini giriniz: ");
                    int todoIndex = getInt();
                    notdefteri.todoCıkar(todoIndex);

                    Console.Clear();
                    menü();
                    break;
            }
        }
    }




    public static void menü()
    {
        Console.WriteLine("\nMenü\n  1-Notları gör\n  2-Todoları gör\n  3-Not Ekle\n  4-Todo Ekle\n  5-Not Sil\n  6-Todo Sil\n  0-Çıkış Yap");
    }

    public static int getInt()
    {
        int sayı;
        while (true)
        {
            if (!Int32.TryParse(Console.ReadLine(), out sayı))
            {
                Console.WriteLine("Hatalı giriş yaptınız!\nLütfen bir sayı giriniz!");
                continue;
            }
            break;
        }
        return sayı;
    }

    public static DateTime getDate()
    {
        DateTime dt;
        while (true)
        {
            if (!DateTime.TryParse(Console.ReadLine(), out dt))
            {
                Console.WriteLine("Hatalı tarih girdiniz!\nLütfen belirtilen formatta giriniz!");
                continue;
            }
            break;
        }
        return dt;
    }

    public static bool SifreDogrula(string girilenSifre)
    {
        return girilenSifre == DogruSifre;
    }






}