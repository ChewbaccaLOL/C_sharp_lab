using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class PostContext
        :DbContext
    {
        public DbSet<admins> Admins { get; set; }
        public DbSet<postContents> PostContents { get; set; }
        public DbSet<posts> Posts { get; set; }
        public DbSet<thumbNails> ThumbNails { get; set; }

        public PostContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
