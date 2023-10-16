namespace DistLab2.Core
{
    public class Auction
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //TODO: lägg till user
        public int StartingPrice { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<Bid> Bids{ get; set;}


    }
}
