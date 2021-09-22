using System;
using System.Collections.Generic;
using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;

namespace Persistence.Repositories
{
    public interface ILibraryRepository
    {
        IEnumerable<BookReadModel> GetAll();

        void Save(BookWriteModel book);

        void SwitchStatus(string isbn, string readerName, DateTime returnDate);

        void SwitchStatus(string isbn);

        void Delete(string isbn);
    }
}