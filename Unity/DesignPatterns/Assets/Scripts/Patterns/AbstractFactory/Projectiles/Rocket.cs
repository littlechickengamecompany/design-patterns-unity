using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public class Rocket : Projectile {

        protected override float GetSpeed() {
            return 5.0f;
        }

        protected override string GetPrefabPath() {
            return "Visuals/Projectiles/Rocket";
        }

    }

}