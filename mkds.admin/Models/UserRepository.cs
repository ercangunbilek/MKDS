using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.admin.Models
{
    public static class UserRepository
    {
        private static List<User> _userList = null;

        static UserRepository()
        {
            _userList = new List<User>()
            {
                new User("admin", "admin"),
                new User( "carrier","carrier"),
                new User("chef","chef")
            };
        }

        public static List<User> GetUserList()
        {
            return _userList;
        }
    }
}
