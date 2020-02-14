using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int _enemiesLeftToWin = 0;

    public event Action EnemiesDefeated;

    public List<Enemy> Enemies { get; private set; }

    private void OnEnable()
    {
        Enemies = GetEnemies();

        foreach (var enemy in Enemies)
        {
            enemy.Died += OnEnemyDied;
        }
    }

    private List<Enemy> GetEnemies()
    {
        List<Enemy> enemies = FindObjectsOfType<Enemy>().Select(x => x.GetComponent<Enemy>()).ToList();
        enemies.RemoveAll(x => x == null);

        return enemies;
    }

    private void OnDisable()
    {
        foreach (var enemy in Enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        Enemies.Remove(enemy);

        if (Enemies.Count == _enemiesLeftToWin)
        {
            EnemiesDefeated?.Invoke();
        }
    }
}
