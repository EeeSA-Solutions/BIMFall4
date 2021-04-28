using BIMFall4.Data;
using BIMFall4.ModelDTO;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIMFall4.Manager
{
    public class FriendManager
    {
        public static bool AddFriend(User value)
        {


            using (var db = new BIMFall4Context())
            {

                try
                {
                    // finns idt i db med conecct till id.email, fiins ens emailen?

                    var checkforduplicateU1 = db.Users.Find(value.ID);
                    var checkforduplicateU2 = UserManager.GetUserByEmail(value.Email, db);

                    if (checkforduplicateU1 == ?? && checkforduplicateU2 == ?? ) { }
                    

                    //----------------------------------------------//
                    Friend added = new Friend();
                    added.Status = 0;
                    added.User1 = db.Users.Find(value.ID);
                    added.User2 = UserManager.GetUserByEmail(value.Email, db);
                    //added.User2 = db.Users.Find(to_ID);

                    db.Friends.Add(added);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }
        }
        static public IEnumerable<FriendDTO> GetPending(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var friendlist = db.Friends.Where(x => x.Status == 0 && x.User2.ID == id).ToList();

                List<FriendDTO> friendDTOlist = new List<FriendDTO>();

                foreach (var item in friendlist)
                {
                    FriendDTO frienddto = new FriendDTO();

                    frienddto.FirstName = item.User1.FirstName;
                    frienddto.LastName = item.User1.LastName;
                    frienddto.Email = item.User1.Email;
                    frienddto.Relationship_ID = item.Relationship_ID;

                    friendDTOlist.Add(frienddto);
                }
                return friendDTOlist;
            }
        }

        static public IEnumerable<Friend> GetFriendsById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                return db.Friends.Where(x => x.User1.ID == id);
            }
        }

        static public void SetFriendStatus(int id, FriendStatus wantedstatus)
        {
            
            using (var db = new BIMFall4Context())
            {
                var newStatus = db.Friends.Find(id);
                
                    newStatus.Status = wantedstatus;
                
                    db.SaveChanges();
            }
        }

    }

}






