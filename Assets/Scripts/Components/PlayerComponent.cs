using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour
{
    public float level;
    public TextMeshProUGUI levelText;

    // Hp
    public float hp;
    public float maxHp;

    // Score
    public float score;

    // Xp
    public float xp;
    public float maxXp;
    public float baseXp;
    public Slider xpBar;
    public TextMeshProUGUI xpText;

    public float moveSpeed;
    public GameObject muzzle;
    public float cannonSpeed;

    // Attack
    public float attack;
    public float attackTimer;
    public float coolTime;

    // Timer
    public TextMeshProUGUI timeText;
}
