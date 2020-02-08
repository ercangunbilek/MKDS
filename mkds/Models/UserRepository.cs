using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public static class UserRepository
    {

        private static List<User> _users = null;

         static UserRepository()
         {
            _users = new List<User>()
            {
                new User(){ name= "Zeynep", password= "zeynep123!"},
                new User(){name= "Ercan", password="erco35"},
                new User(){name= "Batuhan", password="batu97"},
                new User(){name= "Atakan", password="ato16"},
                new User(){ name="Ali", password= "ali123"},
                new User(){name="a",password = "a"}
            };
         }

        //UserRepository.Users
        public static List<User> Users
        {
            get
            {
                return _users;
            }
            
        }
        public static void AddUsers(User user)
        {
            _users.Add(user);
        }

    }
}