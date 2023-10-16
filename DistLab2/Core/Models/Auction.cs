namespace DistLab2.Core
{
    public class Auction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //lägg till user
        public int StartingPrice { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly endDate { get; set; }

    }
}
