using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Interfaces
{
    public interface IPostsRepository
        :IRepository<posts>
    {
    }
}
