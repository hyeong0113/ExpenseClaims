using ExpenseClaims.Infrastructure.Identity.Models;
using ExpenseClaims.Web.Areas.Admin.Models;
using AutoMapper;

namespace ExpenseClaims.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}