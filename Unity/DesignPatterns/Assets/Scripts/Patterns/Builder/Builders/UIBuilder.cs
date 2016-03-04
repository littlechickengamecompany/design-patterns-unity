using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Builder {

    public class UIBuilder : Builder {

        private const int SPACE_PER_ROW = 3;

        private class UIElement {
            public bool IsBig { get; private set; }

            public UIElement(bool isBig) {
                IsBig = isBig;
            }

            public void Draw() {
                string text = IsBig ? "Big" : "Small";
                GUILayout.Box(text);
            }
        }

        private List<UIElement> uiElements = new List<UIElement>();

        public override void GoBig() {
            AddUIElement(true);
        }

        public override void GoSmall() {
            AddUIElement(false);
        }

        public override void Clear() {
            uiElements.Clear();
        }

        private void OnGUI() {
            int screenWidth = Camera.main.pixelWidth;
            GUILayout.BeginArea(new Rect(screenWidth * .2f, 100, screenWidth * .6f, 1000));

            int takenSpacesInRow = 0;

            GUILayout.BeginHorizontal();
            foreach (UIElement element in uiElements) {
                if (takenSpacesInRow >= SPACE_PER_ROW) {
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }

                element.Draw();

                if (element.IsBig) {
                    takenSpacesInRow += 2;
                } else {
                    takenSpacesInRow += 1;
                }
            }
        }

        private void AddUIElement(bool isBig){
            UIElement element = new UIElement(false);
            uiElements.Add(element);
        }

    }

}