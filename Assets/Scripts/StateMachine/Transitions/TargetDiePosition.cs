using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDiePosition : Transition
{
    void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
