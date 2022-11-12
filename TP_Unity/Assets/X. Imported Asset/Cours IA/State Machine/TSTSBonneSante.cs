using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSTSBonneSante : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        if (infos.CanSeeTarget)
            addAndActivateSubState<TSTSAgressif>();
        else
            addAndActivateSubState<TSTSTranquille>();
    }
}