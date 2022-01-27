using IdentityService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDetailEntity> GetUserByAplId(string apiId);
        Task<string> GetUserByUserId(Guid guidid);
    }
}
