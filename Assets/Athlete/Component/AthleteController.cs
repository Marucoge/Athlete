using System.Collections.Generic;
using UnityEngine;
using System;

using Athlete;


namespace Labo{
    /// <summary>
    /// コンポーネント。
    /// </summary>
    public class AthleteController : MonoBehaviour{
        private List<IAthleteUpdater> updaters;
        private List<IAthleteMotor> motors;

        [SerializeField] private GameObject Face;
        private AthleteInformation information;

        
        private void Start() {
            var character = GetComponent<CharacterController>();
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


        private void Update() {
            Vector3 movementPerFrame = Vector3.zero;

            // (仮)
            Vector2 leftInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 rightInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            information.SetInputs(leftInput, rightInput);

            // 接地判定は移動前と移動後の両方で行った方がいいか? 特に重力の適用後
            foreach(var element in updaters) {
                element.Update(information);
            }

            foreach(var element in motors) {
                movementPerFrame += element.MovementPerFrame;
            }

            this.transform.Translate(movementPerFrame * Time.deltaTime);
        }
    }
}