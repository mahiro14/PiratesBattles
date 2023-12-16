using UnityEngine;

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
    private EnemySpawnSystem enemySpawnSystem;
    
    void Start()
    {
        gameSystem = new GameSystem(gameState, gameEvent);
        cameraMoveSystem = new CameraMoveSystem(gameState, gameEvent);
        playerMoveSystem = new PlayerMoveSystem(gameState, gameEvent);
        playerAttackSystem = new PlayerAttackSystem(gameState, gameEvent);
        enemySpawnSystem = new EnemySpawnSystem(gameState, gameEvent);
    }

    void Update()
    {
        gameSystem.OnUpdate();
        cameraMoveSystem.OnUpdate();
        playerMoveSystem.OnUpdate();
        playerAttackSystem.OnUpdate();
        enemySpawnSystem.OnUpdate();
    }
    
    void FixedUpdate()
    {
        playerMoveSystem.OnFixUpdate();
    }
}
