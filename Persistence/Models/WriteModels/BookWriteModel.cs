using System;
using Contracts.Enums;

namespace Persistence.Models.WriteModels
{
    public class BookWriteModel
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public Category Category { get; set; }

        public string Language { get; set; }

        public DateTime PublicationDate { get; set; }

        public string ISBN { get; set; }

        public bool IsAvailable { get; set; }

        public string ReaderName { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime TakeDate { get; set; }
    }
}
