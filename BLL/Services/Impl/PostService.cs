using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using DAL.Entities;
using CCL.Security;
using CCL.Security.Identity;


namespace BLL.Services.Impl
{
    public class PostService
        : IPostService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        public PostService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<postsDTO> GetPosts(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            System.Console.WriteLine(userType);
            if (userType != typeof(Admin))
            {
                throw new MethodAccessException();
            }
            var postid = user.POSTID;
            var postsEntities =
                _database
                    .postss
                    .Find(z => z.postID == postid, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<posts, postsDTO>()
                    ).CreateMapper();
            var postssDTO =
                mapper
                    .Map<IEnumerable<posts>, List<postsDTO>>(
                        postsEntities);
            return postssDTO;
        }
    }
}
