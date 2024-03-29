﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string CareerPath { get; set; }
        public string EmailId { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
        public bool? IsLoggedIn { get; set; }

        public int? ProfileId { get; set; }
        public int? PathId { get; set; }
        public string TrailblazerUrl { get; set; }

        public Double? CompletionPercentage { get; set; }
    }
}
