namespace BIMFall4.Manager.CalculateManagers
{
    public class erik
    {

        public string Category { get; set; }
       public int Count { get; set; }
       public decimal Amount { get; set; }

        public erik(string category, int count, decimal amount)
        {
            this.Category = category;
            this.Count = count;
            this.Amount = amount;
        }


    }


}