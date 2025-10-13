

using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class BookService
    {
        static List<Book> Books { get; }
        static int lastId = 0;
        static BookService()
        {
            GetBooks();
        }

        private static void GetBooks()
        {
            // make call to db to retrieve books
            Book newBook = new()
            {
                Id = lastId++,
                Title = "testTitle",
                Rating = 3,
                Review = "pretty good",
            };
            Books.Add(newBook);
        }

        public static List<Book> GetAll() => Books;

        public static Book? Get(int id) => Books.FirstOrDefault(b => b.Id == id);

        public static void Add(Book book)
        {
            book.Id = lastId++;
            Books.Add(book);
        }

        public static void Delete(int id)
        {
            var book = Get(id);
            if (book is null)
            {
                return;
            }
            Books.Remove(book);
        }

        public static void Update(Book toBeUpdated)
        {
            var bookIndex = Books.FindIndex(b => b.Id == toBeUpdated.Id);
            if (bookIndex == -1)
            {
                return;
            }
            Books[bookIndex] = toBeUpdated;
        }
    }
}
