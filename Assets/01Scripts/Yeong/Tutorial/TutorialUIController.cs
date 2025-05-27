using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textBox;
    [SerializeField] private CanvasGroup _canvasGroup;

    public void ShowTutorialText(string txt)
    {
        _textBox.text = txt;
        _canvasGroup.DOFade(1, 0.5f);
        _canvasGroup.blocksRaycasts = true;
    }

    public void HideTutorialText()
    {
        _canvasGroup.DOFade(0, 0.5f);

        _canvasGroup.blocksRaycasts = false;
    }

}
