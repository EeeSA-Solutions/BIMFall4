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
        public static Response AddFriend(User value)
        {


            using (var db = new BIMFall4Context())
            {

                try
                {
                    // finns idt i db med conecct till id.email, finns ens emailen?

                    var checkforduplicateU1 = db.Users.Find(value.ID);
                    var checkforduplicateU2 = UserManager.GetUserByEmail(value.Email, db);

                    var check1 = db.Friends.Where(x => x.User1.ID.Equals(checkforduplicateU1.ID) && x.User2.ID.Equals(checkforduplicateU2.ID)).FirstOrDefault();
                    var check2 = db.Friends.Where(x => x.User1.ID.Equals(checkforduplicateU2.ID) && x.User2.ID.Equals(checkforduplicateU1.ID)).FirstOrDefault();
                    if (check1 == null && check2 == null) 
                    {
                        Friend added = new Friend();
                        added.Status = 0;
                        added.User1 = db.Users.Find(value.ID);
                        added.User2 = UserManager.GetUserByEmail(value.Email, db);
                        

                        db.Friends.Add(added);
                        db.SaveChanges();
                        return  new Response { Status = "Success", Message = "Success" };
                    }
                    else
                    {
                        return new Response { Status = "Failed", Message = "A request has already been sent" };
                    }

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

        static public IEnumerable<Friend> GetFriendsById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                return db.Friends.Where(x => x.User1.ID == id);
            }
        }

        static public Response SetFriendStatus(int id, FriendStatus wantedstatus)
        {
            
            using (var db = new BIMFall4Context())
            {
                
                var newStatus = db.Friends.Find(id);
                
                    newStatus.Status = wantedstatus;
                
                    db.SaveChanges();

            }
                return new Response { Status = "Success" , Message = "Success"};
        }
        static public IEnumerable<FriendDTO> GetPendingSentFriendsList(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var receivedlist = db.Friends.Where(x => x.Status == 0 && x.User2.ID == id).ToList();
                var sentlist = db.Friends.Where(x => x.Status == 0 && x.User1.ID == id).ToList();
                var friendlist = db.Friends.Where(x => x.Status == FriendStatus.Accepted && x.User1.ID == id || x.User2.ID == id && x.Status == FriendStatus.Accepted).ToList();

                List<FriendDTO> friendDTOlist = new List<FriendDTO>();

                foreach (var item in receivedlist)
                {
                    FriendDTO frienddto = new FriendDTO();
                    frienddto.List_ID = 1;
                    frienddto.FirstName = item.User1.FirstName;
                    frienddto.LastName = item.User1.LastName;
                    frienddto.Email = item.User1.Email;
                    frienddto.Relationship_ID = item.Relationship_ID;

                    friendDTOlist.Add(frienddto);
                }
                foreach (var item in sentlist)
                {
                    FriendDTO frienddto = new FriendDTO();
                    frienddto.List_ID = 2;
                    frienddto.FirstName = item.User2.FirstName;
                    frienddto.LastName = item.User2.LastName;
                    frienddto.Email = item.User2.Email;
                    frienddto.Relationship_ID = item.Relationship_ID;

                    friendDTOlist.Add(frienddto);
                }
                foreach (var item in friendlist)
                {
                    FriendDTO frienddto = new FriendDTO();
                    frienddto.List_ID = 3;
                    frienddto.FirstName = item.User1.FirstName;
                    frienddto.LastName = item.User1.LastName;
                    frienddto.Email = item.User1.Email;
                    frienddto.Relationship_ID = item.Relationship_ID;

                    friendDTOlist.Add(frienddto);
                }
                return friendDTOlist;
            }
        }
        public static void DeleteRelationship(int id)
        {
            using (var db = new BIMFall4Context())
            {
                if (db.Friends.Find(id) != null)
                {
                    db.Friends.Remove(db.Friends.Find(id));
                    db.SaveChanges();
                }
            }
        }
    }

}






   