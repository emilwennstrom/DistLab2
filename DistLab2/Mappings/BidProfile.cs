using AutoMapper;
using DistLab2.Core;
using DistLab2.Persistence.DAO;

namespace DistLab2.Mappings
{
    public class BidProfile : Profile
    {

        public BidProfile()
        {

            //default mapping when property names are the same
            CreateMap<Bid, BidDb>()
               .ReverseMap();

        }
    }
}
