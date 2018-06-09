using UnityEngine;
// using System;


namespace Athlete{
    public class WalkMotor : IAthleteMotor, IAthleteUpdater{
        private float walkSpeed = 6f;
        public Vector3 MovementPerFrame { get; private set; }


        public void Update(AthleteInformation information) {
            Vector3 rightwardMovement = information.WalkInput.x * information.AthleteObject.transform.right;
            Vector3 forwardMovement = information.WalkInput.y * information.AthleteObject.transform.forward;

            Vector3 movementPerFrame = (rightwardMovement + forwardMovement) * walkSpeed;

            MovementPerFrame = movementPerFrame;
        }
    }
}