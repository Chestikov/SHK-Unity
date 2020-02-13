using UnityEngine;

class BattleModerator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void Update()
    {
        for (int index = 0; index < _enemyCounter.Enemies.Count; index++)
        {
            if (AreObjectsClose(_player.transform, _enemyCounter.Enemies[index].transform, _player.AttackDistance))
            {
                _player.Attack(_enemyCounter.Enemies[index]);
            }
        }
    }

    private bool AreObjectsClose(Transform first, Transform second, float distance)
    {
        return Vector3.SqrMagnitude(first.position - second.position) < distance * distance;
    }
}