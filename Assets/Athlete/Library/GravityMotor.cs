using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete{
    public class GravityMotor : IAthleteMotor, IAthleteUpdater{
        public float FloatingTime { get; private set; }
        public float GravityAccel { get; private set; }
        public float MaximumSpeed { get; private set; }
        public Vector3 MovementPerFrame { get; private set; }

        //public float ConstantGravity { get; private set; }


        // 両手両足を広げてうつ伏せでスカイダイビングした場合、終端速度は時速200km程度らしい。
        // 飛び出して数秒から10秒程度で最高速度に達する。


        public GravityMotor() {
            FloatingTime = 0.00f;
            GravityAccel = 10.00f;      // 標準重力加速度(1G)はおよそ 9.8 m/s2  (加速度の単位であることに注意。1秒につき速度が 9.8m/s速くなるような加速をあらわす。)
            MaximumSpeed = 100f;   // もっと小さくてもいいかも。
        }


        public void Update(AthleteInformation information) {
            // 接地していたらフィールドをリセットして return。
            if (information.IsGrounding) {
                MovementPerFrame = Vector3.zero;
                FloatingTime = 0.00f;
                return;
            }

            // 接地していない場合、移動量を計算する。
            FloatingTime += Time.deltaTime;
            float currentSpeed = GravityAccel * FloatingTime;                               // 加速度*経過時間=この時点での速度
            float restrictedSpeed = Mathf.Min(currentSpeed, MaximumSpeed);      // 最大速度を制限する。
            MovementPerFrame = restrictedSpeed * Vector3.down;                     // MovementPerFrame を合計するときに秒あたりの移動量に直すので、ここではフレームあたりのでよい。
        }
    }
}