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

        public static IEnumerable<SavingGoal> GetSavingGoalList()
        {
            using (var db = new BIMFall4Context())
            {
                return db.SavingGoals.ToList();
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
    }
}