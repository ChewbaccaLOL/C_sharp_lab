using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    class postContents
    {
        public int postContentID { get; set; }
        public string postContent { get; set; }
        public int ref_postID { get; set; }
    }
}
