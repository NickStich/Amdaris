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
        private List<Author> _authors;
        public Library()
        {
            _booksInLibrary = new List<Book>();
            _authors = _booksInLibrary.Select(b => b.Author).Distinct().ToList();
        }

        public void AddBook(Book book) // 1. Adding a book to the collection.
        {
            _booksInLibrary.Add(book);
        }

        public void RemoveBookById(int Id) //2. Removing a book from the collection by ID.
        {
            _booksInLibrary.RemoveAll(b => b.Id == Id);
        }

        public List<Book> GetAllBooks() //3. Get the list of all books.
        {
            return _booksInLibrary;
        }

        public List<Book> BooksPublishedAfterGivenYear(int year) //4. Getting the list of all books published after 1980
        {
            var filtredList = _booksInLibrary.Where(book => book.PublishDate.Year >= year);
            return filtredList.ToList();
        }

        public List<Book> BooksWithCategory(Category category) //5. Getting the list of all books with one of the categories: "drama"
        {
            var filtredList = _booksInLibrary.Where(book => book.Categories.Contains(category));
            return filtredList.ToList();
        }

        public List<Author> GetAllAuthors() // 6. Getting the names of all authors . 
        {
            return _authors;
        }

        public List<string> GetAuthorsManyPublish(int manyThan) // 6. Getting the names of all authors that have published at least 3 books.
        {
            var result = _booksInLibrary.GroupBy(b => b.Author.Id).Where(x => x.Count() >= manyThan).Select(x => x.First().Author.Name).ToList();
            return result;
        }

        public List<Author> GetAuthorsByYearAndBooks(int year, Category category, int howManyBooks) // 7.Getting the names of all authors that are born before 1990 and have written at least 2 books of category "science-fiction"
        {
            var result = _booksInLibrary.GroupBy(a => a.Author.Id)
                .Where(x => x.First().Author.BirthDate.Year <= year && x.Where(b => b.Categories.Contains(category))
                .Count() >= howManyBooks).Select(y=>y.First().Author)
                .ToList();
            return result;
        }

        public IEnumerable<IGrouping<int, Book>> GroupingBooksByDecade(List<Book> bookList) // 8.A method that returns an IGrouping of Books grouped by the decade they were published in.
        {
            var groupedList = bookList.GroupBy(b => (b.PublishDate.Year /10));
            return groupedList;
        }

    }
}
