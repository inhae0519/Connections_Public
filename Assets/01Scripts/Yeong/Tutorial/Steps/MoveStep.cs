using System;
using UnityEngine;
using YH.Players;

public class MoveStep : TutorialStepBase
{
    private bool _moved;
    private Player _player;
    public MoveStep(TutorialManager manager, TutorialStepSO so) : base(manager, so)
    {
        _player = manager.Player;
    }

    public override void Enter()
    {
        base.Enter();
        _moved = false;
        _player.PlayerInput.MoveEvent += HandleCheckMoveEvent;
    }

    public override void Exit()
    {
        base.Exit();
        _player.PlayerInput.MoveEvent -= HandleCheckMoveEvent;
    }

    private void HandleCheckMoveEvent()
    {
        if (!_moved)
            _moved = true;
    }

    public override bool IsStepCompleted()
    {
        return _moved;
    }
}
