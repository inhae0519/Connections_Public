using System;
using UnityEngine;

[Serializable]
public class DefaultSkillStatElement : BaseSkillStatElement
{
    [SerializeField] private float _defaultValue;
    [HideInInspector] public float currentValue;
    public DefaultSkillStatInfoSO defaultSkillInfo => statInfo as DefaultSkillStatInfoSO;
    
    public override void Init()
    {
        currentValue = _defaultValue;
    }
}
