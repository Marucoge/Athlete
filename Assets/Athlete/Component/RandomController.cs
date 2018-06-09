using System.Collections.Generic;
using UnityEngine;
//using System;

using Athlete;


namespace Labo{
    public class RandomController : MonoBehaviour{
        [SerializeField] private GameObject Face;
        private CharacterController character;
        private ControllerCore core;

        private float lastUpdateTime = 0f;
        private Vector2 randomWalkInput = Vector2.zero;
        private Vector2 randomCameraInput = Vector2.zero;


        private void Start() {
            character = GetComponent<CharacterController>();
            core = new ControllerCore(character, Face);
        }


        private void Update() {
            // 1秒ごとに値をランダムに更新する。
            if (Time.time > lastUpdateTime + 1) {
                float f = Random.Range(-0.1f, 0.1f);
                float g = Random.Range(-0.1f, 0.1f);
                float h = Random.Range(-6f, 6f);
                float i = Random.Range(-6f, 6f);
                randomWalkInput = new Vector2(f, g);
                randomCameraInput = new Vector2(h, i);
                lastUpdateTime = Time.time;
            }

            Vector2 walkInput = randomWalkInput;
            Vector2 cameraAngleInput = randomCameraInput;

            core.UpdateCore(walkInput, cameraAngleInput);
            randomCameraInput = Vector2.zero;        // 入力されっぱなしだとくるくる回るだけになってしまうので。
        }
    }
}