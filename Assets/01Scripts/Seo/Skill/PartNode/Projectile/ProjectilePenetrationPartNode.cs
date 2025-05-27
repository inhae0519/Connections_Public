using UnityEngine;

public class ProjectilePenetrationPartNode : PartNode
{
    public override void EquipPart(Skill skill)
    {
        if (skill.GetSkillPart(typeof(ProjectilePenetrationPart)) is ProjectilePenetrationPart part)
        {
            part.SetPenetrationCountUp();
        }
    }

    public override void UnEquipPart(Skill skill)
    {
        if (skill.GetSkillPart(typeof(ProjectilePenetrationPart)) is ProjectilePenetrationPart part)
        {
            part.SetPenetrationCountDown();
        }
    }
}
