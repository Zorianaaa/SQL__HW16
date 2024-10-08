using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_library_HW16
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublishingCode { get; set; }
        public int PublishingCodeTypeId { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
