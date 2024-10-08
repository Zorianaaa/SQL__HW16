using System;
using System.Linq;
using SQL_library_HW16; 
namespace LibraryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryDbContext())
            {
                var books = context.Books.ToList();
                foreach (var book in books)
                {
                    Console.WriteLine($"Назва: {book.Title}, Автор: {book.Country}, Рік: {book.Year}");
                }
            }
        }

        public void Register()
        {
            Console.WriteLine("Введіть новий логін:");
            string login = Console.ReadLine();

            Console.WriteLine("Введіть новий пароль:");
            string password = Console.ReadLine();

            Console.WriteLine("Введіть email:");
            string email = Console.ReadLine();

            using (var context = new LibraryDbContext())
            {
                var newReader = new Reader { Login = login, Password = password, Email = email };
                context.Readers.Add(newReader);
                context.SaveChanges();
                Console.WriteLine("Реєстрація завершена успішно.");
            }
        }

        public void Login()
        {
            Console.WriteLine("Введіть логін:");
            string login = Console.ReadLine();

            Console.WriteLine("Введіть пароль:");
            string password = Console.ReadLine();

            using (var context = new LibraryDbContext())
            {
                var librarian = context.Librarians.FirstOrDefault(l => l.Login == login && l.Password == password);
                var reader = context.Readers.FirstOrDefault(r => r.Login == login && r.Password == password);

                if (librarian != null)
                {
                    Console.WriteLine("Успішний вхід як бібліотекар.");
                }
                else if (reader != null)
                {
                    Console.WriteLine("Успішний вхід як читач.");
                }
                else
                {
                    Console.WriteLine("Невірний логін або пароль.");
                }
            }
        }
    }
}
