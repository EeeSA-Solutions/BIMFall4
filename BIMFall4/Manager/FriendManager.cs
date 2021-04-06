using BIMFall4.Data;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager
{
    public class FriendManager
    {
        public void AddFriend(User value)
        {
            

            var User1 = UserManager.GetSafeUserByID(value.ID);
            var to_ID = GetUserIDByEmail(value.Email);
             var User2 = UserManager.GetSafeUserByID(to_ID);
            
            
            using (var db = new BIMFall4Context())
            {
                User2.Friends.Add(User1);
                User1.Friends.Add(User2);
                db.SaveChanges();
            }
        }

        static public int GetUserIDByEmail(string email)
        {
            using (var db = new BIMFall4Context())
            {
                var mail = db.Users.Where(user => user.Email == email).FirstOrDefault();
                int id = mail.ID;
                return id;
            }
        }
    }
}

//        static public IEnumerable<Friend> GetPending(int id)
//        {
//            using (var db = new BIMFall4Context())
//            {

//                return db.Friends.Where(x => x.Status == "Pending" && x.To_ID == id).ToList();
//            }
//        }
//        //static public IEnumerable<Friend> GetFriendsById(int id)
//        //{
//        //    using (var db = new BIMFall4Context())
//        //    {
//        //        return db.Friends.Where(x => x.From_ID == id);
//        //    }
//        //}




//    }
//}