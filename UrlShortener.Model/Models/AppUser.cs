using System;
using System.Collections.Generic;

namespace UrlShortener.Model.Models
{
    public class AppUser
    {
        public Int64 Id { get; set; }
        public Guid Identity { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}