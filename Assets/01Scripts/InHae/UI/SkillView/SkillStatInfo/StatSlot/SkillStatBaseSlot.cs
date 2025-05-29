using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SkillStatBaseSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SkillStatInfoSO statInfo;
    [SerializeField] protected Image _iconImage;
    [SerializeField] protected TextMeshProUGUI _valueText;
    
    private SkillStatPopUpUI _skillStatPopUp;
    private RectTransform _popUpPanelRectTransform => _skillStatPopUp.transform as RectTransform;

    private void Start()
    {
        _skillStatPopUp = UIHelper.Instance.GetSkillStatPopUpUI();
    }

    public virtual void Init(BaseSkillStatElement baseSkillStatElement)
    {
        _iconImage.sprite = baseSkillStatElement.statInfo.icon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos.y += _popUpPanelRectTransform.sizeDelta.y * 0.5f;
        _skillStatPopUp.transform.position = pos;
        
        _skillStatPopUp.Init(statInfo);
        _skillStatPopUp.OnPopUp();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _skillStatPopUp.EndPopUp();
    }
}
