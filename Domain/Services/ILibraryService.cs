using System;
using System.Collections.Generic;
using Contracts.Enums;
using Contracts.Models;
using Persistence.Models.ReadModels;

namespace Domain.Services
{
    public interface ILibraryService
    {
        IEnumerable<BookResponseModel> GetAll();

        IEnumerable<BookResponseModel> GetAllByAuthor(string author);

        void Create(BookRequestModel book);

        void Take(string isdn, string readerName, DateTime returDate);
        void Return(string isdn, string readerName);

        void Delete(string isdn);

        IEnumerable<BookResponseModel> GetAllByCategory(Category category);
        IEnumerable<BookResponseModel> GetAllByLanguage(string language);
        IEnumerable<BookResponseModel> GetAllByIsbn(string isbn);
        IEnumerable<BookResponseModel> GetAllByName(string name);
        IEnumerable<BookResponseModel> GetAllByIsAvailable(bool isAvailable);
    }
}