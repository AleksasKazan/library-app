using System;
using Contracts.Enums;

namespace Contracts.Models
{
    public class Book
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public Category Category { get; set; }

        public Language Language { get; set; }

        public DateTime PublicationDate { get; set; }

        public string ISBN { get; set; }
    }
}
