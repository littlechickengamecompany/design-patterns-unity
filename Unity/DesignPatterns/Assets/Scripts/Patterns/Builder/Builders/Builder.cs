using UnityEngine;
using System.Collections;

namespace DesignPatterns.Builder {

    public abstract class Builder {

        public abstract void PlaceSmallShape(Vector3 position);
        public abstract void PlaceBigShape(Vector3 position);
        public abstract void ClearShapes();

    }

}