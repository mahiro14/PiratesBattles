using UnityEngine;

public class PlayerAttackSystem
{
    GameState gameState;
    GameEvent gameEvent;
    PlayerComponent playerComp;
    public PlayerAttackSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
    }

    private void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        gameState.cannonMuzzle = playerComp.muzzle;
    }

    public void OnUpdate()
    {
        if ( gameState.gameStatus != GameStatus.IsPlaying) return;
        ShootCannon();
    }

    private void ShootCannon()
    {
        if ( playerComp.attackTimer < playerComp.coolTime )
        {
            playerComp.attackTimer += Time.deltaTime;
            gameState.attackBar.value = playerComp.attackTimer;
            return;
        }
        // if ( !((Input.GetMouseButton(0) && Input.mousePosition.x >= Screen.width/2) || Input.GetKeyDown("space")) ) return;
        if ( !Input.GetKeyDown("space") ) return;
        // foreach (GameObject cannonMuzzle in gameState.cannonmuzzle)
        // {
        //     GameObject cannonBall = GameObject.Instantiate(gameState.cannonBallPrefab, )
        // }
        gameEvent.playerAttack?.Invoke();
        playerComp.attackTimer = 0;
    }
}
