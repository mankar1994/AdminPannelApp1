﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Models
{
    public class VerifyAccount
    {

        public int Id { get; set; }
        public string Otp { get; set; }
        public string UserId { get; set; }
        public DateTime? SendTime { get; set; }

    }
}
