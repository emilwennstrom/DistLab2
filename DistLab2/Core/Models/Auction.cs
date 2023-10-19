using DistLab2.ViewModels;
using System.Diagnostics;

namespace DistLab2.Core
{
    public class Auction
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string Username { get; set; }
        public int StartingPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Bid> Bids { get; set; }


        public Auction(int id, string name, string description, string username, int startingPrice, DateTime creationDate, DateTime endDate, List<Bid>? bids)
        {
            Id = id;
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            CreationDate = creationDate;
            Username = username;
            EndDate = endDate;
            Bids = bids;
        }



        //Todo: Ta bort sen, dummy
        public Auction(int id, string name)
        {
            Id = id;
            Name = name;
            Description = "this is a description of auction " + Id;
            StartingPrice = Id + 20;
            CreationDate = DateTime.Now;
            EndDate = DateTime.Now.AddMonths(1);
            Bids = new List<Bid>();
        }

        public Auction(string name, string description, int startingPrice, DateTime endDate)
        {
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            EndDate = endDate;
            Bids = new List<Bid>();
        }

        public Auction(string name, string description, int startingPrice)
        {
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
        }

        public Auction()
        {
        }
    }

    public class StartingPriceComparator : IComparer<Auction>
    {
        public int Compare(Auction? x, Auction? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return y.StartingPrice.CompareTo(x.StartingPrice);
        }
    }


}
