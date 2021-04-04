using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssign
{
    class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {BirthDate}";
        }

        public static bool operator ==(Author a1, Author a2)
        {
            return a1.Id == a2.Id && a1.Name == a2.Name && a1.BirthDate == a2.BirthDate;
        }

        public static bool operator !=(Author a1, Author a2)
        {
            return !(a1==a2);
        }
    }
}
