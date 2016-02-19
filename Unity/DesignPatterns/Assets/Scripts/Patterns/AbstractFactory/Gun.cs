using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public class Gun : MonoBehaviour {

        public ProjectileFactory ProjectileFactory { get; private set; }

        public void SetProjectileFactory(ProjectileFactory projectileFactory) {
            ProjectileFactory = projectileFactory;
        }

        public void Shoot() {
            Projectile projectile = ProjectileFactory.InstantiateProjectile();
            projectile.transform.position = transform.position;

            ShootEffect shootEffect = ProjectileFactory.InstantiateShootEffect();
            shootEffect.transform.position = transform.position;
        }

        private void Awake() {
            SetProjectileFactory(new BulletFactory());
        }

    }

}