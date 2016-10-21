﻿using EnduroTrails.Analizer.Extremum.Abstract;

namespace EnduroTrails.Analizer.Extremum
{
    public class MinimumSpeedAnalizer:IExtremumSpeedAnalizer
    {
        public double GetExtremumSpeed(double extremumSpeed, double currentSpeed) 
            => extremumSpeed > currentSpeed ? currentSpeed : extremumSpeed;        
    }
}