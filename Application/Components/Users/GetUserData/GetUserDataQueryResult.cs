using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Users.GetUserData
{
    public class GetUserDataQueryResult
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
