using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialStepSO", menuName = "SO/TutorialStepSO")]
public class TutorialStepSO : ScriptableObject
{
    public string StepName;                // ex) "Move", "Attack"
    [TextArea]
    public string Description;             // ȭ�鿡 ������ ���� �ؽ�Ʈ
    public string StepClassName;           // ex) "MoveTutorialStep", "AttackTutorialStep"
}
