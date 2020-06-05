using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Impl;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;



namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private PostContext db;
        private AdminRepository adminRepository;
        private PostContentsRepository postContentsRepository;
        private PostsRepository postsRepository;
        private ThumbNailsRepository thumbNailsRepository;


        public EFUnitOfWork(PostContext context)
        {
            db = context;
        }

        public IAdminRepository adminss
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }
        public IPostContentsRepository postContentss
        {
            get
            {
                if (postContentsRepository == null)
                    postContentsRepository = new PostContentsRepository(db);
                return postContentsRepository;
            }
        }
        public IPostsRepository postss
        {
            get
            {
                if (postsRepository == null)
                    postsRepository = new PostsRepository(db);
                return postsRepository;
            }
        }
        public IThumbNailsRepository thumbNailss
        {
            get
            {
                if (thumbNailsRepository == null)
                    thumbNailsRepository = new ThumbNailsRepository(db);
                return thumbNailsRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}