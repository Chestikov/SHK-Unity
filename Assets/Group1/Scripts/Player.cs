using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private EnemyCounter enemyCounter;
    [SerializeField] private float _attackDistance = 0.2f;
    private float _currentSpeed;
    private List<Bonus> _speedBonuses;

    public float AttackDistance => _attackDistance;

    private void OnEnable()
    {
        enemyCounter.EnemiesDefeated += OnEnemiesDefeated;
    }

    private void Start()
    {
        _currentSpeed = _baseSpeed;
        _speedBonuses = new List<Bonus>();
    }

    private void Update()
    {
        RefreshSpeedBonuses(_speedBonuses);

        Vector3 inputDirection = GetInput();
        Move(inputDirection, _currentSpeed);
    }

    private void OnDisable()
    {
        enemyCounter.EnemiesDefeated -= OnEnemiesDefeated;
    }

    public void Attack(Enemy enemy)
    {
        enemy.Die();
    }

    public void AddSpeedBonus(float multiplier, float time)
    {
        _speedBonuses.Add(new Bonus(multiplier, time));
        _currentSpeed *= multiplier;
    }

    private void RemoveSpeedBonus(Bonus bonus)
    {
        _speedBonuses.Remove(bonus);
        _currentSpeed /= bonus.Multiplier;
    }

    private void RefreshSpeedBonuses(List<Bonus> speedBonuses)
    {
        for (int index = 0; index < speedBonuses.Count; index++)
        {
            if (speedBonuses[index].TimeLeft < 0)
            {
                RemoveSpeedBonus(speedBonuses[index]);
            }
            else
            {
                speedBonuses[index].TimeLeft -= Time.deltaTime;
            }
        }
    }

    private Vector3 GetInput()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        return inputDirection;
    }

    private void Move(Vector3 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnEnemiesDefeated()
    {
        enabled = false;
    }
}