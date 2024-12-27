using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_27._12._24___2_
{
    public class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Назва: {Title}, Автор: {Author}, Рік публікації: {PublicationYear}");
        }
    }

    public interface IBorrowable
    {
        void BorrowItem();
        void ReturnItem();
    }

    public interface IReadableOnline
    {
        void ReadOnline();
    }

    public class Book : LibraryItem, IBorrowable
    {
        private bool isBorrowed = false;

        public void BorrowItem()
        {
            if (isBorrowed)
            {
                Console.WriteLine($"Книга \"{Title}\" вже позичена.");
            }
            else
            {
                isBorrowed = true;
                Console.WriteLine($"Книга \"{Title}\" успішно позичена.");
            }
        }
        public void ReturnItem()
        {
            if (isBorrowed)
            {
                isBorrowed = false;
                Console.WriteLine($"Книга \"{Title}\" успішно повернута.");
            }
            else
            {
                Console.WriteLine($"Книга \"{Title}\" не була позичена.");
            }
        }
    }
    public class Magazine : LibraryItem, IReadableOnline
    {
        public void ReadOnline()
        {
            Console.WriteLine($"Читаємо журнал \"{Title}\" онлайн.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var books = new List<Book>
        {
            new Book { Title = "Гаррі Потер", Author = "Дж.К. Роулінг", PublicationYear = "2001" },
            new Book { Title = "Крик диявола", Author = "Вілбур Сміт", PublicationYear = "1968" },
            new Book { Title = "Золота Шахта", Author = "Вілбур Сміт", PublicationYear = "1970" }
        };

            var magazines = new List<Magazine>
        {
            new Magazine { Title = "48 Законів Влади", Author = "Роберт Грін", PublicationYear = "1998" }
        };

            foreach (var book in books)
            {
                book.DisplayInfo();
                Console.WriteLine();
                book.BorrowItem();
                book.ReturnItem();
                Console.WriteLine();
            }

            foreach (var magazine in magazines)
            {
                magazine.DisplayInfo();
                magazine.ReadOnline();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}