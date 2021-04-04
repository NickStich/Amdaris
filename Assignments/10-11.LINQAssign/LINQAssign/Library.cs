using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssign
{
    class Library
    {
        private List<Book> _booksInLibrary;

        public Library()
        {
            _booksInLibrary = new List<Book>();
        }

        
        public void AddBook(Book book) // 1. Adding a book to the collection.
        {
            _booksInLibrary.Add(book);
        }

        public void RemoveBookById(int Id) //2. Removing a book from the collection by ID.
        {
            foreach (Book book in _booksInLibrary)
            {
                if(book.Id == Id)
                {
                    _booksInLibrary.Remove(book);
                }
            }
        }

        public List<Book> GetAllBooks() //3. Get the list of all books.
        {
            return _booksInLibrary;
        }

        public void CheckingBooksStock() // A method that return existing books in stock.
        {
            foreach (Book book in GetAllBooks())
            {
                Console.WriteLine(book.ToString());
            }
        }

        public List<Book> BooksPublishedAfterEighty(List<Book> bookList) //4. Getting the list of all books published after 1980
        {
            var filtredList = bookList.Where(book => book.PublishDate.Year >= 1980);
            return filtredList.ToList();
        }

        public List<Book> BooksWithDrama(List<Book> bookList) //5. Getting the list of all books with one of the categories: "drama"
        {
            var filtredList = bookList.Where(book => book.Categories.Contains(Category.Drama));
            return filtredList.ToList();
        }

        public List<Author> GetAllAuthors(List<Book> bookList) // 6. Getting the names of all authors . 
        {
            var authorList = new List<Author>();
            foreach (Book book in bookList)
            {
                authorList.Add(book.author);
            }
            var distinctAuthorList = authorList.Distinct().ToList();
            return distinctAuthorList;
        }

        public List<Author> GetAuthorsManyPublish(List<Book> bookList, List<Author> authorList) // 6. Getting the names of all authors that have published at least 3 books.
        {
            var filtredList = new List<Author>();

            foreach (Author author in authorList)
            {
                int count = 0;
                foreach (Book book in bookList)
                {
                    if (author == book.author)
                    {
                        count++;
                    }
                }
                if (count >= 3)
                {
                    filtredList.Add(author);
                }
            }
            return filtredList;
        }

        public List<Author> GetAuthorsByYearAndBooks(List<Book> bookList, List<Author> authorList) //Getting the names of all authors that are born before 1990 and have written at least 2 books of category "science-fiction"
        {
            var filtredList = new List<Author>();
            foreach (Author author in authorList)
            {
                int count = 0;
                foreach (Book book in bookList)
                {
                    if (author.BirthDate.Year<=1990 && author == book.author)
                    {
                        count++;
                    }
                }
                if (count >= 2)
                {
                    filtredList.Add(author);
                }
            }
            return filtredList;
        }

        public IEnumerable<IGrouping<int, Book>> GroupingBooksByDecade(List<Book> bookList) //A method that returns an IGrouping of Books grouped by the decade they were published in.
        {
            var groupedList = bookList.GroupBy(b => (b.PublishDate.Year % 100)/10);
            return groupedList;
        }

    }
}
