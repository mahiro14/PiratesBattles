using System.Collections.Generic;
using UnityEngine;

public class CannonBallSystem
{
    GameState gameState;
    GameEvent gameEvent;

    PlayerComponent playerComp;
    CannonBallComponent cannonComp;

    List<CannonBallComponent> removeCannonBalls = new List<CannonBallComponent>();

    CannonPool cannonPool;
    public CannonBallSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
    }

    void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        cannonPool = new CannonPool(gameState, gameEvent);
        gameEvent.playerAttack += BallGene;
    }

    public void OnUpdate()
    {
    }

    public void OnFixUpdate()
    {
        if (gameState.gameStatus != GameStatus.IsPlaying) return;
        BallManage();
    }

    void BallManage()
    {
        int count = gameState.cannonBalls.Count;
        if (count == 0) return;
        for (int i=count-1 ; i>=0 ; --i)
        {
            cannonComp = gameState.cannonBalls[i];
            cannonComp.timer += Time.deltaTime;
            if (cannonComp.timer >= cannonComp.limitTime)
            {
                gameEvent.onRemoveCannon?.Invoke(cannonComp);
                return;
            }

            CollisionDetect(cannonComp);
        }
    }

    void BallGene()
    {
        GameObject cannonBall = cannonPool.OnGeneCannon(gameState.cannonBallPrefab);
        cannonBall.SetActive(true);
        CannonBallComponent cannonComp = cannonBall.GetComponent<CannonBallComponent>();
        gameState.cannonBalls.Add(cannonComp);

        cannonComp.timer = 0;
        Rigidbody ballRig = cannonComp.rig;
        cannonBall.transform.LookAt(cannonBall.transform.position + gameState.cannonMuzzle.transform.forward * 10);
        ballRig.AddForce(gameState.cannonMuzzle.transform.forward * playerComp.cannonSpeed);
    }

    void CollisionDetect(CannonBallComponent cannonComp)
    {
        RaycastHit hit;
        Debug.DrawRay(cannonComp.transform.position, cannonComp.transform.forward, Color.green);
        if (Physics.SphereCast(cannonComp.transform.position, 0.5f, cannonComp.transform.forward, out hit, 1f))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                EnemyBaseComponent enemyComp = hit.collider.gameObject.GetComponent<EnemyBaseComponent>();
                gameEvent.cannonHitEnemy?.Invoke(enemyComp);
                gameEvent.geneText?.Invoke(playerComp.gameObject, enemyComp.gameObject);
                gameEvent.onRemoveCannon?.Invoke(cannonComp);
                gameEvent.geneEffect?.Invoke(enemyComp.gameObject);
            }
        }
    }
}