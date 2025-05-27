using UnityEngine;

public abstract class TutorialStepBase
{
    protected readonly TutorialManager _manager;
    protected readonly TutorialStepSO _so;

    protected TutorialStepBase(TutorialManager manager, TutorialStepSO so)
    {
        _manager = manager;
        _so = so;
    }

    public virtual void Enter()
    {
        _manager.UI.ShowTutorialText(_so.Description);
    }

    public abstract bool IsStepCompleted();

    public virtual void Exit()
    {
        _manager.UI.HideTutorialText();
    }
}
