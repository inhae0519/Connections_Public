using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillStatBaseSlot : MonoBehaviour
{
    public SkillStatInfoSO statInfo;
    [SerializeField] protected Image _iconImage;
    [SerializeField] protected TextMeshProUGUI _valueText;

    public virtual void Init(BaseSkillStatElement baseSkillStatElement)
    {
        _iconImage.sprite = baseSkillStatElement.statInfo.icon;
    }
}
