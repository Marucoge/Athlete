using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEditor;
using UnityEngine;
using System;


namespace Athlete{
    public class ControllerCore{
        private List<IAthleteUpdater> updaters;
        private List<IAthleteMotor> motors;

        private GameObject Face;
        private AthleteInformation information;


        public ControllerCore(CharacterController charaCon, GameObject face) {
            this.Face = face;
            var character = charaCon;
            information = new AthleteInformation(character, Face);

            GravityMotor gravityMotor = new GravityMotor();
            WalkMotor walkMotor = new WalkMotor();

            motors = new List<IAthleteMotor>();
            motors.Add(gravityMotor);
            motors.Add(walkMotor);

            updaters = new List<IAthleteUpdater>();
            updaters.Add(new GroundingDetector(information));
            updaters.Add(new AdoptiveFriction());
            updaters.Add(new FaceAngleDirector());
            updaters.Add(gravityMotor);
            updaters.Add(walkMotor);
        }


        public void UpdateCore() {
            Vector3 movementPerFrame = Vector3.zero;

            // (仮)
            Vector2 walkInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 cameraAngleInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            information.SetInputs(walkInput, cameraAngleInput);

            // 接地判定は移動前と移動後の両方で行った方がいいか? 特に重力の適用後
            foreach (var element in updaters) {
                element.Update(information);
            }

            foreach (var element in motors) {
                movementPerFrame += element.MovementPerFrame;
            }

            var TotalMovementPerSecond = movementPerFrame * Time.deltaTime;
            this.information.Character.Move(TotalMovementPerSecond);
        }
    }
}