using System;
using UnityEngine;
using YH.Players;

public class AttackStep : TutorialStepBase
{
    private bool _attacked;
    private Player _player;
    public AttackStep(TutorialManager manager, TutorialStepSO so) : base(manager, so)
    {
        _player = manager.Player;
    }

    public override void Enter()
    {
        base.Enter();
        _attacked = false;
        _player.PlayerInput.FireEvent += HandleCheckAttackEvent;
    }

    private void HandleCheckAttackEvent(bool isClick)
    {
        if (!_attacked && isClick)
        {
            _attacked = true;
        }
    }

    public override bool IsStepCompleted()
    {
        return _attacked;
    }
}
