using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    Ready,
    IsPlaying,
    GameOver,
    Result,
}

[System.Serializable]
public class GameState
{
    public GameObject player;
    public GameObject shipPrefab;
    public float timer;
    public GameObject camera;
    public FloatingJoystick inputMove;
    public GameObject redSlime;
    public List<RedSlimeComponent> redSlimes;
    public GameObject blueTurtle;
    public List<BlueTurtleComponent> blueTurtles;

    // Cannon
    public GameObject cannonBallPrefab;
    public Transform cannonBallParent;
    public List<CannonBallComponent> cannonBalls;
    public GameObject cannonMuzzle;
    public GameObject cannonMuzzlePrefab;
    public Transform cannonMuzzleParent;
    public float coolTime;
}
