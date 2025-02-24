namespace _26_11
{
    using System;
    using System.Collections.Generic;

    public class ReadingList
    {
        private List<string> _books = new List<string>();

        public int Count => _books.Count;

        public void AddBook(string book)
        {
            if (!string.IsNullOrWhiteSpace(book) && !_books.Contains(book))
                _books.Add(book);
            else
                Console.WriteLine("Invalid or duplicate book.");
        }

        public void RemoveBook(string book)
        {
            if (_books.Contains(book))
                _books.Remove(book);
            else
                Console.WriteLine("Book not found in the list.");
        }

        public bool ContainsBook(string book)
        {
            return _books.Contains(book);
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < _books.Count)
                    return _books[index];
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            set
            {
                if (index >= 0 && index < _books.Count)
                    _books[index] = value;
                else
                   throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
        }

        public static ReadingList operator +(ReadingList list, string book)
        {
            list.AddBook(book);
            return list;
        }

        public static ReadingList operator -(ReadingList list, string book)
        {
            list.RemoveBook(book);
            return list;
        }

        public override string ToString()
        {
            return $"Reading List: {string.Join(", ", _books)}";
        }
    }
}