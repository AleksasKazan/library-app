using System;

namespace Contracts.Models
{
    public class BookRequestModel : Book
    {
        public bool IsAvailable { get; set; }

        public string ReaderName { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime TakeDate { get; set; }
    }
}
