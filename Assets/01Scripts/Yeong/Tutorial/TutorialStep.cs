using UnityEngine;

public enum TutorialStepType
{
    Move,
    Attack,
    Skill,
    Item,
    Interact,
    Collect,
    Upgrade,
    Trade,
    Quest
}
public abstract class TutorialStep
{
    public abstract void Init(TutorialStepSO tutorialStepSO);
    public abstract void StartStep();
    public abstract void UpdateStep();
    public abstract bool IsStepCompleted();
    public abstract void EndStep();
}
