using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete{
    public class GroundingDetector {
        public RaycastHit HitInfo { get; private set; }
        public GameObject DetectedGround { get; private set; }
        public bool IsGrounding { get; private set; }
        private int layermask = ~0;

        private readonly Vector3 offsetToCastOrigin = Vector3.down * 0.2f;
        private readonly Vector3 castDirection = Vector3.down;
        private readonly float castLength = 0.4f;
        private readonly float castRadius = 0.5f;


       public GroundingDetector(AthleteInformation info) {
            layermask = LayerMaskGenerator.Generate(IgnoreLayer.Specified, info.AthleteObject.layer);
            Debug.Log("Detector will ignore: [" + LayerMask.LayerToName(info.AthleteObject.layer) + "] layer.");
        }


        public void UpdateDetection(AthleteInformation information) {
            HitInfo = Cast(information.AthleteObject.transform);
            IsGrounding = (HitInfo.collider != null);
            DetectedGround =
                IsGrounding ? HitInfo.collider.gameObject : null;
            //LogView.Log("Grounding: " + IsGrounding + " on " + DetectedGround);
        }


        private RaycastHit Cast(Transform caster) {
            Vector3 castOrigin = caster.transform.position + offsetToCastOrigin;

            var hitInfo = new RaycastHit();
            Physics.SphereCast(castOrigin, castRadius, castDirection, out hitInfo, castLength, layermask, QueryTriggerInteraction.Ignore);

            return hitInfo;
        }
    }
}