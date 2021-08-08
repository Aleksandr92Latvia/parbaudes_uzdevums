using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servera_puse.Entities;

namespace Servera_puse.Helpers
{
    public static class Parolu_noslepshana
    {
        public static User Bez_paroles (this User user)
        {
            if (user == null)
                return null;

            else
            {
                user.Password = null;
                return user;
            }
        }
    }
}
