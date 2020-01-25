using UnityEngine;

class GameEnder : MonoBehaviour
{
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private EnemyCounter enemyCounter;

    private void OnEnable()
    {
        enemyCounter.EnemiesDefeated += OnEnemiesDefeated;
    }

    private void OnDisable()
    {
        enemyCounter.EnemiesDefeated -= OnEnemiesDefeated;
    }

    private void OnEnemiesDefeated()
    {
        _victoryScreen.SetActive(true);
    }
}
