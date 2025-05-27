using UnityEngine;

public class CoolTimeDownPart : SkillPart, ICoolTimeDownPart
{
    public void DeCreaseCoolTime(float time, ICoolTimeDownPart.ModifyType modifyType)
    {
        if (_skill.GetSkillData(SkillFieldDataType.Generic) is GenericSkillDataSO data)
        {
            switch (modifyType)
            {
                case ICoolTimeDownPart.ModifyType.Add:
                    data.coolTime = Mathf.Max(1, data.coolTime - time);
                    break;
                case ICoolTimeDownPart.ModifyType.Percent:
                    data.coolTime = Mathf.Max(1, data.coolTime * (1 - time / 100f));
                    break;
            }
        }
    }

    public void InCreaseCoolTime(float time, ICoolTimeDownPart.ModifyType modifyType)
    {
        if (_skill.GetSkillData(SkillFieldDataType.Generic) is GenericSkillDataSO data)
        {
            switch (modifyType)
            {
                case ICoolTimeDownPart.ModifyType.Add:
                    data.coolTime += time;
                    break;
                case ICoolTimeDownPart.ModifyType.Percent:
                    data.coolTime += data.coolTime * (time / 100f);
                    break;
            }
        }
    }

    public void SetCoolTime(float time)
    {
        if (_skill.GetSkillData(SkillFieldDataType.Generic) is GenericSkillDataSO data)
        {
            data.coolTime = time;
        }
    }

    public void SetCoolTimeBetweenTwo(int time1, int time2)
    {
        if (_skill.GetSkillData(SkillFieldDataType.Generic) is GenericSkillDataSO data)
        {
            data.coolTime = Random.Range(0, 2) == 0 ? time1 : time2;
        }
    }
}
