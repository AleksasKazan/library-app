using System;
using System.Threading.Tasks;
using Contracts.Enums;
using Contracts.Models;
using Domain.Services;

namespace VismaBookLibraryApp
{
    public class LibraryApp
    {
        private readonly ILibraryService _libraryService;
        public LibraryApp(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public Task StartAsync()
        {
            string name;
            string author;
            Category category;
            string language;
            DateTime publicationDate;
            string isbn;
            Filter filter;
            int isAvailable;
            string readerName;
            TimeSpan period;
            DateTime returnDate;

            while (true)
            {
                Console.WriteLine("Available commands:");
                Console.WriteLine("1 - List all the books");
                Console.WriteLine("2 - Add a new book");
                Console.WriteLine("3 - Take a book");
                Console.WriteLine("4 - Return a book");
                Console.WriteLine("5 - Delete a book");
                Console.WriteLine("6 - End program");

                var chosenCommand = Console.ReadLine();
                //ConsoleKeyInfo cki;
                switch (chosenCommand)
                {
                    case "1":
                        var books = _libraryService.GetAll();
                        foreach (var book in books)
                        {
                            Console.WriteLine(book);
                        }
                        Console.WriteLine("Filter by:");
                        Console.WriteLine("0 - author");
                        Console.WriteLine("1 - category");
                        Console.WriteLine("2 - language");
                        Console.WriteLine("3 - ISBN");
                        Console.WriteLine("4 - book name");
                        Console.WriteLine("5 - available / taken books");
                        Console.WriteLine("6 - Exit");

                        Enum.TryParse(Console.ReadLine(), out filter);
                        switch (filter)
                        {
                            case Filter.Author:
                                Console.WriteLine("Enter Author name:");
                                author = Console.ReadLine();
                                books = _libraryService.GetAllByAuthor(author);
                                foreach (var book in books)
                                {
                                    Console.WriteLine(book);
                                }
                                break;
                            case Filter.Category:
                                Console.WriteLine("Select book Category (0 - Fiction, 1 - Nonfiction, 2 - Teens, 3 - Children):");
                                Enum.TryParse(Console.ReadLine(), out category);
                                books = _libraryService.GetAllByCategory(category);
                                foreach (var book in books)
                                {
                                    Console.WriteLine(book);
                                }
                                break;
                            case Filter.Language:
                                Console.WriteLine("Enter Language:");
                                language = Console.ReadLine();
                                books = _libraryService.GetAllByLanguage(language);
                                foreach (var book in books)
                                {
                                    Console.WriteLine(book);
                                }
                                break;
                            case Filter.ISBN:
                                Console.WriteLine("Enter ISBN:");
                                isbn = Console.ReadLine();
                                books = _libraryService.GetAllByIsbn(isbn);
                                foreach (var book in books)
                                {
                                    Console.WriteLine(book);
                                }
                                break;
                            case Filter.Name:
                                Console.WriteLine("Enter book Name:");
                                name = Console.ReadLine();
                                books = _libraryService.GetAllByName(name);
                                foreach (var book in books)
                                {
                                    Console.WriteLine(book);
                                }
                                break;
                            case Filter.Available:
                                Console.WriteLine("Enter 0 - for taken or 1 - for available books:");
                                isAvailable = Convert.ToInt32(Console.ReadLine());
                                books = isAvailable == 0 ? _libraryService.GetAllByIsAvailable(false) : _libraryService.GetAllByIsAvailable(true);
                                foreach (var book in books)
                                {
                                    Console.WriteLine(book);
                                }
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter book Name:");
                        name = Console.ReadLine();

                        Console.WriteLine("Enter book Author:");
                        author = Console.ReadLine();

                        Console.WriteLine("Select book Category (0 - Fiction, 1 - Nonfiction, 2 - Teens, 3 - Children):");
                        Enum.TryParse(Console.ReadLine(), out category);

                        Console.WriteLine("Enter book Language:");
                        language = Console.ReadLine();

                        Console.WriteLine("Enter book Publication date:");
                        DateTime.TryParse(Console.ReadLine(), out publicationDate);

                        Console.WriteLine("Enter book ISBN (correct format: 13 grouped and slashes separated digits):");
                        isbn = Console.ReadLine();

                        _libraryService.Create(new BookRequestModel
                        {
                            Name = name,
                            Author = author,
                            Category = category,
                            Language = language,
                            PublicationDate = publicationDate,
                            ISBN = isbn,
                            IsAvailable = true
                        });

                        break;
                    case "3":
                        Console.WriteLine("Enter book ISBN");
                        isbn = Console.ReadLine();
                        Console.WriteLine("Enter reader Name:");
                        readerName = Console.ReadLine();
                        Console.WriteLine("Enter reading Period days (max 60 days):");
                        TimeSpan.TryParse(Console.ReadLine(), out period);
                        returnDate = DateTime.Now.Add(period);
                        _libraryService.Take(isbn, readerName, returnDate);
                        Console.WriteLine(period);
                        break;
                    case "4":
                        Console.WriteLine("Enter book ISBN");
                        isbn = Console.ReadLine();
                        Console.WriteLine("Enter reader's Name:");
                        readerName = Console.ReadLine();
                        _libraryService.Return(isbn, readerName);
                        break;
                    case "5":
                        Console.WriteLine("Enter book ISBN:");
                        isbn = Console.ReadLine();
                        _libraryService.Delete(isbn);
                        break;
                    case "6":
                        break;
                }
            }
        }

    }
}
