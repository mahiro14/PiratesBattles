using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public Action startGame;
    public Action defeatPlayer;
    public Action gameOver;
    public Action showResult;
    public Action retryGame;
    public Action backTitle;

    public Action playerAttack;
    public Action<GameObject, GameObject> geneText;
    public Action<GameObject> geneEffect;
    public Action<EnemyBaseComponent> getXp;
    public Action<EnemyBaseComponent> addScore;
    public Action<EnemyBaseComponent> enemyAttack;
    public Action<EnemyBaseComponent>  cannonHitEnemy;
    public Action<EnemyBaseComponent> onRemoveEnemy;
    public Action<CannonBallComponent> onRemoveCannon;
    public Action<DamageTextComponent> removeText;
    public Action<DamageEffectComponent> removeEffect;
}
