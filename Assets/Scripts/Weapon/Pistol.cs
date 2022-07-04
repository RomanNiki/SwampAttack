using UnityEngine;

namespace Weapon
{
    public class Pistol : Weapon
    {

        public override void Shoot(Transform shootPoint)
        {
            Instantiate(_bullet, shootPoint.position, Quaternion.identity);
        }
    }
}
