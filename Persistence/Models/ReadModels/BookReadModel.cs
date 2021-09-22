using System;
using Contracts.Enums;

namespace Persistence.Models.ReadModels
{
    public class BookReadModel
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public Category Category { get; set; }

        public Language Language { get; set; }

        public DateTime PublicationDate { get; set; }

        public string ISBN { get; set; }

        public bool IsAvailable { get; set; }

        public string ReaderName { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime TakeDate { get; set; }
    }
}
