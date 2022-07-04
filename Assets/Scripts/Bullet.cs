using Interfaces;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * (_speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<IDamageable>(out var enemy))
        {
            enemy.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}