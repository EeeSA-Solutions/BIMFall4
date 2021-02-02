using BIMFall4.Data;
using BIMFall4.Models;

namespace BIMFall4.Manager
{
    public class SavingGoalManager
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

        public static SavingGoal GetSavingGoalById(int id)
        {
            using (var db = new BIMFall4Context())
            {
                var savingGoal = db.SavingGoals.Find(id);
                return savingGoal;
            }
        }
    }
}