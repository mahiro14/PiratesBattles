using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public Action startGame;
    public Action gameOver;
    public Action showResult;
    public Action retryGame;
    public Action backTitle;

    public Action playerAttack;
    public Action<EnemyBaseComponent>  cannonHitEnemy;
    public Action<EnemyBaseComponent> onRemoveEnemy;
    public Action<CannonBallComponent> onRemoveCannon;
}
