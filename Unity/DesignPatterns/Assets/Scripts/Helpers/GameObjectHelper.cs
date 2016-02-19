using UnityEngine;
using System.Collections;

public static class GameObjectHelper {

    public static GameObject InstantiateAsChild(this GameObject parent, string resourcePath) {
        GameObject prefab = Resources.Load(resourcePath) as GameObject;
        GameObject gameObject = GameObject.Instantiate(prefab);
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        gameObject.transform.localScale = Vector3.one;
        return gameObject;
    }

}