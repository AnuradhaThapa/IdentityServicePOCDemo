﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityService.Infrastructure.Model
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public Guid UserGuid { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public string AplId { get; set; }
        public bool HasActiveRole { get; set; }
    }
}
