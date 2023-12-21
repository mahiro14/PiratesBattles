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

        gameEvent.startGame += Init;
        gameEvent.resetGame += ResetGame;
    }

    void Init()
    {
        camera = gameState.camera;
        playerComponent = gameState.player.GetComponent<PlayerComponent>();
        pos = camera.transform.position;
    }

    public void OnUpdate()
    {
        if (gameState.gameStatus != GameStatus.IsPlaying) return;
        MoveCamera();
    }

    private void ResetGame()
    {
        camera.transform.position = gameState.cameraBasePos;
        pos = camera.transform.position;
    }

    void MoveCamera()
    {
        float ver = gameState.inputMove.Vertical;
        float hor = gameState.inputMove.Horizontal;

        pos += camera.transform.forward * ver * playerComponent.moveSpeed * Time.deltaTime;
        pos += camera.transform.right * hor * playerComponent.moveSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -1840, 1840);
        pos.z = Mathf.Clamp(pos.z, -1840, 1840);

        camera.transform.position = pos;
    }
}
