using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;


namespace DAL.Repository.Impl
{
    class PostContentsReopsitory
        :BaseRepository<postContents>, IPostContentsRepository
    {
        internal PostContentsReopsitory(PostContext context)
            : base(context)
        {

        }
    }
}
