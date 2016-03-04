using UnityEngine;
using System.Collections;
using System;

namespace DesignPatterns.Builder {

    public class BuilderExample : MonoBehaviour {

        private Builder builder;
        private Rect uiRect = new Rect(10, 10, 300, 100);

        private void Awake() {
            builder = new PopBuilder();
            builder.Load(new Data());
        }

        private void Update() {
            HandlePlacement();
        }

        private void OnGUI() {
            GUILayout.BeginArea(uiRect);
            GUILayout.BeginHorizontal();

            DrawBuilderButton<PopBuilder>();
            DrawBuilderButton<FlatBuilder>();

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Clear")) {
                builder.Clear();
            }

            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void HandlePlacement() {
            Vector2 flippedMousePosition = Input.mousePosition;
            flippedMousePosition.y = Camera.main.pixelHeight - Input.mousePosition.y;
            if (uiRect.Contains(flippedMousePosition)) { return; }

            if (Input.GetMouseButtonDown(0)) {
                builder.GoSmall(Input.mousePosition);
            }
            if (Input.GetMouseButtonDown(1)) {
                builder.GoBig(Input.mousePosition);
            }
        }

        private bool DrawBuilderButton<T>() where T : Builder, new() {
            Type currentBuilderType = builder.GetType();
            Type thisBuilderType = typeof(T);

            bool isCurrentType = currentBuilderType == thisBuilderType;
            GUI.color = isCurrentType ? Color.green : Color.white;

            bool isPressed = GUILayout.Button(thisBuilderType.Name);

            if (isPressed) {
                Builder previousBuilder = builder;
                
                builder = new T();
                builder.Load(previousBuilder.Data);

                previousBuilder.Clear();
            }

            GUI.color = Color.white;

            return isPressed;
        }

    }

}