using UnityEngine;

public class PlayerMoveSystem
{
    GameState gameState;
    GameEvent gameEvent;
    GameObject playerObj;
    PlayerComponent playerComp;
    Vector3 pos;
    public PlayerMoveSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        playerObj = gameState.player;
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        pos = playerObj.transform.position;
    }

    public void OnUpdate()
    {
        pos += Vector3.forward * gameState.inputMove.Vertical * playerComp.moveSpeed * Time.deltaTime;
        pos += Vector3.right * gameState.inputMove.Horizontal * playerComp.moveSpeed * Time.deltaTime;

        if ( pos.x > 1840 )
        {
            pos.x = 1840;
        }
        else if ( pos.x < -1840 )
        {
            pos.x = -1840;
        }

        if ( pos.z > 1840 )
        {
            pos.z = 1840;
        }
        else if( pos.z < -1840 )
        {
            pos.z = -1840;
        }

        playerObj.transform.position = pos;

        float ver = gameState.inputMove.Vertical;
        float hor = gameState.inputMove.Horizontal;
        Vector3 direction = new Vector3(hor, 0, ver);
        if (ver != 0 || hor != 0)
        {
            playerObj.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
