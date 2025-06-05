using Mission.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepositories
{
    public interface IMissionSkillRepository
    {
        Task<MissionSkill> GetMissionSkillById(int id);
        Task<IList<MissionSkill>> GetAllMissionSkills();

        Task AddMissionSkill(MissionSkill missionSkill);
        Task UpdateMissionSkill(MissionSkill missionSkillReq);

        Task DeleteMissionSkill(int id);
    }
}
