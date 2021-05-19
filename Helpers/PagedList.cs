using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace RMQueryDemo.Helpers
{
public class PagedList<T> : List<T>
    {

        public int CurrentPage { get; private set; }

        public int? TotalPages { get; private set; }

        public int? Rpp { get; private set; }

        public int TotalCount { get; private set; }

        public bool HasPrevious
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        public PagedList(List<T> items, int count, int pageNumber, int? rpp)
        {
            if (pageNumber < 1)
                pageNumber = 1;

            if (rpp < 0)
                rpp = 1;

            TotalCount = count;
            Rpp = rpp;
            CurrentPage = this.Rpp > 0 ? pageNumber : 0;

            if (rpp > 0)
                TotalPages = (int)Math.Ceiling(count / (double)rpp);
            else
                TotalPages = null;
            AddRange(items);
        }

        ///<summary>
        ///Inherits from List, this will run the query.
        ///</summary>
        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int? rpp)
        {
            if (pageNumber < 0)
                pageNumber = 1;

            if (rpp < 0)
                rpp = 1;

            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * rpp.Value).Take(rpp.Value);
            return new PagedList<T>(items.ToList(), count, pageNumber, rpp.Value);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int? rpp)
        {
            if (pageNumber < 0)
                pageNumber = 1;

            if (rpp < 0)
                rpp = 1;

            var count = source.Count();
            var query = source.Skip((pageNumber - 1) * rpp.Value).Take(rpp.Value);
            var items = await query.ToListAsync();
            return new PagedList<T>(items, count, pageNumber, rpp.Value);
        }

        public static PagedList<T> EmptyPagedList()
        {
            return new PagedList<T>(new List<T>(), 0, 0, 0);
        }

    }
}