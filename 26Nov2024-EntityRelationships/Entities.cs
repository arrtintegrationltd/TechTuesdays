using System;
using System.Collections.Generic;


    // Member Entity
    public class Member
    {
        public int MembershipId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        private readonly List<Book> _borrowedBooks = new List<Book>();
        public IReadOnlyCollection<Book> BorrowedBooks => _borrowedBooks.AsReadOnly();

        public Member(int membershipId, string name, string email)
        {
            MembershipId = membershipId;
            Name = name;
            Email = email;
        }

        public void BorrowBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (!_borrowedBooks.Contains(book))
            {
                _borrowedBooks.Add(book);
                book.AddBorrowingMember(this);
            }
        }
    }

    // Book Entity
    public class Book
    {
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public Author Author { get; private set; }

        private readonly List<Member> _borrowingMembers = new List<Member>();
        public IReadOnlyCollection<Member> BorrowingMembers => _borrowingMembers.AsReadOnly();

        public Book(string isbn, string title, Author author)
        {
            ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        internal void AddBorrowingMember(Member member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));
            if (!_borrowingMembers.Contains(member))
            {
                _borrowingMembers.Add(member);
            }
        }
    }

// Author Entity
public class Author
{
    public int AuthorId { get; private set; }
    public string Name { get; private set; }
    public string Bio { get; private set; }

    private readonly List<Book> _books = new List<Book>();
    public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    public Author(int authorId, string name, string bio)
    {
        AuthorId = authorId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Bio = bio;
    }

    public void AddBook(Book book)
    {
        if (book == null) throw new ArgumentNullException(nameof(book));
        if (!_books.Contains(book))
        {
            _books.Add(book);
        }
    }
}
