using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSTSPatrouille : FSMState<TSTStateInfo>
{
    public Transform[] patrouille;
    
    
    public override void doState(ref TSTStateInfo infos)
    {
        Debug.Log("Je fais ma petite patrouille...");
        
    }
}