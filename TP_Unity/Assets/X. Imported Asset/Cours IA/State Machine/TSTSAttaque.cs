using UnityEngine;

public class TSTSAttaque : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        Debug.Log("Je fais une attaque");
    }
}