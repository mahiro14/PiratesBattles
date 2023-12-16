using UnityEngine;

public class EnemyBaseComponent : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public float xp;
    public float attack;
    public float moveSpeed;

    public float attackTimer;
    public float coolTime;

    public virtual EnemyType GetEnemyType()
    {
        return EnemyType.Enemy;
    }
}
