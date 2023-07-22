using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Location { get; set; }
        // Step 7: MLA Citation
        public string MLACitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {Price:C}. {DateTime.UtcNow.Year},{Location}.";
        // Step 8: Chicago Citation
        public string ChicagoCitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {DateTime.UtcNow.Year},{Location}.";

    }
}
