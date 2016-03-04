using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Builder {

    public class PopBuilder : Builder {

        private List<GameObject> cubes = new List<GameObject>();

        public override void GoBig() {
            InstantiateCube(2.0f);
        }

        public override void GoSmall() {
            InstantiateCube(1.0f);
        }

        public override void Clear() {
            cubes.ForEach(x => GameObject.Destroy(x));
            cubes.Clear();
        }

        private void InstantiateCube(float size) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.localScale = Vector3.one * size;

            Vector3 position = Vector3.zero;
            position.x = Random.Range(-5.0f, 5.0f);
            position.y = Random.Range(-5.0f, 5.0f);
            cube.transform.position = position;

            cube.transform.rotation = Quaternion.Euler(Random.Range(0.0f, 360.0f),
                                                       Random.Range(0.0f, 360.0f),
                                                       Random.Range(0.0f, 360.0f));

            cubes.Add(cube);
        }

    }

}