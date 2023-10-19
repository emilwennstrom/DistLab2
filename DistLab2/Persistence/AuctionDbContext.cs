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
            AuctionDb db = new AuctionDb
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

            db.Bids.Add(new BidDb { 
                Id = -1, 
                AuctionId = db.Id, 
                BidAmount = 50, 
                Username = "Emil",
                DateOfBid = DateTime.Now.AddMinutes(10),
            });

            db.Bids.Add(new BidDb
            {
                Id = -2,
                AuctionId = db.Id,
                BidAmount = 58,
                Username = "Albin",
                DateOfBid = DateTime.Now.AddMinutes(20),
            });




        }


    }
}
