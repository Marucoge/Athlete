using UnityEngine;
// using System;


namespace Athlete{
    public class WalkMotor : IAthleteMotor{
        private float walkSpeed = 3f;
        public Vector3 MovementPerFrame { get; private set; }


        public void UpdateWalk(AthleteInformation information, Vector2 input) {
            Vector3 rightwardMovement = input.x * Vector3.right;
            Vector3 forwardMovement = input.y * Vector3.forward;
            Vector3 movementPerFrame = (rightwardMovement + forwardMovement) * walkSpeed;

            MovementPerFrame = movementPerFrame;
        }
    }
}