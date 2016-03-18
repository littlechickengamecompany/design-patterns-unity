using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace DesignPatterns.Builder {

    public class FlatBuilder : Builder {

        private List<GameObject> uiElements = new List<GameObject>();
        private Canvas canvas;

        public override void PlaceSmallShape(Vector3 position) {
            AddUIElement(position, 100.0f, Color.red);
        }

        public override void PlaceBigShape(Vector3 position) {
            AddUIElement(position, 50.0f, Color.blue);
        }

        public override void ClearShapes() {
            uiElements.ForEach(x => GameObject.Destroy(x));
            uiElements.Clear();
        }

        private void AddUIElement(Vector3 position, float size, Color color) {
            Canvas canvas = GetOrCreateCanvas();

            GameObject element = new GameObject("UIElement");
            element.transform.SetParent(canvas.transform);

            Image image = element.AddComponent<Image>();
            image.color = color;

            RectTransform rectTransform = element.GetComponent<RectTransform>();
            rectTransform.position = position;
            rectTransform.sizeDelta = new Vector2(size, size);

            rectTransform.rotation = Quaternion.Euler(0.0f, 0.0f, position.x + position.y);

            uiElements.Add(element);
        }

        private Canvas GetOrCreateCanvas() {
            canvas = GameObject.FindObjectOfType<Canvas>();
            if (canvas == null) {
                GameObject canvasObject = new GameObject("Canvas");
                canvas = canvasObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }
            return canvas;
        }

    }

}