using System;
using System.Collections.Generic;
using System.Linq;
using RMQueryDemo.Helpers;
using RMQueryDemo.Models;
using RMQueryDemo.Parameters;
using RMQueryDemo.Services.Interfaces;

namespace RMQueryDemo.Services
{
    public class BooksService : IBooksService
    {
        IEnumerable<Book> books = new Book[] {

            new Book(Guid.NewGuid(), "Something Happened", "Joseph Heller", new DateTime(2021, 05, 01, 15, 30, 0)),
            new Book(Guid.NewGuid(), "In Search of Lost Time", "Marcel Proust", new DateTime(2021, 01, 20, 10, 15, 0)),
            new Book(Guid.NewGuid(), "American Pastoral", "Philip Roth", new DateTime(2010, 02, 03, 21, 10, 0)),
            new Book(Guid.NewGuid(), "Catch 22", "Joseph Heller", new DateTime(2010, 02, 03, 21, 10, 0)),
         };

        public PagedList<Book> GetBooks(BooksParameters parameters)
        {

            var query = books.AsQueryable(); // context query for db

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                query = query.Where(x => 
                    x.Title.ToLowerInvariant().Contains(parameters.SearchQueryLowerCase) ||
                    x.Author.ToLowerInvariant().Contains(parameters.SearchQueryLowerCase)
                    );
            }

            if (parameters.DateModifiedGreaterThan.HasValue || parameters.DateModifiedLessThan.HasValue)
            {
                if (parameters.DateModifiedGreaterThan.HasValue && !parameters.DateModifiedLessThan.HasValue)
                    query = query.Where(x => x.DateModified > parameters.DateModifiedGreaterThan.Value);

                if (!parameters.DateModifiedGreaterThan.HasValue && parameters.DateModifiedLessThan.HasValue)
                    query = query.Where(x => x.DateModified < parameters.DateModifiedLessThan.Value);

                if (parameters.DateModifiedGreaterThan.HasValue && parameters.DateModifiedLessThan.HasValue)
                    query = query.Where(x => x.DateModified > parameters.DateModifiedGreaterThan.Value && x.DateModified < parameters.DateModifiedLessThan.Value);
            }

            var results = PagedList<Book>.Create(query, parameters.Page, parameters.rpp);
            return results;

        }
    }




}