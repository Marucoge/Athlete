using System.Collections.Generic;
using UnityEngine;
using System;

using Athlete;


namespace Labo{
    /// <summary>
    /// コンポーネント。
    /// </summary>
    public class AthleteController : MonoBehaviour{
        [SerializeField] private GameObject Face;
        private AthleteInformation information;
        private GroundingDetector detector;
        private AdoptiveFriction frictioner;
        private FaceAngleDirector director;

        private List<IAthleteMotor> motors;
        private GravityMotor gravityMotor;
        private WalkMotor walkMotor;
        

        private void Start() {
            var character = GetComponent<CharacterController>();
            information = new AthleteInformation(character, Face);
            detector = new GroundingDetector(information);
            frictioner = new AdoptiveFriction();
            director = new FaceAngleDirector();

            motors = new List<IAthleteMotor>();
            gravityMotor = new GravityMotor();
            walkMotor = new WalkMotor();
            motors.Add(gravityMotor);
            motors.Add(walkMotor);
        }


        private void Update() {
            Vector3 movementPerFrame = Vector3.zero;

            // (仮)
            Vector2 leftInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 rightInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            // 接地判定は移動前と移動後の両方で行った方がいいか? 特に重力の適用後
            // 引数を統一させれば、インターフェイスを介してforeachでメソッドを呼べるが...
            detector.UpdateDetection(information);
            frictioner.UpdateFriction(information, detector);
            director.UpdateDirection(information, rightInput);
            gravityMotor.UpdateGravity(detector);
            walkMotor.UpdateWalk(information, leftInput);

            foreach(var element in motors) {
                movementPerFrame += element.MovementPerFrame;
            }

            // Debug.Log(detector.DetectedGround);
            // Debug.Log(this.transform.parent);

            this.transform.Translate(movementPerFrame * Time.deltaTime);
        }
    }
}