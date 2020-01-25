using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private string _enemyTagName = "Enemy";

    public event Action EnemiesDefeated;

    public List<Enemy> Enemies { get; private set; }

    private void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag(_enemyTagName).Select(x => x.GetComponent<Enemy>()).ToList();

        foreach (var enemy in Enemies)
        {
            enemy.Died += OnEnemyDied;
        }
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

        if (!Enemies.Any())
        {
            EnemiesDefeated?.Invoke();
        }
    }
}
