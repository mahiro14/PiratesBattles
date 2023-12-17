using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    Ready,
    IsPlaying,
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
    public GameState gameState;
    public FloatingJoystick inputMove;
    public Vector3 basePos = new Vector3(0f, 0f, 0f);

    [Header("Player")]
    public GameObject player;
    public GameObject shipPrefab;
    public GameObject camera;

    [Header("Enemy")]
    public GameObject enemy;
    public List<EnemyBaseComponent> enemies = new List<EnemyBaseComponent>();
    public Transform parentEnemies;
    public float spawnCoolTime;
    public float enemyCountLimit;

    [Header("Enemy Prefab")]
    public List<GameObject> enemyPrefab = new List<GameObject>();
    public GameObject redSlimePrefab;
    public GameObject blueTurtlePrefab;

    [Header("Timer")]
    public float gameTimer;
    public float enemySpawnTimer;

    [Header("Minimap")]
    public GameObject minimapCamera;

    [Header("Timer")]
    public GameObject cannonBallPrefab;
    public Transform cannonBallParent;
    public List<CannonBallComponent> cannonBalls = new List<CannonBallComponent>();
    public GameObject cannonMuzzle;
    public GameObject cannonMuzzlePrefab;
    public Transform cannonMuzzleParent;
}
