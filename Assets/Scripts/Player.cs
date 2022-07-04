using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon.Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon.Weapon _currentWeapon;
    private int _currentWeaponNumber;
    private int _currentHealth;
    private Animator _animator;
    
    public int Money { get; private set; }
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _currentHealth = _health;
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.StopPlayback();
            _animator.Play("Shoot");
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        _animator.Play("HitGun");
        HealthChanged?.Invoke(_currentHealth, _health);
        
        if (_currentHealth <= 0)
        {
            _animator.Play("Death");
            Destroy(gameObject, 1f);
        }
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }

    public void BuyWeapon(Weapon.Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanged?.Invoke(Money);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count -1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }
        
        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }
        
        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon.Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}