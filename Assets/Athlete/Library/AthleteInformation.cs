using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete{
    public class AthleteInformation{
        public CharacterController Character { get; private set; }
        public GameObject AthleteObject { get; private set; }
        public GameObject FaceObject { get; private set; }

        public bool IsGrounding { get; private set; }
        public GameObject DetectedGround { get; private set; }
        public RaycastHit HitInformation { get; private set; }

        public Vector2 CameraInput { get; private set; }
        public Vector2 WalkInput { get; private set; }


        public AthleteInformation(CharacterController character, GameObject face) {
            this.Character = character;
            this.AthleteObject = character.gameObject;
            this.FaceObject = face;
        }


        internal void UpdateGrounding(bool isGrounding, GameObject detectedGround, RaycastHit hitInfo) {
            this.IsGrounding = isGrounding;
            this.DetectedGround = detectedGround;
            this.HitInformation = hitInfo;
        }


        internal void SetInputs(Vector2 _walkStickInput, Vector2 _cameraStickInput) {
            this.WalkInput = _walkStickInput;
            this.CameraInput = _cameraStickInput;
        }
    }
}