using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public abstract class ShootEffect : MonoBehaviour {

        private const float MAX_AGE = 1.0f;

        protected abstract string GetPrefabPath();

        private void Awake() {
            gameObject.InstantiateAsChild(GetPrefabPath());
            Destroy(gameObject, MAX_AGE);
        }

    }

}