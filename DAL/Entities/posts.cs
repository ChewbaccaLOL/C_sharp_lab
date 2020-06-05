using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class posts
    {
        public int postID { get; set; }
        public string postName { get; set; }
        public string postDate { get; set; }
        public int postAuthor { get; set; }
    }
}
