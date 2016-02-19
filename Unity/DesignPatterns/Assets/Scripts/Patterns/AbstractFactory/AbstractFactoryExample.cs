using UnityEngine;
using System.Collections;
using System;

namespace DesignPatterns.AbstractFactory {

    public class AbstractFactoryExample : MonoBehaviour {

        [SerializeField] private Gun gun;

        private void Awake() {
            gun.SetProjectileFactory(new BulletFactory());
        }

        private void OnGUI() {
            GUILayout.BeginArea(new Rect(10, 10, 300, 1000));
            GUILayout.BeginHorizontal();

            DrawProjectileFactoryButton<BulletFactory>();
            DrawProjectileFactoryButton<RocketFactory>();

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Shoot")) {
                gun.Shoot();
            }

            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void DrawProjectileFactoryButton<T>() where T : ProjectileFactory, new() {
            Type currentFactoryType = gun.ProjectileFactory.GetType();
            Type thisFactoryType = typeof(T);
            
            bool isCurrentType = currentFactoryType == thisFactoryType;
            GUI.color = isCurrentType ? Color.green : Color.white;

            if (GUILayout.Button(thisFactoryType.Name)) {
                ProjectileFactory bulletFactory = new T();
                gun.SetProjectileFactory(bulletFactory);
            }

            GUI.color = Color.white;
        }

    }

}