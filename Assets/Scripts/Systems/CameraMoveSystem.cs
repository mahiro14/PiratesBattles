using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSystem
{
    GameState gameState;
    GameEvent gameEvent;
    GameObject camera;
    PlayerComponent playerComponent;
    public CameraMoveSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        camera = _gameState.camera;
        playerComponent = _gameState.player.GetComponent<PlayerComponent>();
    }

    public void OnUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        camera.transform.position += camera.transform.forward * gameState.inputMove.Vertical * playerComponent.moveSpeed * Time.deltaTime;
        camera.transform.position += camera.transform.right * gameState.inputMove.Horizontal * playerComponent.moveSpeed * Time.deltaTime;
    }
}
