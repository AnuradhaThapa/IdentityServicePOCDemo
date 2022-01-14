using AutoMapper;
using IdentityService.Core.Entities;
using IdentityService.Core.Interfaces;
using IdentityService.Infrastructure.Model;
using IdentityService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AMDBContext context;
        private readonly IMapper imapper;
        public UserRepository(AMDBContext context,IMapper mapper)
        {
            this.context = context;
            imapper = mapper;
        }
        public async Task<UserDetailEntity> GetUserByApiId(string apiId)
        {
            UserDetailEntity userDetailEntity = null;
            UserDetail userDetail = await context.UserDetails.Where(x => x.AplId == apiId).FirstOrDefaultAsync();

            if (userDetail != null)
            {
                userDetailEntity = imapper.Map<UserDetailEntity>(userDetail);
            }
            return userDetailEntity;
        }
        public async Task<string> GetUserByUserId(Guid guidid)
        {
            string base64EncodedResponse = string.Empty;

            UserDetail userDetail = await context.UserDetails.Where(x => x.UserGuid == guidid).FirstOrDefaultAsync();

            if (userDetail != null)
            {
                UserDetailEntity userDetailEntity = imapper.Map<UserDetailEntity>(userDetail);
                string userDetailsJson = JsonConvert.SerializeObject(userDetailEntity);
                base64EncodedResponse = Convert.ToBase64String(Encoding.UTF8.GetBytes(userDetailsJson));
            }
            return base64EncodedResponse;
        }
    }
}
