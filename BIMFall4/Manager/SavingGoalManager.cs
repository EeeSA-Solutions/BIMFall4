using BIMFall4.Data;
using BIMFall4.Models;
using System.Collections.Generic;
using System.Linq;

namespace BIMFall4.Manager
{
    public static class SavingGoalManager
    {

        public static void CreateSavingGoal(SavingGoal savingGoal)
        {
            using (var db = new BIMFall4Context())
            {
                db.SavingGoals.Add(savingGoal);
                db.SaveChanges();
            }
        }

        public static void DeleteSavingGoal(int id)
        {
            using (var db = new BIMFall4Context())
            {
                if (db.SavingGoals.Find(id) != null)
                {
                    db.SavingGoals.Remove(db.SavingGoals.Find(id));
                    db.SaveChanges();
                }
            }
        }

        public static IEnumerable<SavingGoal> getSavingGoalById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var saving = db.SavingGoals.Where(x => x.UserID == id).ToList();
                return saving;
            }
        }

        //public static SavingGoal GetSavingGoalById(int id)
        //{
        //    using (var db = new BIMFall4Context())
        //    {
        //        var savingGoal = db.SavingGoals.Find(id);
        //        return savingGoal;
        //    }
        //}


    }
}