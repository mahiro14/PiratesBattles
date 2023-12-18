using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour
{
    public float level;
    public TextMeshProUGUI levelText;
    public float hp;
    public float maxHp;
    public Slider hpBar;
    public TextMeshProUGUI hpText;
    public float xp;
    public float maxXp;
    public float baseXp;
    public Slider xpBar;
    public TextMeshProUGUI xpText;
    public float moveSpeed;

    public GameObject muzzle;
    public float cannonSpeed;

    public float attack;
    public float attackTimer;

    public float coolTime;
}
