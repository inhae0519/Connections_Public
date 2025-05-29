using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct TrajectoryTranslate
{
    public List<TrajectoryType> trajectoryCheckList;
    public string text;
}

public class SkillStatTrajectorySlot : SkillStatBaseSlot
{
    [SerializeField] private List<TrajectoryTranslate> _trajectoryCheckList;
    
    public override void Init(BaseSkillStatElement baseSkillStatElement)
    {
        base.Init(baseSkillStatElement);
        
        TrajectorySkillStatElement trajectorySkillStatElement = baseSkillStatElement as TrajectorySkillStatElement;
        _valueText.text = TrajectoryTranslate(trajectorySkillStatElement.currentTrajectory);
    }
    
    private string TrajectoryTranslate(List<TrajectoryType> trajectoryCheckList)
    {
        foreach (var checkList in _trajectoryCheckList)
        {
            bool equal = checkList.trajectoryCheckList.OrderBy(x => x).
                SequenceEqual(trajectoryCheckList.OrderBy(x => x));

            if (equal)
            {
                return checkList.text;
            }
        }

        return "직선";
    }
}
