using System.Collections.Generic;
using RMQueryDemo.Helpers;
using RMQueryDemo.Models;
using RMQueryDemo.Parameters;

namespace RMQueryDemo.Services.Interfaces
{
    public interface IBooksService
    {
        PagedList<Book> GetBooks(BooksParameters parameters);
    }
}