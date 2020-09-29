using DBModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private EDMContainer db = new EDMContainer();
        public void Add(Profile profile)
        {
            db.Profiles.Add(profile);
            db.SaveChanges();
        }

        public void Delete(int profileId)
        {
            Profile profile = db.Profiles.Find(profileId);
            db.Profiles.Remove(profile);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(Profile profile)
        {
            db.Entry(profile).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Profile> GetAllProfiles()
        {
            return db.Profiles.ToList();
        }

        public Profile GetProfile(int profileId)
        {
            return db.Profiles.Find(profileId);
        }

        public List<Skill> GetAllSkills()
        {
            return db.Skills.ToList();
        }
    }
}
