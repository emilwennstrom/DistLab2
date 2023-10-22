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
                Name = "Auction1",
                Description = "Min första auktion",
                StartingPrice = 0,
                Username = "agge@hotmail.com",
                CreationDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                Bids = new List<BidDb>()
            };
           
            BidDb bid1 = new BidDb { 
                Id = -1, 
                AuctionId = auctionDb1.Id, 
                BidAmount = 50, 
                Username = "Emil",
                DateOfBid = DateTime.Now.AddMinutes(10),
            };

            BidDb bid2 = new BidDb
            {
                Id = -2,
                AuctionId = auctionDb1.Id,
                BidAmount = 58,
                Username = "Albin",
                DateOfBid = DateTime.Now.AddMinutes(20),
            };
            modelBuilder.Entity<AuctionDb>().HasData(auctionDb1);
            modelBuilder.Entity<BidDb>().HasData(bid1);
            modelBuilder.Entity<BidDb>().HasData(bid2);



            AuctionDb auctionDb2 = new AuctionDb
            {
                Id = -2,
                Name = "Auction2",
                Description = "Min andra auktion",
                StartingPrice = 100,
                Username = "agge@hotmail.com",
                CreationDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(-10), // Ended
                Bids = new List<BidDb>()
            };

            BidDb bid21 = new BidDb
            {
                Id = -3,
                AuctionId = auctionDb2.Id,
                BidAmount = 501,
                Username = "Emil",
                DateOfBid = DateTime.Now.AddMinutes(-40),
            };

            BidDb bid22 = new BidDb
            {
                Id = -4,
                AuctionId = auctionDb2.Id,
                BidAmount = 5800,
                Username = "algot@kth.se",
                DateOfBid = DateTime.Now.AddMinutes(-20),
            };

            modelBuilder.Entity<AuctionDb>().HasData(auctionDb2);
            modelBuilder.Entity<BidDb>().HasData(bid21);
            modelBuilder.Entity<BidDb>().HasData(bid22);



        }


    }
}
