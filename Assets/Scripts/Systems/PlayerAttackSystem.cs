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

        playerComp = gameState.player.GetComponent<PlayerComponent>();
    }

    public void OnUpdate()
    {
        ShootCannon();
    }

    private void ShootCannon()
    {
        if ( gameState.timer < gameState.coolTime ) return;
        if ( !((Input.GetMouseButton(0) && Input.mousePosition.x >= Screen.width/2) || Input.GetKeyDown("space")) ) return;
        // foreach (GameObject cannonMuzzle in gameState.cannonmuzzle)
        // {
        //     GameObject cannonBall = GameObject.Instantiate(gameState.cannonBallPrefab, )
        // }
        GameObject cannonBall = GameObject.Instantiate(gameState.cannonBallPrefab, gameState.cannonMuzzle.transform.position, Quaternion.identity, gameState.cannonBallParent);
        Rigidbody ballRig = cannonBall.GetComponent<Rigidbody>();
        ballRig.AddForce(gameState.cannonMuzzle.transform.forward * playerComp.cannonSpeed);
        gameState.timer = 0;
    }
}
