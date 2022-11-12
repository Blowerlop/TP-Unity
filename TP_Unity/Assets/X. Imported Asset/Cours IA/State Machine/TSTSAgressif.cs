using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TSTSAgressif : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        if (infos.CloseToTarget)
            addAndActivateSubState<TSTSAttaque>();
        else
            addAndActivateSubState<TSTSPoursuite>();
    }
}