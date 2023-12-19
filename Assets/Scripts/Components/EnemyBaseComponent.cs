using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseComponent : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public Canvas canvas;
    public Slider hpBar;
    public float dropXp;
    public float moveSpeed;

    // Attack
    public float attack;
    public Slider attackBar;
    public float attackTimer;
    public float coolTime;

    public virtual EnemyType GetEnemyType()
    {
        return EnemyType.Enemy;
    }
}
