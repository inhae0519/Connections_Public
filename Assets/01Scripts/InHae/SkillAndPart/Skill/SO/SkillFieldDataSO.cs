using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public enum SkillFieldDataType
{
    Range,
    Projectile,
    Generic,
    Targeting,
}

public abstract class SkillFieldDataSO : ScriptableObject
{
    public SkillFieldDataType fieldType;
    public Dictionary<SkillStatInfoSO, BaseSkillStatElement> skillStatElements = new();
    
    private void Awake()
    {
        var skillElementInfos = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.Public)
            .Where(x=>typeof(BaseSkillStatElement).IsAssignableFrom(x.FieldType));
        
        foreach (var skillElement in skillElementInfos)
        {
            BaseSkillStatElement skillStatElement = (BaseSkillStatElement)skillElement.GetValue(this);
            skillStatElements.Add(skillStatElement.statInfo, skillStatElement);
        }
    }

    public virtual void Init()
    {
        foreach (var skillStatElement in skillStatElements.Values)
            skillStatElement.Init();
    }
}
