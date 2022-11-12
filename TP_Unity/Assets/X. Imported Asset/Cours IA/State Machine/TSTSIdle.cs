using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSTSIdle : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        Debug.Log("Je fais une petite anim d'idle");
    }
}