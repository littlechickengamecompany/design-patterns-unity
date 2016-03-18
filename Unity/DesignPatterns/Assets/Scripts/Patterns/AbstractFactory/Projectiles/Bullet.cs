using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public class Bullet : Projectile {

        protected override float GetSpeed() {
            return 10.0f;
        }

        protected override string GetPrefabPath() {
            return "Visuals/Projectiles/Bullet";
        }

    }

}