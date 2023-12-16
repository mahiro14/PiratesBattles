using UnityEngine;

public class RedSlimeComponent : EnemyBaseComponent
{
    public override EnemyType GetEnemyType()
    {
        return EnemyType.RedSlime;
    }
}
