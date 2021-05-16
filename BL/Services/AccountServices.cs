using BL.Bases;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
   public class AccountServices :BaseServices
    {
        public ApplicationUserIdentity Find(string name, string password)
        {
            return TheUnitOfWork.Account.Find(name, password);
        }
        public IdentityResult Register(RegisterViewModel user)
        {
            ApplicationUserIdentity identityUser =
                mapper.Map<RegisterViewModel, ApplicationUserIdentity>(user);
            return TheUnitOfWork.Account.Register(identityUser);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);


        }

    }
}
