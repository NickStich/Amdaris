using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssign
{
    class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Author Author { get; set; }       
        public List<Category> Categories { get; set; } = new List<Category>();


        public override string ToString()
        {
            string categories = "";
            foreach (Category cat in Categories)
            {
                categories += ", "+cat;
            }
            if (categories.Length == 0)
            {
                return $"{ Id} - { Title} - {PublishDate} - {Author.Name}";
            }
           return $"{ Id} - { Title} - {PublishDate} - {Author.Name} - "+categories.Substring(2) ;
        }
    }

    public enum Category
    {
        Fantasy,
        SF,
        Mystery,
        Thriller,
        Romance,
        Westerns,
        Contemporary,
        Drama
    }
}
