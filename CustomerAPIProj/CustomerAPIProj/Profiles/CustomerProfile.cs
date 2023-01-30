using AutoMapper;

namespace CustomerAPIProj.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Models.Domain.Customer, Models.DTO.Customer>()
                .ReverseMap();
        }
    }
}
