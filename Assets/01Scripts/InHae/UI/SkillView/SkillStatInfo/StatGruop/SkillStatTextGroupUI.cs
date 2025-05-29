using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillStatTextGroupUI : MonoBehaviour
{
    public SkillFieldDataType fieldType;
    
    private List<SkillStatBaseSlot> _slots = new List<SkillStatBaseSlot>();
    
    private void Awake()
    {
        _slots = GetComponentsInChildren<SkillStatBaseSlot>().ToList();
    }

    public void Init(SkillFieldDataSO skillFieldData)
    {
        foreach (var slot in _slots)
            slot.Init(skillFieldData.skillStatElements[slot.statInfo]);
    }
}
