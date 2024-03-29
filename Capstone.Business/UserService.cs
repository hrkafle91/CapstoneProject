﻿using Common.Model;
using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Capstone.Business
{
    public static class UserService
    {
        public static UserViewModel SetUser(Account account)
        {
            return new UserViewModel()
            {
                Id = account.userID,
                EmailId = account.emailID,
                UserId = account.userName,
                UserType = account.userType,
                FirstName = account.firstName,
                Lastname = account.lastName,
                ProfileId = account.Profile.profileId,
                CareerPath = account.Profile.careerPath ?? "n/a",
                TrailblazerUrl = account.Profile.trailHeadUrl ?? "n/a"
            };
        }

        public static UserViewModel SetCareerPath(UserViewModel user, string path)
        {
            user.CareerPath = path;
            return user;
        }
    }
}
