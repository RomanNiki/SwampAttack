using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private TMP_Text _coast;
        [SerializeField] private Image _weaponImage;
        [SerializeField] private Button _sellButton;

        private Weapon.Weapon _weapon;

        public event UnityAction<Weapon.Weapon, WeaponView> SellButtonClick;
        
        private void OnEnable()
        {
            _sellButton.onClick.AddListener(OnButtonClick);
            _sellButton.onClick.AddListener(TryLockItem);
        }

        private void OnDisable()
        {
            _sellButton.onClick.RemoveListener(OnButtonClick);
            _sellButton.onClick.RemoveListener(TryLockItem);
        }

        private void TryLockItem()
        {
            if (_weapon.IsBought)
            {
                _sellButton.interactable = false;
            }
        }

        public void Render(Weapon.Weapon weapon)
        {
            _weapon = weapon;
            _label.text = _weapon.Label;
            _coast.text = _weapon.Price.ToString();
            _weaponImage.sprite = _weapon.Icon;
        }

        private void OnButtonClick()
        {
            SellButtonClick?.Invoke(_weapon, this);
        }
    }
}
