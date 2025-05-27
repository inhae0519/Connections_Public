using UnityEngine;

public class DefaultRoomStep : TutorialStepBase
{
    private bool _isRoomCompleted;
    public DefaultRoomStep(TutorialManager manager, TutorialStepSO so) : base(manager, so)
    {
        //TODO:여기부터
        
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override bool IsStepCompleted()
    {
        return _isRoomCompleted;
    }
}
