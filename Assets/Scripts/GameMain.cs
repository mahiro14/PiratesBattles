using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameEvent gameEvent;
    // [SerializeField] List<>

    [Header("Systems")]
    private CameraMoveSystem cameraMoveSystem;
    private PlayerMoveSystem playerMoveSystem;
    
    void Start()
    {
        cameraMoveSystem = new CameraMoveSystem(gameState, gameEvent);
        playerMoveSystem = new PlayerMoveSystem(gameState, gameEvent);
    }

    void Update()
    {
        cameraMoveSystem.OnUpdate();
        playerMoveSystem.OnUpdate();
    }
}
