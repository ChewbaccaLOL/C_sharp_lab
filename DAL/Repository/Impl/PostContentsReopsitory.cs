using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;


namespace DAL.Repository.Impl
{
    class PostContentsRepository
        :BaseRepository<postContents>, IPostContentsRepository
    {
        internal PostContentsRepository(PostContext context)
            : base(context)
        {

        }
    }
}
