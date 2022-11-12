using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TSTSFuite : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        Debug.Log("Je m'enfuie !");
    }
}