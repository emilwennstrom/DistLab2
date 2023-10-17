using DistLab2.Core;

namespace DistLab2.Persistence.MockClasses
{
    public class MockAuctionDb //Todo: Ta bort sen
    {
        public static List<Auction> fakeAuctions;


        static MockAuctionDb()
        {
            fakeAuctions = new List<Auction>();
            fakeAuctions.Add(new Auction(-1, "A1"));
            fakeAuctions.Add(new Auction(-2, "A2"));
        }


        public static void AddAuction(Auction auction)
        {
            fakeAuctions.Add(auction);
        }

        public static List<Auction> GetAuctions()
        {
            return fakeAuctions;
        }


    }
}
