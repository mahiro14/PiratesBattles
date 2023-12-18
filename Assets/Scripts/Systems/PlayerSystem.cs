using UnityEngine;

public class PlayerSystem
{
    GameState gameState;
    GameEvent gameEvent;
    PlayerComponent playerComp;
    public PlayerSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
    }

    void Init()
    {
        ResetPlayer();
        gameEvent.enemyAttack += UpdatePlayerHp;
        gameEvent.getXp += UpdatePlayerXp;
    }
    public void OnUpdate()
    {
        
    }

    void ResetPlayer()
    {
        GameObject player = GameObject.Instantiate(gameState.shipPrefab, gameState.basePos, Quaternion.identity);
        Debug.Log("set player");
        gameState.player = player;
        playerComp = gameState.player.GetComponent<PlayerComponent>();

        // HPバー
        playerComp.hp = playerComp.maxHp;
        playerComp.hpBar.maxValue = playerComp.maxHp;
        playerComp.hpBar.value = playerComp.maxHp;
        playerComp.hpText.SetText(playerComp.hp + "/" +playerComp.maxHp);

        // XPバー
        playerComp.maxXp = playerComp.baseXp * playerComp.level;
        playerComp.xpBar.maxValue = playerComp.maxXp;
        playerComp.xpBar.value = 0;
        playerComp.xpText.SetText(playerComp.xp + "/" +playerComp.maxXp);
        playerComp.levelText.SetText("Lv." +playerComp.level);
    }

    void UpdatePlayerHp(EnemyBaseComponent enemyComp)
    {
        playerComp.hp -= enemyComp.attack;
        if (playerComp.hp <= 0)
        {
            gameEvent.defeatPlayer?.Invoke();
        }
        playerComp.hpBar.value = playerComp.hp;
        playerComp.hpText.SetText(playerComp.hp + "/" +playerComp.maxHp);
    }

    void UpdatePlayerXp(EnemyBaseComponent enemyComp)
    {
        playerComp.xp += enemyComp.dropXp;
        if (playerComp.maxXp <= playerComp.xp)
        {
            playerComp.level++;
            playerComp.xp = playerComp.xp - playerComp.maxXp;
            playerComp.xpBar.value = playerComp.maxXp;
            playerComp.maxXp = playerComp.baseXp * playerComp.level;
            playerComp.xpBar.maxValue = playerComp.maxXp;
            playerComp.levelText.SetText("Lv." +playerComp.level);
        }
        else playerComp.xpBar.value = playerComp.xp;

        playerComp.xpText.SetText(playerComp.xp + "/" +playerComp.maxXp);
    }
}
