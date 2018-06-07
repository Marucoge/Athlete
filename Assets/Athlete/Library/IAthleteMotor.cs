using System.Collections.Generic;
using UnityEngine;
using System;


namespace Athlete{
    public interface IAthleteMotor{
        Vector3 MovementPerFrame { get; }
    }
}