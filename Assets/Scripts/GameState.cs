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
    public GameObject camera;
    public FloatingJoystick inputMove;
    public GameObject redSlime;
    public List<RedSlimeComponent> redSlimes;
    public GameObject blueTurtle;
    public List<BlueTurtleComponent> blueTurtles;
}
