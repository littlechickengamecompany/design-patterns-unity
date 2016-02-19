using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public class SmokeEffect : ShootEffect {

        protected override string GetPrefabPath() {
            return "Visuals/Effects/SmokeEffect";
        }

    }

}