using System.Collections.Generic;
using Persistence.Models.ReadModels;
using System.Linq;
using Persistence.Models.WriteModels;
using System;

namespace Persistence.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private const string FileName = "library.json";
        private readonly IFileClient _fileClient;

        public LibraryRepository(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public IEnumerable<BookReadModel> GetAll()
        {
            return _fileClient.ReadAll<BookReadModel>(FileName);
        }

        public void Save(BookWriteModel book)
        {
            _fileClient.Append(FileName, book);
        }

        public void SwitchStatus(string isbn, string readerName, DateTime returnDate)
        {
            var books = _fileClient.ReadAll<BookReadModel>(FileName).ToList();

            var book = books.Single(book => book.ISBN == isbn);

            book.IsAvailable = !book.IsAvailable;
            book.ReaderName = readerName;
            book.ReturnDate = returnDate;
            book.TakeDate = DateTime.Now;

            _fileClient.WriteAll(FileName, books);
        }

        public void SwitchStatus(string isbn)
        {
            var books = _fileClient.ReadAll<BookReadModel>(FileName).ToList();

            var book = books.Single(book => book.ISBN == isbn);

            book.IsAvailable = !book.IsAvailable;
            book.ReaderName = string.Empty;
            book.ReturnDate = DateTime.MinValue;
            book.TakeDate = DateTime.MinValue;

            _fileClient.WriteAll(FileName, books);
        }

        public void Delete(string isbn)
        {
            var books = _fileClient.ReadAll<BookReadModel>(FileName).ToList();

            var updatedBooks = books.Where(book => book.ISBN != isbn);

            _fileClient.WriteAll(FileName, updatedBooks);
        }
    }
}
