using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialStepListSO", menuName = "SO/TutorialStepListSO")]
public class TutorialStepListSO : ScriptableObject
{
    public List<TutorialStepSO> steps;
}
