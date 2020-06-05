using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;


namespace DAL.Repository.Impl
{
    class PostsRepository
        : BaseRepository<posts>, IPostsRepository
    {
        internal PostsRepository(PostContext context)
            :base(context)
        {

        }
    }
}
