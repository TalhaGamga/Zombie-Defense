using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IlockTarget
{
    /*
        Define a func that takes 2 parameters which is each a function
        and call them properly in base and other classes.
    */
    public Collider Detect(TargetDetecmentConst targetDetecment);
}