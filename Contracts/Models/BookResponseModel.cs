using System;

namespace Contracts.Models
{
    public class BookResponseModel : Book
    {
        public bool IsAvailable { get; set; }

        public string ReaderName { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime TakeDate { get; set; }

        public override string ToString()
        {
            return $"Title: {Name}, Author: {Author}, Category: {Category}, Language: {Language}, " +
                $"ISBN {ISBN}, Available: {IsAvailable}, Reader: {ReaderName}, Return date: {ReturnDate:d}";
        }
    }
}
