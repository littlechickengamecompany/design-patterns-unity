using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public class BulletFactory : ProjectileFactory {

        public override Projectile InstantiateProjectile() {
            return new GameObject("Bullet").AddComponent<Bullet>();
        }

        public override ShootEffect InstantiateShootEffect() {
            return new GameObject("FlashEffect").AddComponent<FlashEffect>();
        }

    }

}