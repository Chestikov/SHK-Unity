using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    public void Die()
    {
        Died?.Invoke(this);

        Destroy(gameObject);
    }
}