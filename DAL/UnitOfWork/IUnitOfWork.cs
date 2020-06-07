using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;


namespace DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IAdminRepository adminss { get; }
        IPostContentsRepository postContentss { get; }
        IPostsRepository postss { get; }
        IThumbNailsRepository thumbNailss { get; }
        void Save();
    }
}
