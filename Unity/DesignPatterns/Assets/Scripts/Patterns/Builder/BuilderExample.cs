using UnityEngine;
using System.Collections;
using System;

namespace DesignPatterns.Builder {

    public class BuilderExample : MonoBehaviour {

        private Builder builder;

        private void Awake() {
            SetBuilder<CubeBuilder>();
        }

        private void OnGUI() {
            GUILayout.BeginArea(new Rect(10, 10, 300, 1000));
            GUILayout.BeginHorizontal();

            DrawBuilderButton<CubeBuilder>();
            DrawBuilderButton<UIBuilder>();
            DrawBuilderButton<SoundBuilder>();

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Go Small")) {
                builder.GoSmall();
            }

            if (GUILayout.Button("Go Big")) {
                builder.GoBig();
            }

            if (GUILayout.Button("Clear")) {
                builder.Clear();
            }

            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void SetBuilder<T>() where T : Builder, new() {
            if (builder != null) {
                builder.Clear();
            }
            builder = new T();
        }

        private void DrawBuilderButton<T>() where T : Builder, new() {
            Type currentBuilderType = builder.GetType();
            Type thisBuilderType = typeof(T);

            bool isCurrentType = currentBuilderType == thisBuilderType;
            GUI.color = isCurrentType ? Color.green : Color.white;

            if (GUILayout.Button(thisBuilderType.Name)) {
                SetBuilder<T>();
            }

            GUI.color = Color.white;
        }

    }

}