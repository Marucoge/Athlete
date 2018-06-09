using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEditor;
using UnityEngine;
using System;


namespace Athlete{
    public interface IAthleteUpdater{
        void Update(AthleteInformation info);
    }
}