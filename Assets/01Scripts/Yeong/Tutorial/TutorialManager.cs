using System;
using System.Collections.Generic;
using UnityEngine;
using YH.Entities;
using YH.Players;

public class TutorialManager : MonoSingleton<TutorialManager>
{
    [SerializeField] private TutorialStepListSO _stepList;
    [SerializeField] private TutorialUIController _ui;
    [SerializeField] private PlayerManagerSO _playerSO;
    private Dictionary<TutorialStepType, TutorialStepBase> _steps;
    private TutorialStepType _currentStepType;
    private bool _isRunning;
    public TutorialUIController UI => _ui;
    
    public Player Player => _playerSO.Player;



    private void Awake()
    {
        // SO로부터 Dictionary 구성
        _steps = new Dictionary<TutorialStepType, TutorialStepBase>();
        foreach (var so in _stepList.steps)
        {
            if (!Enum.TryParse<TutorialStepType>(so.StepName, out var stepType))
            {
                Debug.LogWarning($"Invalid TutorialStepType for " + so.StepName);
                continue;
            }
            string fullName = so.StepClassName;
            var type = Type.GetType(fullName);
            if (type == null)
            {
                Debug.LogWarning($"Tutorial Step class not found: {fullName}");
                continue;
            }
            var instance = Activator.CreateInstance(type, this, so) as TutorialStepBase;
            if (instance != null)
                _steps.Add(stepType, instance);
        }
    }

    private void Start()
    {
        if (_steps.Count == 0)
            return;

        _currentStepType = _steps.Keys.GetEnumerator().Current;
        StartStep(_currentStepType);
    }

    private void Update()
    {
        if (!_isRunning) return;

        var step = _steps[_currentStepType];
        if (step.IsStepCompleted())
        {
            step.Exit();
            AdvanceToNextStep();
        }
    }

    private void StartStep(TutorialStepType stepType)
    {
        _currentStepType = stepType;
        _isRunning = true;
        _steps[_currentStepType].Enter();
    }

    private void AdvanceToNextStep()
    {
        var enumValues = (TutorialStepType[])Enum.GetValues(typeof(TutorialStepType));
        int currentIndex = Array.IndexOf(enumValues, _currentStepType);
        int nextIndex = currentIndex + 1;
        if (nextIndex < enumValues.Length && _steps.ContainsKey(enumValues[nextIndex]))
        {
            StartStep(enumValues[nextIndex]);
        }
        else
        {
            FinishTutorial();
        }
    }

    private void FinishTutorial()
    {
        _isRunning = false;
        Debug.Log("=== Tutorial Complete ===");
        // 필요 시 이벤트 호출 or 자동 제거 등
    }
}
