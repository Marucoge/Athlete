using UnityEngine;
// using System;


namespace Athlete{
    public class WalkMotor : IAthleteMotor, IAthleteUpdater{
        private float walkSpeed = 3f;
        public Vector3 MovementPerFrame { get; private set; }


        public void Update(AthleteInformation information) {
            Vector3 rightwardMovement = information.WalkInput.x * Vector3.right;
            Vector3 forwardMovement = information.WalkInput.y * Vector3.forward;
            Vector3 movementPerFrame = (rightwardMovement + forwardMovement) * walkSpeed;

            MovementPerFrame = movementPerFrame;
        }
    }
}