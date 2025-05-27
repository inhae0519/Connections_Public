using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialStepSO", menuName = "SO/TutorialStepSO")]
public class TutorialStepSO : ScriptableObject
{
    public string StepName;                // ex) "Move", "Attack"
    [TextArea]
    public string Description;             // 화면에 보여줄 설명 텍스트
    public string StepClassName;           // ex) "MoveTutorialStep", "AttackTutorialStep"
}
