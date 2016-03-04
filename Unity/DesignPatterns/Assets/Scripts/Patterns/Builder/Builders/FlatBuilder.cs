using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace DesignPatterns.Builder {

    public class FlatBuilder : Builder {

        private List<GameObject> uiElements = new List<GameObject>();

        private Canvas canvas;

        public override void GoBig() {
            AddUIElement(true);
        }

        public override void GoSmall() {
            AddUIElement(false);
        }

        public override void Clear() {
            uiElements.ForEach(x => GameObject.Destroy(x));
            uiElements.Clear();
        }

        private void AddUIElement(bool isBig){
            Canvas canvas = GetOrCreateCanvas();

            GameObject element = new GameObject("UIElement");
            element.transform.SetParent(canvas.transform);

            Image image = element.AddComponent<Image>();
            image.color = new Color(255, 255, 255, .8f);

            RectTransform rectTransform = element.GetComponent<RectTransform>();
            rectTransform.position = new Vector3(Random.Range(0, canvas.pixelRect.width),
                                                 Random.Range(0, canvas.pixelRect.height),
                                                 0);
            float size = isBig ? 100.0f : 50.0f;
            rectTransform.sizeDelta = new Vector2(size, size);

            rectTransform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

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