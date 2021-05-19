using System;

namespace RMQueryDemo.Models
{
    public class Book
    {
        public Book(Guid bookGuid, string title, string author, DateTime dateModified)
        {
            this.BookGuid = bookGuid;
            this.Title = title;
            this.Author = author;
            DateModified = dateModified;
        }
        
        public Guid BookGuid { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime DateModified { get; set; }

    }
}