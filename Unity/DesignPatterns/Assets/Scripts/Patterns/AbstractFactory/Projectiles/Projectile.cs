using UnityEngine;
using System.Collections;

namespace DesignPatterns.AbstractFactory {

    public abstract class Projectile : MonoBehaviour {

        private const float MAX_AGE = 3.0f;

        protected abstract float GetSpeed();
        protected abstract string GetPrefabPath();

        private void Awake() {
            gameObject.InstantiateAsChild(GetPrefabPath());
            Destroy(gameObject, MAX_AGE);
        }

        private void Update() {
            transform.Translate(Vector3.right * GetSpeed() * Time.deltaTime);
        }

    }

}