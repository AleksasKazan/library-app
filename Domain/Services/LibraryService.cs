using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Enums;
using Contracts.Models;
using Persistence.Models.WriteModels;
using Persistence.Repositories;

namespace Domain.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public IEnumerable<BookResponseModel> GetAll()
        {
            var books = _libraryRepository.GetAll();

            return books.Select(book => new BookResponseModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                ReturnDate = book.ReturnDate,
                TakeDate = book.TakeDate              
            });
        }

        public IEnumerable<BookResponseModel> GetAllByAuthor(string author)
        {
            var books = _libraryRepository.GetAll();
            var updatedBooks = books.Where(book => book.Author == author);

            return updatedBooks.Select(book => new BookResponseModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                TakeDate = book.TakeDate,
                ReturnDate = book.ReturnDate
            });
        }public IEnumerable<BookResponseModel> GetAllByCategory(Category category)
        {
            var books = _libraryRepository.GetAll();
            var updatedBooks = books.Where(book => book.Category == category);

            return updatedBooks.Select(book => new BookResponseModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                TakeDate = book.TakeDate,
                ReturnDate = book.ReturnDate
            });
        }public IEnumerable<BookResponseModel> GetAllByLanguage(Language language)
        {
            var books = _libraryRepository.GetAll();
            var updatedBooks = books.Where(book => book.Language == language);

            return updatedBooks.Select(book => new BookResponseModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                TakeDate = book.TakeDate,
                ReturnDate = book.ReturnDate
            });
        }

        public IEnumerable<BookResponseModel> GetAllByIsbn(string isbn)
        {
            var books = _libraryRepository.GetAll();
            var updatedBooks = books.Where(book => book.ISBN == isbn);

            return updatedBooks.Select(book => new BookResponseModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                TakeDate = book.TakeDate,
                ReturnDate = book.ReturnDate
            });
        }

        public IEnumerable<BookResponseModel> GetAllByName(string name)
        {
            var books = _libraryRepository.GetAll();
            var updatedBooks = books.Where(book => book.Name == name);

            return updatedBooks.Select(book => new BookResponseModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                TakeDate = book.TakeDate,
                ReturnDate = book.ReturnDate
            });
        }

        public IEnumerable<BookResponseModel> GetAllByIsAvailable(bool isAvailable)
        {
            var books = _libraryRepository.GetAll();
            var updatedBooks = books.Where(book => book.IsAvailable == isAvailable);

            return updatedBooks.Select(book => new BookResponseModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                TakeDate = book.TakeDate,
                ReturnDate = book.ReturnDate
            });
        }

        public void Create(BookRequestModel book)
        {
            var books = _libraryRepository.GetAll();
            var isUnique = books.Where(b => b.ISBN == book.ISBN).Count();
            if (isUnique > 0)
            {
                Console.WriteLine($"ISBN: {book.ISBN} already exists");
                return;
            }
            _libraryRepository.Save(new BookWriteModel
            {
                Name = book.Name,
                Author = book.Author,
                Category = book.Category,
                Language = book.Language,
                PublicationDate = book.PublicationDate,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable,
                ReaderName = book.ReaderName,
                ReturnDate = book.ReturnDate,
                TakeDate = book.TakeDate
            });
            Console.WriteLine($"Book ISBN: {book.ISBN} was added to Library");
        }

        public void Take(string isbn, string readerName, DateTime returnDate)
        {
            if (returnDate > DateTime.Now.AddDays(60))
            {
                Console.WriteLine("Taking the book longer than two months is not allowed");
                return;
            }
            var books = _libraryRepository.GetAll();
            var tokenBooks = books.Count(book => book.ReaderName == readerName);
            if (tokenBooks == 3)
            {
                Console.WriteLine("Taking more than 3 books not allowed");
                return;
            }
            var isAvailable = books.Where(book => book.ISBN == isbn).Count(book => book.IsAvailable);

            if (isAvailable == 0)
            {
                Console.WriteLine("This book is not available");
                return;
            }
            _libraryRepository.SwitchStatus(isbn, readerName, returnDate);
            Console.WriteLine($"Dear.{readerName} you can read the book until {returnDate:D}. " +
                $"Every next day will be fined by one candy");
        }

        public void Return(string isbn, string readerName)
        {
            var books = _libraryRepository.GetAll();
            var isLate = books.Single(book => book.ISBN == isbn).ReturnDate;
            if (isLate < DateTime.Now)
            {
                Console.WriteLine($"Dear.{readerName} where are my candies? Did you read the book twice...? :)");
            }
            _libraryRepository.SwitchStatus(isbn);
            Console.WriteLine($"Book ISBN: {isbn} was returned to Library");
        }

        public void Delete(string isbn)
        {
            _libraryRepository.Delete(isbn);
            Console.WriteLine($"Book ISBN: {isbn} was deleted from Library");
        }
    }
}
