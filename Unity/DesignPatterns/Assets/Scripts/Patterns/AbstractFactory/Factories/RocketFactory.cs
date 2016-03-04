using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public class RocketFactory : ProjectileFactory {

        public override Projectile InstantiateProjectile() {
            return new GameObject("Rocket").AddComponent<Rocket>();
        }

        public override ShootEffect InstantiateShootEffect() {
            return new GameObject("SmokeEffect").AddComponent<SmokeEffect>();
        }

    }

}