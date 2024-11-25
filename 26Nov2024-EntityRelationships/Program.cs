

// Create an author
var author = new Author(1, "J.K. Rowling", "British author of the Harry Potter series");

// Create books authored by the author
var book1 = new Book("9780747532699", "Harry Potter and the Philosopher's Stone", author);
var book2 = new Book("9780747538493", "Harry Potter and the Chamber of Secrets", author);

// Add books to the author's collection
author.AddBook(book1);
author.AddBook(book2);

// Create a library member
var member = new Member(101, "John Doe", "john.doe@example.com");

// Member borrows a book
member.BorrowBook(book1);

// Output results
Console.WriteLine($"Author: {author.Name}");
Console.WriteLine("Books written by the author:");
foreach (var book in author.Books)
{
    Console.WriteLine($"- {book.Title}");
}

Console.WriteLine($"\nMember: {member.Name} has borrowed:");
foreach (var borrowedBook in member.BorrowedBooks)
{
    Console.WriteLine($"- {borrowedBook.Title}");
}