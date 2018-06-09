using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete {
    /// <summary>
    /// 足場との間に起こる摩擦を実装する。足場が動けば自分も動く。
    /// 摩擦だけで慣性を実装していないので、足場から離れるとはたらいていた力は失われる。
    /// </summary>
    public class AdoptiveFriction : IAthleteUpdater{
        private Transform defaultParent = null;


        public void Update(AthleteInformation information) {
            // parent = DetectedGround.transform の1行で済みそうなものだが、null.transform になった時にまずい。
            if (information.IsGrounding == false) {
                information.AthleteObject.transform.parent = defaultParent;
                return;
            }

            information.AthleteObject.transform.parent = information.DetectedGround.transform;
        }
    }
}