using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;


namespace DAL.Repository.Impl
{
    public class AdminRepository
        :BaseRepository<admins>, IAdminRepository
    {
        internal AdminRepository(PostContext context)
            :base(context)
        {

        }
    }
}
