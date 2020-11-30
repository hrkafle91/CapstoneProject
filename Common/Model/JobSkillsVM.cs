using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class JobSkillsVM
    {
        public string JobTitle { get; set; }
        public string JobDesc { get; set; }
        public int Id { get; set; }
        public string JobRef { get; set; }
        public string CareerPath { get; set; }
        public string Company { get; set; }
        public string JobType { get; set; }
        public List<ReqSkill> RequiredSkills { get; set; }

        public JobSkillsVM()
        {
            RequiredSkills = new List<ReqSkill>();
        }

        public JobSkillsVM(string title, string desc, string jbref, string careerPath, string company, string jobType, int id)
        {
            this.JobTitle = title;
            this.JobDesc = desc;
            this.JobRef = jbref;
            this.CareerPath = careerPath;
            this.Company = company;
            this.JobType = jobType;
            this.Id = id;
            RequiredSkills = new List<ReqSkill>();
        }

    }

    public class ReqSkill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public bool isChecked { get; set; }

    }
}
