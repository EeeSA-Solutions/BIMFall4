//using BIMFall4.Data;
//using BIMFall4.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace BIMFall4.Manager
//{
//    public class FriendManager
//    {
//        public static void AddFriend(Friend value)
//        {   
//            var to_ID = GetUserIDByEmail(value.To_Email);
//            value.To_ID = to_ID;
//            using (var db = new BIMFall4Context())
//            {
//                db.Friends.Add(value);
//                db.SaveChanges();
//            }
//        }

//        static public int GetUserIDByEmail(string email)
//        {
//            using (var db = new BIMFall4Context())
//            {
//                var mail = db.Users.Where(user => user.Email == email).FirstOrDefault();
//                int id = mail.ID;
//                return id;
//            }
//        }

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