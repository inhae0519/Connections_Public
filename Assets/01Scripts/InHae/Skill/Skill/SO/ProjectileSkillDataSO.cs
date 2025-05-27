using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ProjectileSkillDataSO", menuName = "SO/SkillData/ProjectileSkillDataSO")]
public class ProjectileSkillDataSO : SkillFieldDataSO
{
    public int skillObjCreateCount;
    private int SkillObjCreateCount;

    public float projMoveSpeed;
    private float ProjMoveSpeed;

    public float skillObjCreateDelay;  // ������ ��ų�� ��� �ణ ������ �־����.
    private float SkillObjCreateDelay;  // ������ ��ų�� ��� �ణ ������ �־����.

    public int penetrationCount;  //���� ���ɿ���
    private int PenetrationCount;  //���� ���ɿ���

    public bool canBeHit;
    private bool CanBeHit;

    public int reflectionCount;
    private int ReflectionCount;

    public List<TrajectoryType> currentTrajectoryList;

    public override void SetDefaultValues()
    {
        SkillObjCreateCount = skillObjCreateCount;
        ProjMoveSpeed = projMoveSpeed;
        SkillObjCreateDelay = skillObjCreateDelay;
        PenetrationCount = penetrationCount;
        CanBeHit = canBeHit;
        ReflectionCount = reflectionCount;
    }

    public override void Init()
    {
        skillObjCreateCount = SkillObjCreateCount;
        projMoveSpeed = ProjMoveSpeed;
        skillObjCreateDelay = SkillObjCreateDelay;
        penetrationCount = PenetrationCount;
        canBeHit = CanBeHit;
        reflectionCount = ReflectionCount;

        currentTrajectoryList.Clear();
    }
}
