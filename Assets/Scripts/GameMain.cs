using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameEvent gameEvent;

    [Header("Systems")]
    private GameSystem gameSystem;
    private PlayerSystem playerSystem;
    private CameraMoveSystem cameraMoveSystem;
    private PlayerMoveSystem playerMoveSystem;
    private PlayerAttackSystem playerAttackSystem;
    private EnemySpawnSystem enemySpawnSystem;
    private EnemyMoveSystem enemyMoveSystem;
    private CannonBallSystem cannonBallSystem;
    private EnemyDamageSystem enemyDamageSystem;
    
    void Start()
    {
        gameSystem = new GameSystem(gameState, gameEvent);
        playerSystem = new PlayerSystem(gameState, gameEvent);
        cameraMoveSystem = new CameraMoveSystem(gameState, gameEvent);
        playerMoveSystem = new PlayerMoveSystem(gameState, gameEvent);
        playerAttackSystem = new PlayerAttackSystem(gameState, gameEvent);
        enemySpawnSystem = new EnemySpawnSystem(gameState, gameEvent);
        enemyMoveSystem = new EnemyMoveSystem(gameState, gameEvent);
        cannonBallSystem = new CannonBallSystem(gameState, gameEvent);
        enemyDamageSystem = new EnemyDamageSystem(gameState, gameEvent);

        gameEvent.startGame?.Invoke();
    }

    void Update()
    {
        gameSystem.OnUpdate();
        playerSystem.OnUpdate();
        cameraMoveSystem.OnUpdate();
        playerMoveSystem.OnUpdate();
        enemyMoveSystem.OnUpdate();
        playerAttackSystem.OnUpdate();
        enemySpawnSystem.OnUpdate();
    }
    
    void FixedUpdate()
    {
        playerMoveSystem.OnFixUpdate();
        enemyMoveSystem.OnFixUpdate();
        cannonBallSystem.OnFixUpdate();
    }
}
