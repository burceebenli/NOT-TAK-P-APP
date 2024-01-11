using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTakipApp
{
    public class Notdefteri : NotdefteriIslemleri
    {
        // bu classda not ve todo objeleri tutulacak ve ekle çıkar düzenle işlemleri gerçekleştirilecek!

        private List<Todo> todoList = new List<Todo>();
        private List<Not> notList = new List<Not>();

        private string defterAd;

        // yapıcı methodlar
        public Notdefteri(string defterAD)
        {
            this.defterAd = defterAD;
        }
        public Notdefteri()
        {
            this.defterAd = "Not Defterim";
        }

        // Liste işlemleri
        public override void notEkle(string baslik, string icerik)
        {
            Not not = new Not(baslik, icerik);
            this.NotList.Add(not);
        }

        public override void notCıkar(int index)
        {
            if (index >= 0 && index < this.NotList.Count)
            {
                this.NotList.RemoveAt(index);
            }
        }

        public override void todoEkle(string baslik, string icerik, DateTime bitisTarih, int öncelikDegeri)
        {
            Todo todo = new Todo(baslik, icerik, bitisTarih, (Öncelik)öncelikDegeri);
            this.TodoList.Add(todo);
        }

        public override void todoCıkar(int index)
        {
            if (index >= 0 && index < this.TodoList.Count)
            {
                this.TodoList.RemoveAt(index);
            }
        }

        public override void notGöster()
        {
            int lenght = this.NotList.Count;
            if (lenght == 0)
            {
                Console.WriteLine("Hiç notunuz yok!");
                return;
            }
            Console.WriteLine("--- Notlar ---");
            foreach (Not not in this.NotList)
            {
                int index = this.NotList.IndexOf(not);
                Console.WriteLine("-- " + Convert.ToString(index) + " --");
                not.info();
            }
        }

        public override void todoGöster()
        {
            int lenght = this.TodoList.Count;
            if (lenght == 0)
            {
                Console.WriteLine("Hiç Todonuz yok!");
                return;
            }
            Console.WriteLine("--- Todolar ---");
            foreach (Todo todo in this.TodoList)
            {
                int index = this.TodoList.IndexOf(todo);
                Console.WriteLine("-- " + Convert.ToString(index) + " --");
                todo.info();
            }
        }

        // getter setter
        public List<Todo> TodoList
        {
            get { return this.todoList; }
            set { this.todoList = value; }
        }

        public List<Not> NotList
        {
            get { return this.notList; }
            set { this.notList = value; }
        }

        public string DefterAd
        {
            get { return this.defterAd; }
            set { this.defterAd = value; }
        }
    }
}