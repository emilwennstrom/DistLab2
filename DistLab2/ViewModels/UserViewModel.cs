using DistLab2.Core;
using System.Diagnostics;
using DistLab2.Areas.Identity.Data;

namespace DistLab2.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        
        public static UserViewModel FromUser(DistUser user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };
        }
    }
}
