using UnityEngine;

public class PlayerMoveSystem
{
    GameState gameState;
    GameEvent gameEvent;
    GameObject playerObj;
    PlayerComponent playerComp;
    Vector3 pos;
    Rigidbody rig;
    public PlayerMoveSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
    }

    private void Init()
    {
        playerObj = gameState.player;
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        pos = playerObj.transform.position;
        rig = playerObj.GetComponent<Rigidbody>();
    }

    public void OnUpdate()
    {

    }

    public void OnFixUpdate()
    {
        if ( gameState.gameStatus != GameStatus.IsPlaying) return;
        MovePlayer();
    }

    private void MovePlayer()
    {
        float ver = gameState.inputMove.Vertical;
        float hor = gameState.inputMove.Horizontal;
        
        Vector3 velocity = Vector3.forward * ver * playerComp.moveSpeed;
        velocity += Vector3.right * hor * playerComp.moveSpeed;
        rig.velocity = velocity;

        // -1840~1840の間にClump
        Vector3 clampedPosition = rig.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -1840, 1840);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -1840, 1840);
        rig.MovePosition(clampedPosition);

        Vector3 direction = new Vector3(hor, 0, ver);
        if (ver != 0 || hor != 0)
        {
            playerObj.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
