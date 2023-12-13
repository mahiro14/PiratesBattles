using UnityEngine;

public class PlayerMoveSystem
{
    GameState gameState;
    GameEvent gameEvent;
    GameObject playerObj;
    PlayerComponent playerComp;
    public PlayerMoveSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        playerObj = gameState.player;
        playerComp = gameState.player.GetComponent<PlayerComponent>();
    }

    public void OnUpdate()
    {
        playerObj.transform.position += Vector3.forward * gameState.inputMove.Vertical * playerComp.moveSpeed * Time.deltaTime;
        playerObj.transform.position += Vector3.right * gameState.inputMove.Horizontal * playerComp.moveSpeed * Time.deltaTime;

        float ver = gameState.inputMove.Vertical;
        float hor = gameState.inputMove.Horizontal;
        Vector3 direction = new Vector3(hor, 0, ver);
        if (ver != 0 || hor != 0)
        {
            playerObj.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
