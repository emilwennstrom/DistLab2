using DistLab2.Core;
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
                Username = "Algot",
                CreationDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                Bids = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(auctionDb1);

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

            modelBuilder.Entity<BidDb>().HasData(bid1);
            modelBuilder.Entity<BidDb>().HasData(bid2);

        }


    }
}
