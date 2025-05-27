using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using IH.EventSystem.NodeEvent.SkillNodeEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YH.EventSystem;

public class SkillInfoPanelUI : MonoBehaviour
{
    [SerializeField] private GameEventChannelSO _skillNodeEventChannel;
    [SerializeField] private float _tweenTime;
    
    [SerializeField] private Image _skillIcon;
    private TextMeshProUGUI _skillName;
    private TextMeshProUGUI _skillDescription;

    [SerializeField] private Transform _statTextParent;
    private Dictionary<SkillFieldDataType, SkillStatTextUI> _statTextUI = new Dictionary<SkillFieldDataType, SkillStatTextUI>();
    
    [SerializeField] private RectTransform _arrowTrm;
    [SerializeField] private float _offset;
    private Vector3 _arrowDefaultScale;
    
    private bool _isOpen = true;
    private Vector3 _initPos;

    private void Awake()
    {
        _initPos = transform.localPosition;
        _arrowDefaultScale = _arrowTrm.localScale;
            
        _skillName = transform.Find("SkillName").GetComponent<TextMeshProUGUI>();
        _skillDescription = transform.Find("Description").GetComponent<TextMeshProUGUI>();

        _statTextParent.GetComponentsInChildren<SkillStatTextUI>().ToList()
            .ForEach(x => _statTextUI.Add(x.fieldType, x));
        
        _skillNodeEventChannel.AddListener<SkillStatViewInitEvent>(HandleSkillStatViewInit);
        _skillNodeEventChannel.AddListener<EquipSkillSelectEvent>(HandleSkillSelect);
    }

    private void OnDestroy()
    {
        _skillNodeEventChannel.RemoveListener<SkillStatViewInitEvent>(HandleSkillStatViewInit);
        _skillNodeEventChannel.RemoveListener<EquipSkillSelectEvent>(HandleSkillSelect);
    }
    
    private void HandleSkillSelect(EquipSkillSelectEvent evt)
    {
        if (evt.isSelected)
        {
            Vector3 pos = _initPos;
            pos.x = 0;
            pos.x += _offset;

            transform.DOLocalMove(pos, _tweenTime).SetUpdate(true);
        }
        else
        {
            transform.DOLocalMove(_initPos, _tweenTime).SetUpdate(true);
            _arrowTrm.localScale = _arrowDefaultScale;
            _isOpen = true;
        }
    }

    private void HandleSkillStatViewInit(SkillStatViewInitEvent evt)
    {
        _skillIcon.sprite = evt.skillInventoryItem.data.icon;
        _skillName.text = evt.skillInventoryItem.data.itemName;
        _skillDescription.text = evt.skillInventoryItem.data.itemDescription;

        foreach (var statTextUI in _statTextUI)
            statTextUI.Value.Init(evt.skill.GetSkillData(statTextUI.Key));
    }

    // Button 함수
    public void ButtonClickInOut()
    {
        Vector3 scale = _arrowTrm.localScale;
        scale.x *= -1;
        _arrowTrm.localScale = scale;

        Vector3 pos = transform.localPosition;
        
        if (_isOpen)
            pos.x -= _offset;
        else
            pos.x += _offset;

        transform.DOLocalMove(pos, _tweenTime).SetUpdate(true);
        _isOpen = !_isOpen;
    }
}
