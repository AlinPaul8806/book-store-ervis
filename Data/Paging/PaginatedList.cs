using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        //constructor:
        public PaginatedList(List<T> items, int itemsCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            //for example, you have 8 items, so the number of pages will be 2.
            TotalPages = (int)Math.Ceiling(itemsCount / (double)pageSize);

            this.AddRange(items);
        }

        //these 2 props are used to determine if you display the previous and next page icons
        public bool HasPreviousPage
        {
            get 
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage 
        {
            get
            { 
                return PageIndex < TotalPages;
            }
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        { 
            var count = source.Count();
            /*explanation: 
             you have 12 items and the page is 5 items "long". so, you will have 3 pages
             when you take the second page --> source.Skip(page index - 1), meaning 2-1 = 1 * 5 = 5. 
            .Take(pageSize). ToList = skip the first 5 results, take the next 5 and put them in the page
             */
            var items = source.Skip((pageIndex -1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize); 
        }
    }
}
