using UnityEngine;

public class ProjectilePenetrationPart : SkillPart, IProjectilePenetrationCountUp
{
    public void SetPenetrationCountDown()
    {
        if (_skill.GetSkillData(SkillFieldDataType.Projectile) is ProjectileSkillDataSO data)
        {
            data.penetrationCount--;
        }
    }

    public void SetPenetrationCountUp()
    {
        if (_skill.GetSkillData(SkillFieldDataType.Projectile) is ProjectileSkillDataSO data)
        {
            data.penetrationCount++;
        }
    }
}
