using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class thumbNails
    {
        public int postThumbnailID { get; set; } 
        public string postThumbnailURL { get; set; }
        public int ref_postID { get; set; }
    }
}
