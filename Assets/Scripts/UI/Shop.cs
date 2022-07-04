using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Weapon.Weapon> _weapons;
        [SerializeField] private Player _player;
        [SerializeField] private WeaponView _template;
        [SerializeField] private GameObject _itemContainer;

        private void Start()
        {
            foreach (var weapon in _weapons)
            {
                AddItem(weapon);
            }
        }

        private void AddItem(Weapon.Weapon weapon)
        {
            var view = Instantiate(_template, _itemContainer.transform);
            view.SellButtonClick += OnSellButtonClick;
            view.Render(weapon);
        }

        private void OnSellButtonClick(Weapon.Weapon weapon, WeaponView view)
        {
            TrySellWeapon(weapon, view);
        }

        private void TrySellWeapon(Weapon.Weapon weapon, WeaponView view)
        {
            if (weapon.Price > _player.Money) return;
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.SellButtonClick -= OnSellButtonClick;
        }
    }
}
