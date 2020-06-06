using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int postid, string userType)
        {
            UserId = userId;
            Name = name;
            POSTID = postid;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int POSTID { get; }
        protected string UserType { get; }
    }
}
