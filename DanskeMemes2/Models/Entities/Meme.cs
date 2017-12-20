using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeMemes2.Models.Entities
{
    public class Meme : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
