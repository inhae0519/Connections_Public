using UnityEngine;

public class ReflectionPartNode : PartNode
{
    public override void EquipPart(Skill skill)
    {
        if (skill.GetSkillPart(typeof(ReflectionPart)) is ReflectionPart part)
        {
            part.ReflectionEquip();
        }
    }

    public override void UnEquipPart(Skill skill)
    {
        if (skill.GetSkillPart(typeof(ReflectionPart)) is ReflectionPart part)
        {
            part.ReflectionUnEquip();
        }
    }
}
