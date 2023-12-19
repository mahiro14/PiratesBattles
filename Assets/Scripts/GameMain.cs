using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameEvent gameEvent;
    [SerializeField] List<BaseScreen> screens;

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
    private DamageTextSystem damageTextSystem;
    private EffectSystem effectSystem;
    
    void Start()
    {
        playerSystem = new PlayerSystem(gameState, gameEvent);
        gameSystem = new GameSystem(gameState, gameEvent);
        cameraMoveSystem = new CameraMoveSystem(gameState, gameEvent);
        playerMoveSystem = new PlayerMoveSystem(gameState, gameEvent);
        playerAttackSystem = new PlayerAttackSystem(gameState, gameEvent);
        enemySpawnSystem = new EnemySpawnSystem(gameState, gameEvent);
        enemyMoveSystem = new EnemyMoveSystem(gameState, gameEvent);
        cannonBallSystem = new CannonBallSystem(gameState, gameEvent);
        enemyDamageSystem = new EnemyDamageSystem(gameState, gameEvent);
        damageTextSystem = new DamageTextSystem(gameState, gameEvent);
        effectSystem = new EffectSystem(gameState, gameEvent);

        gameEvent.showTitle?.Invoke();

        foreach(BaseScreen screen in gameState.screens)
        {
            screen.Init(gameState, gameEvent);
        }
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
        damageTextSystem.OnUpdate();
        effectSystem.OnUpdate();
    }
    
    void FixedUpdate()
    {
        playerMoveSystem.OnFixUpdate();
        enemyMoveSystem.OnFixUpdate();
        cannonBallSystem.OnFixUpdate();
    }
}
