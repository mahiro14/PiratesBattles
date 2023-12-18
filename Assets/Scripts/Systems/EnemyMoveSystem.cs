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
        EnemyAction();
    }

    void ControlEnemyUI()
    {
        foreach(EnemyBaseComponent enemyComp in gameState.enemies)
        {
            enemyComp.hpBar.transform.LookAt(Camera.main.transform);
        }
    }

    void EnemyAction()
    {
        foreach(EnemyBaseComponent enemyComp in gameState.enemies)
        {
            enemyComp.attackTimer += Time.deltaTime;
            MoveTowardsPlayer(enemyComp);
        }
    }

    void MoveTowardsPlayer(EnemyBaseComponent enemyComp)
    {
        enemyComp.transform.LookAt(playerComp.transform.position);
        Vector3 direction = playerObj.transform.position - enemyComp.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(enemyComp.transform.position, direction, out hit, 0.5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                EnemyCollision(enemyComp);
                return;
            }
        }
        enemyComp.transform.position += enemyComp.transform.forward * enemyComp.moveSpeed * Time.deltaTime;
    }

    void EnemyCollision(EnemyBaseComponent enemyComp)
    {
        if (enemyComp.attackTimer > enemyComp.coolTime)
        {
            gameEvent.enemyAttack?.Invoke(enemyComp);
            enemyComp.attackTimer = 0;
        }
    }
}
