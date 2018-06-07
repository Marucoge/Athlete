using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete{
    public class AthleteInformation{
        public CharacterController Character { get; private set; }
        public GameObject AthleteObject { get; private set; }
        public GameObject FaceObject { get; private set; }
        // 

        public AthleteInformation(CharacterController character, GameObject face) {
            this.Character = character;
            this.AthleteObject = character.gameObject;
            this.FaceObject = face;
        }
    }
}