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
        gameEvent.resetGame += ResetGame;
        gameEvent.showTitle += ResetPlayer;
    }

    private void Init()
    {
        gameEvent.enemyAttack += UpdatePlayerHp;
        gameEvent.getXp += UpdatePlayerXp;
        gameEvent.addScore += UpdateScoreText;
    }
    public void OnUpdate()
    {
        
    }

    private void ResetGame()
    {
        GameObject.Destroy(gameState.player);
    }

    private void ResetPlayer()
    {
        // if (gameState.player != null) gameState.
        GameObject player = GameObject.Instantiate(gameState.shipPrefab, gameState.playerBasePos, Quaternion.identity);
        Debug.Log("set player");
        gameState.player = player;
        playerComp = gameState.player.GetComponent<PlayerComponent>();

        // HPバー
        playerComp.hp = playerComp.maxHp;
        gameState.hpBar.maxValue = playerComp.maxHp;
        gameState.hpBar.value = playerComp.maxHp;
        gameState.hpText.SetText(playerComp.hp + "/" +playerComp.maxHp);

        // XPバー
        // playerComp.maxXp = playerComp.baseXp * playerComp.level;
        // playerComp.xpBar.maxValue = playerComp.maxXp;
        // playerComp.xpBar.value = 0;
        // playerComp.xpText.SetText(playerComp.xp + "/" +playerComp.maxXp);
        // playerComp.levelText.SetText(playerComp.level.ToString());

        // Attackバー
        playerComp.attackTimer = 0;
        gameState.attackBar.value = 0;
        gameState.attackBar.maxValue = playerComp.coolTime;

        // Score
        playerComp.score = 0;
        gameState.scoreText.SetText(playerComp.score.ToString());
    }

    private void UpdatePlayerHp(EnemyBaseComponent enemyComp)
    {
        playerComp.hp -= enemyComp.attack;
        if (playerComp.hp <= 0)
        {
            gameEvent.gameOver?.Invoke();
        }
        gameState.hpBar.value = playerComp.hp;
        gameState.hpText.SetText(playerComp.hp + "/" +playerComp.maxHp);
    }

    private void UpdatePlayerXp(EnemyBaseComponent enemyComp)
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

    private void UpdateScoreText(EnemyBaseComponent enemyComp)
    {
        playerComp.score += enemyComp.score;
        gameState.scoreText.SetText(playerComp.score.ToString());
    }
}
