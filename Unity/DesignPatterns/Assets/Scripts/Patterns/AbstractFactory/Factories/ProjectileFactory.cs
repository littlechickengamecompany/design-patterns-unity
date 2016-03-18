using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public abstract class ProjectileFactory {

        public abstract Projectile InstantiateProjectile();
        public abstract ShootEffect InstantiateShootEffect();

    }

}