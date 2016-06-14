using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebUI.Models.View.Home
{
    public class ShortenInputModel
    {
        [Required]
        [DataType(DataType.Url)]
        [Url]
        public String Url { get; set; }
    }
}