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

    private void Init()
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

    private void MoveCamera()
    {
        pos = new Vector3(gameState.player.transform.position.x, 0, gameState.player.transform.position.z);

        camera.transform.position = pos;
    }
}
