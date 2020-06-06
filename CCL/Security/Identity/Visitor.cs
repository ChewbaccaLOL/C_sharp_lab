using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Visitor
        :User
    {
        public Visitor(int userid, string name, int postid)
            :base(userid, name, postid, nameof(Visitor))
        {

        }
    }
}
