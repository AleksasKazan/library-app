using System;
using Contracts.Enums;

namespace Contracts.Models
{
    public class BookResponseModel
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

        public override string ToString()
        {
            return $"Title: {Name}, Author: {Author}, Category: {Category}, Language: {Language}, " +
                $"Published: {PublicationDate:Y}, ISBN {ISBN}, Available: {IsAvailable}, Reader: {ReaderName}, " +
                $"Return date: {ReturnDate:d}, Take date: {TakeDate:d}";
        }
    }
}
