using System;

namespace SQL_library_HW16
{
        public class Loan
        {
            public int Id { get; set; }
            public int ReaderId { get; set; }
            public int BookId { get; set; }
            public DateTime BorrowedDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public DateTime DueDate { get; set; }

            public Reader Reader { get; set; }
            public Book Book { get; set; }
        }
}
