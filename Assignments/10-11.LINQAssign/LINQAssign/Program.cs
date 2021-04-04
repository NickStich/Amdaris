using System;
using System.Collections.Generic;
using System.Linq;
using static LINQAssign.Book;

namespace LINQAssign
{
    class Program
    {
        static void Main(string[] args)
        {
            var myLibrary = new Library();

            var martin = new Author { Id = 1, Name = "Martin", BirthDate = new DateTime(1948, 12, 04) };
            var tolkien = new Author { Id = 2, Name = "Tolkien", BirthDate = new DateTime(1928, 10, 12) };
            var bradbury = new Author { Id = 3, Name = "Bradbury", BirthDate = new DateTime(1920, 08, 22) };
            var king = new Author { Id = 4, Name = "King", BirthDate = new DateTime(1947, 09, 21) };
            var tolstoy = new Author { Id = 5, Name = "Tolstoy", BirthDate = new DateTime(1828, 11, 20) };

            var book1 = new Book {
                Id = 1,
                Title = "The song of ice and fire",
                author = martin,
                PublishDate = new DateTime(1995, 08, 13),
                Categories = { Category.Fantasy, Category.Mystery, Category.SF, Category.Drama}
            };
            var book2 = new Book
            {
                Id = 2,
                Title = "The Hobbit",
                author = tolkien,
                PublishDate = new DateTime(1972, 09, 12),
                Categories = { Category.Fantasy }
            };
            var book3 = new Book
            {
                Id = 3,
                Title = "Fahrenheit 451",
                author = bradbury,
                PublishDate = new DateTime(1953, 01, 01),
                Categories = { Category.SF }
            };
            var book4 = new Book
            {
                Id = 4,
                Title = "The Halloween Tree",
                author = bradbury,
                PublishDate = new DateTime(1972, 01, 01),
                Categories = { Category.SF }
            };
            var book5 = new Book
            {
                Id = 5,
                Title = "Let's All Kill Constance ",
                author = bradbury,
                PublishDate = new DateTime(2006, 01, 01),
                Categories = { Category.SF }
            };
            var book6 = new Book
            {
                Id = 6,
                Title = "Farewell Summer",
                author = bradbury,
                PublishDate = new DateTime(2002, 01, 01),
                Categories = { Category.SF }
            };
            var book7 = new Book
            {
                Id = 7,
                Title = "The mobile",
                author = king,
                PublishDate = new DateTime(2009, 01, 01),
                Categories = { Category.Mystery, Category.SF, Category.Drama }
            };
            var book8 = new Book
            {
                Id = 8,
                Title = "Revival",
                author = king,
                PublishDate = new DateTime(2014, 01, 01),
                Categories = { Category.Mystery, Category.Thriller, Category.SF }
            };
            var book9 = new Book
            {
                Id = 9,
                Title = "Later",
                author = king,
                PublishDate = new DateTime(2021, 01, 01),
                Categories = { Category.Mystery, Category.Thriller, Category.SF }
            };
            var book10 = new Book
            {
                Id = 10,
                Title = "Anna Karenina",
                author = tolstoy,
                PublishDate = new DateTime(1877, 01, 01),
                Categories = { Category.Drama }
            };

            myLibrary.AddBook(book1);
            myLibrary.AddBook(book2);
            myLibrary.AddBook(book3);
            myLibrary.AddBook(book4);
            myLibrary.AddBook(book5);
            myLibrary.AddBook(book6);
            myLibrary.AddBook(book7);
            myLibrary.AddBook(book8);
            myLibrary.AddBook(book9);
            myLibrary.AddBook(book10);

            myLibrary.CheckingBooksStock();

            Console.WriteLine("After '80");
            List<Book> filtredBooksEighty = myLibrary.BooksPublishedAfterEighty(myLibrary.GetAllBooks());
            foreach(Book book in filtredBooksEighty)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("From drama");
            List<Book> filtredBooksDrama = myLibrary.BooksWithDrama(myLibrary.GetAllBooks());
            foreach (Book book in filtredBooksDrama)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("Many than 3");
            List<Author> filtredAutors = myLibrary.GetAuthorsManyPublish(myLibrary.GetAllBooks(), myLibrary.GetAllAuthors(myLibrary.GetAllBooks()));
            foreach (Author author in filtredAutors)
            {
                Console.WriteLine(author.ToString());
            }

            Console.WriteLine("Many than 2 and born before 1990");
            List<Author> filtredOldAutors = myLibrary.GetAuthorsByYearAndBooks(myLibrary.GetAllBooks(), myLibrary.GetAllAuthors(myLibrary.GetAllBooks()));
            foreach (Author author in filtredOldAutors)
            {
                Console.WriteLine(author.ToString());
            }

            Console.WriteLine("Books grouped by the decade");
            IEnumerable<IGrouping<int, Book>> groupedBooks = myLibrary.GroupingBooksByDecade(myLibrary.GetAllBooks());
            foreach (var group in groupedBooks)
            {
                Console.WriteLine(group.Key);
                foreach (Book book in group)
                {
                    Console.WriteLine($"\t{book.ToString()}");

                }
            }
        }

        
    }
}
