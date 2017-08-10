using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    private readonly SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly IEnumerable<Book> books;
        private int index;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        object IEnumerator.Current => this.Current;

        public Book Current => this.books.ElementAt(this.index);

        public void Dispose()
        {
        }

        public void Reset()
        {
            this.index = -1;
        }

        public bool MoveNext()
        {
            return (this.index += 1) < this.books.Count();
        }
    }
}