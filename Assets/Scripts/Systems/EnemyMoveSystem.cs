using UnityEngine;

public class EnemyMoveSystem
{
    GameState gameState;
    GameEvent gameEvent;
    GameObject playerObj;
    PlayerComponent playerComp;
    Rigidbody rig;

    float sphereCastRadius = 0.5f;
    float sphereCastDistance = 1f;
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
    }

    public void OnUpdate()
    {
        if (gameState.gameStatus != GameStatus.IsPlaying) return;
        ControlEnemyUI();
    }

    public void OnFixUpdate()
    {
        if (gameState.gameStatus != GameStatus.IsPlaying) return;
        EnemyAction();
    }

    void ControlEnemyUI()
    {
            int count = gameState.activeEnemies.Count;
            if (count == 0) return;
            for (int i=count-1 ; i>=0 ; --i)
            {
                gameState.activeEnemies[i].canvas.transform.LookAt(Camera.main.transform);
            }
    }

    void EnemyAction()
    {
        int count = gameState.activeEnemies.Count;
        if (count == 0) return;
        for (int i=count-1 ; i>=0 ; --i)
        {
            gameState.activeEnemies[i].attackTimer += Time.deltaTime;
            gameState.activeEnemies[i].attackBar.value = gameState.activeEnemies[i].attackTimer;
            MoveTowardsPlayer(gameState.activeEnemies[i]);
        }
    }

    void MoveTowardsPlayer(EnemyBaseComponent enemyComp)
    {
        enemyComp.transform.LookAt(playerComp.transform.position);
        Vector3 direction = playerObj.transform.position - enemyComp.transform.position;
        RaycastHit hit;

        if (Physics.SphereCast(enemyComp.transform.position, sphereCastRadius, direction, out hit, sphereCastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                EnemyCollision(enemyComp);
                return;
            }
        }
        enemyComp.rig.velocity = Vector3.zero;
        enemyComp.transform.position += enemyComp.transform.forward * enemyComp.moveSpeed * Time.deltaTime;
    }

    void EnemyCollision(EnemyBaseComponent enemyComp)
    {
        if (enemyComp.attackTimer > enemyComp.coolTime)
        {
            gameEvent.enemyAttack?.Invoke(enemyComp);
            gameEvent.geneText?.Invoke(enemyComp.gameObject, playerObj);
            gameEvent.geneEffect?.Invoke(playerComp.gameObject);
            enemyComp.attackTimer = 0;
        }
    }
}
