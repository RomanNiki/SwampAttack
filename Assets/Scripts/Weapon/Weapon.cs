using UnityEngine;

namespace Weapon
{
   public abstract class Weapon : MonoBehaviour
   {
      [SerializeField] private string _label;
      [SerializeField] private int _price;
      [SerializeField] private Sprite _icon;
      [SerializeField] private bool _isBought;

      [SerializeField] protected Bullet _bullet;
      public string Label => _label;
      public int Price => _price;
      public Sprite Icon => _icon;
      public bool IsBought => _isBought;
      public abstract void Shoot(Transform shootPoint);

      public void Buy()
      {
         _isBought = true;
      }
   }
}
