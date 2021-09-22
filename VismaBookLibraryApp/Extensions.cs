using Contracts.Models;
using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;

namespace VismaBookLibraryApp
{
    public static class Extensions
    {
        public static BookResponseModel MapToBookResponse(this BookReadModel book)
        {
            return new BookResponseModel
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
            };
        }

        public static BookWriteModel MapToBookWrite(this BookRequestModel book)
        {
            return new BookWriteModel
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
            };
        }
    }
}
