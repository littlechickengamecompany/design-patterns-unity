using UnityEngine;
using System.Collections;

namespace DesignPatterns.Builder {

    public abstract class Builder {

        public Data Data { get; private set; }

        public void Load(Data data) {
            Clear();

            foreach (Element element in data.Elements) {
                if (element.IsBig) {
                    GoBig(element.Position);
                } else {
                    GoSmall(element.Position);
                }
            }
        }

        public virtual void GoBig(Vector3 position) {
            AddDataElement(position, true);
        }

        public virtual void GoSmall(Vector3 position) {
            AddDataElement(position, false);
        }

        public virtual void Clear() {
            Data = new Data();
        }

        private void AddDataElement(Vector3 position, bool isBig) {
            if (Data == null) { return; }
            Element element = new Element();
            element.Position = position;
            element.IsBig = isBig;
            Data.Elements.Add(element);
        }

    }

}