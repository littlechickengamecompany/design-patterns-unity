using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public class FlashEffect : ShootEffect {

        protected override string GetPrefabPath() {
            return "Visuals/Effects/FlashEffect";
        }

    }

}