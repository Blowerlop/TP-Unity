using UnityEngine;

public class TSTSPoursuite : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        Debug.Log("Je suis à sa poursuite !");
    }
}