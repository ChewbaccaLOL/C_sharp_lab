using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;


namespace DAL.Repository.Impl
{
    class ThumbNailsRepository
        : BaseRepository<thumbNails>, IThumbNailsRepository
    {
        internal ThumbNailsRepository(PostContext context)
            :base(context)
        {

        }
    }
}
