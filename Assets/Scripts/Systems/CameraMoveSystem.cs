using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSystem
{
    GameState gameState;
    GameEvent gameEvent;
    GameObject camera;
    PlayerComponent playerComponent;
    Vector3 pos;
    public CameraMoveSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        camera = gameState.camera;
        playerComponent = _gameState.player.GetComponent<PlayerComponent>();
        pos = camera.transform.position;
    }

    public void OnUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        pos += camera.transform.forward * gameState.inputMove.Vertical * playerComponent.moveSpeed * Time.deltaTime;
        pos += camera.transform.right * gameState.inputMove.Horizontal * playerComponent.moveSpeed * Time.deltaTime;

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

        camera.transform.position = pos;
    }
}
