using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete{
    public class GroundingDetector : IAthleteUpdater{
        private readonly Vector3 offsetToCastOrigin = Vector3.down * 0.2f;
        private readonly Vector3 castDirection = Vector3.down;
        private readonly float castLength = 0.4f;
        private readonly float castRadius = 0.5f;
        private int layermask = ~0;


        public GroundingDetector(AthleteInformation info) {
            layermask = LayerMaskGenerator.Generate(IgnoreLayer.Specified, info.AthleteObject.layer);
           // Debug.Log("Detector will ignore: [" + LayerMask.LayerToName(info.AthleteObject.layer) + "] layer.");
        }


        public void Update(AthleteInformation information) {
            RaycastHit hitInfo = Cast(information.AthleteObject.transform);
            bool isGrounding = (hitInfo.collider != null);
            GameObject detectedGround =
                isGrounding ? hitInfo.collider.gameObject : null;

            information.UpdateGrounding(isGrounding, detectedGround, hitInfo);
        }


        private RaycastHit Cast(Transform caster) {
            Vector3 castOrigin = caster.transform.position + offsetToCastOrigin;

            var hitInfo = new RaycastHit();
            Physics.SphereCast(castOrigin, castRadius, castDirection, out hitInfo, castLength, layermask, QueryTriggerInteraction.Ignore);

            return hitInfo;
        }
    }
}