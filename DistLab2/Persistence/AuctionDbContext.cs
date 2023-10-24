using DistLab2.Core;
using DistLab2.Persistence.DAO;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Persistence
{
    public class AuctionDbContext : DbContext
    {

        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }


        public DbSet<AuctionDb> AuctionDbs { get; set; }
        public DbSet<BidDb> BidDbs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionDb auctionDb1 = new AuctionDb
            {
                Id = -1,
                Name = "Fina hattar",
                Description = "lite hål dock",
                StartingPrice = 99,
                Username = "agge@hotmail.com",
                CreationDate = DateTime.Now.AddDays(-20),
                EndDate = DateTime.Now.AddDays(-1),
                Bids = new List<BidDb>()
            };
           
            BidDb bid1 = new BidDb { 
                Id = -1, 
                AuctionId = auctionDb1.Id, 
                BidAmount = 140, 
                Username = "emil@hotmale.com",
                DateOfBid = DateTime.Now.AddDays(-2),
            };

            BidDb bid2 = new BidDb
            {
                Id = -2,
                AuctionId = auctionDb1.Id,
                BidAmount = 200,
                Username = "popcorn@gmail.com",
                DateOfBid = DateTime.Now.AddDays(-1.5),
            };
            modelBuilder.Entity<AuctionDb>().HasData(auctionDb1);
            modelBuilder.Entity<BidDb>().HasData(bid1);
            modelBuilder.Entity<BidDb>().HasData(bid2);



            AuctionDb auctionDb2 = new AuctionDb
            {
                Id = -2,
                Name = "Plånbok",
                Description = "Jag hittade den",
                StartingPrice = 100,
                Username = "algot@kth.com",
                CreationDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddMinutes(-10), // Ended
                Bids = new List<BidDb>()
            };

            BidDb bid21 = new BidDb
            {
                Id = -3,
                AuctionId = auctionDb2.Id,
                BidAmount = 501,
                Username = "emil@hotmale.com",
                DateOfBid = DateTime.Now.AddMinutes(-40),
            };

            BidDb bid22 = new BidDb
            {
                Id = -4,
                AuctionId = auctionDb2.Id,
                BidAmount = 5800,
                Username = "algot@hotmail.se",
                DateOfBid = DateTime.Now.AddMinutes(-20),
            };

            modelBuilder.Entity<AuctionDb>().HasData(auctionDb2);
            modelBuilder.Entity<BidDb>().HasData(bid21);
            modelBuilder.Entity<BidDb>().HasData(bid22);


            AuctionDb auctionDb3 = new AuctionDb
            {
                Id = -3,
                Name = "En kruka",
                Description = "lite jord medkommer",
                StartingPrice = 100,
                Username = "emil@hotmale.com",
                CreationDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddMinutes(-10), // Ended
                Bids = new List<BidDb>()
            };

            BidDb bid31 = new BidDb
            {
                Id = -5,
                AuctionId = auctionDb2.Id,
                BidAmount = 501,
                Username = "popcorn@gmail.com",
                DateOfBid = DateTime.Now.AddMinutes(-40),
            };

            BidDb bid32 = new BidDb
            {
                Id = -6,
                AuctionId = auctionDb2.Id,
                BidAmount = 5800,
                Username = "agge@hotmail.com",
                DateOfBid = DateTime.Now.AddMinutes(-20),
            };

            modelBuilder.Entity<AuctionDb>().HasData(auctionDb3);
            modelBuilder.Entity<BidDb>().HasData(bid31);
            modelBuilder.Entity<BidDb>().HasData(bid32);



        }


    }
}
