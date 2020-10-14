using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Interfaces
{
    public interface IProfileRepository : IDisposable 
    {
        Profile CreateProfile(Profile profile);
        void Delete(int profileId);
        void Edit(Profile profile);
        List<Profile> GetAllProfiles();
        Profile GetProfile(int profileId);
        List<Skill> GetAllSkills();
        List<Skill> GetSkillsByPath(string path);
    }
}
