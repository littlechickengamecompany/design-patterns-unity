﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Builder {

    public class PopBuilder : Builder {

        private List<GameObject> cubes = new List<GameObject>();

        public override void GoBig(Vector3 position) {
            base.GoBig(position);
            InstantiateCube(2.0f, position);
        }

        public override void GoSmall(Vector3 position) {
            base.GoSmall(position);
            InstantiateCube(1.0f, position);
        }

        public override void Clear() {
            base.Clear();

            cubes.ForEach(x => GameObject.Destroy(x));
            cubes.Clear();
        }

        private void InstantiateCube(float size, Vector3 position) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            worldPosition.z = 0.0f;

            cube.transform.position = worldPosition;
            cube.transform.localScale = Vector3.one * size;
            cube.transform.rotation = Quaternion.Euler(position.x, position.y, 0.0f);

            cubes.Add(cube);
        }

    }

}