using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_操作
{
    class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int Damage { get; set; }


        public override string ToString()
        {
            return string.Format("Id:{0},Name:{1},Language:{2},Damage{3}", Id, Name, Language, Damage);
        }

    }

    class SkillInfo
    {
   
        public int SkillID { get; set; }
        public string SkillEngName { get; set; }
        public int TriggerType { get; set; }
        public string ImageFile { get; set; }
        public int AvailableRace { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("SkillID:{0},SkillEngName:{1},TriggerType:{2},ImageFile:{3},AvailableRace:{4},Name:{5}", SkillID, SkillEngName, TriggerType, ImageFile, AvailableRace, Name);
        }
    }
}