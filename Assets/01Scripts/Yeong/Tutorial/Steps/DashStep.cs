using System;
using UnityEngine;
using YH.Players;

public class DashStep : TutorialStepBase
{
    private bool _dashed;
    private Player _player;
    public DashStep(TutorialManager manager, TutorialStepSO so) : base(manager, so)
    {
        _player = manager.Player;
    }

    public override void Enter()
    {
        base.Enter();
        _dashed = false;
        _player.PlayerInput.DashEvent += HandleCheckDashEvent;
    }

    public override void Exit()
    {
        base.Exit();
        _player.PlayerInput.DashEvent -= HandleCheckDashEvent;
    }

    private void HandleCheckDashEvent()
    {
        if (!_dashed)
            _dashed = true;
    }

    public override bool IsStepCompleted()
    {
        return _dashed;
    }
}
