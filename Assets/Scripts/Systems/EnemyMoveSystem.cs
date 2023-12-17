using UnityEngine;

public class EnemyMoveSystem
{
    GameState gameState;
    GameEvent gameEvent;
    GameObject playerObj;
    PlayerComponent playerComp;
    EnemyBaseComponent enemyComp;
    Vector3 pos;
    Rigidbody rig;
    public EnemyMoveSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
    }

    void Init()
    {
        playerObj = gameState.player;
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        pos = playerObj.transform.position;
    }

    public void OnUpdate()
    {
        ControlEnemyUI();
    }

    public void OnFixUpdate()
    {
        MoveTowardsPlayer();
    }

    void ControlEnemyUI()
    {
        enemyComp.hpBar.transform.LookAt(Camera.main.transform);
    }

    void MoveTowardsPlayer()
    {
        // Raycastでぶつかってたら攻撃の挙動、なかったらプレイヤーに向かって速度0にしてから向かわせる
        if (enemyComp.attackTimer < enemyComp.coolTime) return;
        enemyComp.attackTimer = 0;
        // EnemyHitPlayer();
        enemyComp.transform.position += enemyComp.transform.forward * enemyComp.moveSpeed * Time.deltaTime;
    }
}
