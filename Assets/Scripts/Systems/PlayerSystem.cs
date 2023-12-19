using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
        gameEvent.showTitle += ResetPlayer;
    }

    void Init()
    {
        gameEvent.enemyAttack += UpdatePlayerHp;
        gameEvent.getXp += UpdatePlayerXp;
        gameEvent.addScore += UpdateScoreText;
    }
    public void OnUpdate()
    {
        
    }

    void ResetPlayer()
    {
        // if (gameState.player != null) gameState.
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
        // playerComp.maxXp = playerComp.baseXp * playerComp.level;
        // playerComp.xpBar.maxValue = playerComp.maxXp;
        // playerComp.xpBar.value = 0;
        // playerComp.xpText.SetText(playerComp.xp + "/" +playerComp.maxXp);
        // playerComp.levelText.SetText(playerComp.level.ToString());

        // Attackバー
        playerComp.attackTimer = 0;
        playerComp.attackBar.value = 0;
        playerComp.attackBar.maxValue = playerComp.coolTime;

        // Score
        playerComp.score = 0;
        playerComp.scoreText.SetText(playerComp.score.ToString());
    }

    void UpdatePlayerHp(EnemyBaseComponent enemyComp)
    {
        playerComp.hp -= enemyComp.attack;
        if (playerComp.hp <= 0)
        {
            gameEvent.gameOver?.Invoke();
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

    void UpdateScoreText(EnemyBaseComponent enemyComp)
    {
        playerComp.score += enemyComp.score;
        playerComp.scoreText.SetText(playerComp.score.ToString());
    }
}
