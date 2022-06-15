using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = books.OrderBy(x => x, new BookComparator()).ToList();
        }

        public List<Book> Books { get; }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                yield return Books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        //public IEnumerator<Book> GetEnumerator()
        //{
        //    return new LibraryIterator(Books);
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return new LibraryIterator(Books);
        //}

        //class LibraryIterator : IEnumerator<Book>
        //{
        //    private List<Book> books;
        //    private int position = -1;

        //    public LibraryIterator(List<Book> books)
        //    {
        //        this.books = books;

        //        Reset();
        //    }

        //    public Book Current => this.books[position];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {
        //        //not needed
        //    }

        //    public bool MoveNext()
        //    {
        //        this.position++;

        //        return position < books.Count;
        //    }

        //    public void Reset()
        //    {
        //        this.position = -1;
        //    }
        //}
    }
}
