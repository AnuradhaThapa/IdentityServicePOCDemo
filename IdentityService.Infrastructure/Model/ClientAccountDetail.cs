﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityService.Infrastructure.Model
{
    public class ClientAccountDetail
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string CustodianId { get; set; }
        public string CustodianName { get; set; }
        public string RegisteredName { get; set; }
        public string ClientId { get; set; }
        public string UserId { get; set; }
        public string CustodialAccountNumber { get; set; }
        public string MarketValue { get; set; }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string IsClosed { get; set; }
    }
}
