using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameEvent gameEvent;
    // [SerializeField] List<>

    [Header("Systems")]
    private GameSystem gameSystem;
    private CameraMoveSystem cameraMoveSystem;
    private PlayerMoveSystem playerMoveSystem;
    private PlayerAttackSystem playerAttackSystem;
    
    void Start()
    {
        gameSystem = new GameSystem(gameState, gameEvent);
        cameraMoveSystem = new CameraMoveSystem(gameState, gameEvent);
        playerMoveSystem = new PlayerMoveSystem(gameState, gameEvent);
        playerAttackSystem = new PlayerAttackSystem(gameState, gameEvent);
    }

    void Update()
    {
        gameSystem.OnUpdate();
        cameraMoveSystem.OnUpdate();
        playerMoveSystem.OnUpdate();
        playerAttackSystem.OnUpdate();
    }
}
