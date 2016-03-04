using UnityEngine;
using System.Collections;

namespace DesignPatterns.Builder {

    public abstract class Builder {

        public abstract void GoBig();
        public abstract void GoSmall();
        public abstract void Clear();

    }

}