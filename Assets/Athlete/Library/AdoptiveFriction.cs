using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete {
    /// <summary>
    /// 足場との間に起こる摩擦を実装する。足場が動けば自分も動く。
    /// 摩擦だけで慣性を実装していないので、足場から離れるとはたらいていた力は失われる。
    /// </summary>
    public class AdoptiveFriction {
        private Transform defaultParent = null;


        public void ManualUpdate(AthleteInformation information, GroundingDetector detector) {
            // parent = DetectedGround.transform の1行で済みそうなものだが、null.transform になった時にまずい。
            if (detector.IsGrounding == false) {
                information.AthleteObject.transform.parent = defaultParent;
                return;
            }

            information.AthleteObject.transform.parent = detector.DetectedGround.transform;
        }
    }
}