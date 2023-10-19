namespace DistLab2.Core
{
    public class Bid
    {
        public Bid(int id, DateTime dateOfBid, double bidAmount, string username)
        {
            Id = id;  
            DateOfBid = dateOfBid;
            BidAmount = bidAmount;
            Username = username;
        }
        public int Id { get; set; }
        public DateTime DateOfBid { get; set; }
        public double BidAmount { get; set; }
        public string Username { get; set; }   
    }
}
