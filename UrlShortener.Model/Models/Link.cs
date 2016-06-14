using System;
using System.Collections.Generic;

namespace UrlShortener.Model.Models
{
    public class Link
    {
        public Int64 Id { get; set; }
        public Guid Short { get; set; }
        public Int32 Visitors { get; set; }
        public DateTime CreatedDate { get; set; }
        public String Original { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
}