using BIMFall4.Data;
using BIMFall4.ModelDTO;
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

        public static void DeleteSavingGoal(int savinggoalId, int userid)
        {
            using (var db = new BIMFall4Context())
            {
                var savinggoal = db.SavingGoals.Find(savinggoalId);
                if (savinggoal != null && savinggoal.UserID == userid)
                {
                    db.SavingGoals.Remove(db.SavingGoals.Find(savinggoalId));
                    db.SaveChanges();
                }
            }
        }

        public static IEnumerable<SavingGoalDTO> GetSavingGoalDtoById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var goal = db.SavingGoals.Where(x => x.UserID == id).ToList();

                var goallist = new List<SavingGoalDTO>();

                foreach (var item in goal)
                {
                    goallist.Add(new SavingGoalDTO
                    {
                        ID = item.ID,
                        ReachDate = item.ReachDate,
                        StartDate = item.StartDate,
                        Amount = item.Amount,
                        Name = item.Name
                    });

                }

                return goallist;
            }
        }
        public static void EditSavingGoalByID(SavingGoal savinggoal, int id)
        {
            using (var db = new BIMFall4Context())
            {
                var db_sav = db.SavingGoals.Where(x => x.ID == id).FirstOrDefault();
                if (db_sav != null)
                {
                    db_sav.Name = savinggoal.Name;
                    db_sav.Amount = savinggoal.Amount;
                    db_sav.StartDate = savinggoal.StartDate;
                    db_sav.ReachDate = savinggoal.ReachDate;
                }
                else
                {
                    return;
                }
                db.SaveChanges();
            }
        }
    }
}