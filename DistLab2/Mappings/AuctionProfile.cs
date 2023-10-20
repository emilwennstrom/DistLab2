using AutoMapper;
using DistLab2.Core;
using DistLab2.Persistence;

namespace DistLab2.Mappings
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile() {

            //default mapping when property names are the same
            CreateMap<Auction, AuctionDb>()
                .ReverseMap();
        }
    }
}
