using System.Collections.Generic;
using UnityEngine;
using System;

using Athlete;

namespace Labo{
    public class NPCController : MonoBehaviour{
        [SerializeField] private GameObject Face;
        private CharacterController character;
        private ControllerCore core;

        private void Start() {
            character = GetComponent<CharacterController>();
            core = new ControllerCore(character, Face);
        }

        private void Update() {
            core.UpdateCore();
        }
    }
}