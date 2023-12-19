using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameStatus
{
    Ready,
    IsPlaying,
    PauseGame,
    GameOver,
    Result,
}

public enum EnemyType
{
    Enemy,
    RedSlime,
    BlueTurtle,
}

[System.Serializable]
public class GameState
{
    [Header("System")]
    public GameStatus gameStatus;
    public GameState gameState;
    public FloatingJoystick inputMove;
    public Vector3 basePos = new Vector3(0f, 0f, 0f);
    public Button pauseButton;
    public List<BaseScreen> screens;

    [Header("Effect")]
    public GameObject damageEffectPrefab;
    public Transform parentEffects;
    public List<DamageEffectComponent> damageEffects = new List<DamageEffectComponent>();

    [Header("Player")]
    public GameObject player;
    public GameObject shipPrefab;
    public GameObject camera;

    [Header("Enemy")]
    public GameObject enemy;
    public List<EnemyBaseComponent> enemies = new List<EnemyBaseComponent>();
    public List<EnemyBaseComponent> activeEnemies = new List<EnemyBaseComponent>();
    public Transform parentEnemies;
    public float spawnCoolTime;
    public float enemyCountLimit;

    [Header("Enemy Prefab")]
    public List<GameObject> enemyPrefab = new List<GameObject>();
    public GameObject redSlimePrefab;
    public GameObject blueTurtlePrefab;

    [Header("DamageTexts")]
    public Transform parentDamageText;
    public GameObject prefabDamageText;
    public List<DamageTextComponent> damageTexts;

    [Header("Timer")]
    public float gameTimer;
    public float enemySpawnTimer;

    [Header("Camera")]
    public GameObject mainCamera;
    public GameObject minimapCamera;

    [Header("Timer")]
    public GameObject cannonBallPrefab;
    public Transform parentCannonBall;
    public List<CannonBallComponent> cannonBalls = new List<CannonBallComponent>();
    public GameObject cannonMuzzle;
    public GameObject cannonMuzzlePrefab;
    public Transform parentCannonMuzzle;
}
