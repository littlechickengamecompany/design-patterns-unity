using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace DesignPatterns.Builder {

    public class FlatBuilder : Builder {

        private List<GameObject> uiElements = new List<GameObject>();

        private Canvas canvas;

        public override void GoBig(Vector3 position) {
            base.GoBig(position);
            AddUIElement(position, true);
        }

        public override void GoSmall(Vector3 position) {
            base.GoSmall(position);
            AddUIElement(position, false);
        }

        public override void Clear() {
            base.Clear();

            uiElements.ForEach(x => GameObject.Destroy(x));
            uiElements.Clear();
        }

        private void AddUIElement(Vector3 position, bool isBig) {
            Canvas canvas = GetOrCreateCanvas();

            GameObject element = new GameObject("UIElement");
            element.transform.SetParent(canvas.transform);

            Image image = element.AddComponent<Image>();
            image.color = new Color(255, 255, 255, .8f);

            float size = isBig ? 100.0f : 50.0f;
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