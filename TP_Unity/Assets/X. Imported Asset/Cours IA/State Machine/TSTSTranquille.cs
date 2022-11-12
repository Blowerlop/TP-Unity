using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSTSTranquille : FSMState<TSTStateInfo>
{
    public float PeriodIdle = 5;
    private float TempoIdle = 0;
    private bool Init = true;

    public override void doState(ref TSTStateInfo infos)
    {
        TempoIdle += infos.PeriodUpdate;

        if (TempoIdle > PeriodIdle || Init)
        {
            TempoIdle = 0;
            Init = false;
            if (isActiveSubstate<TSTSIdle>())
            {
                addAndActivateSubState<TSTSPatrouille>();
            }
            else
            {
                addAndActivateSubState<TSTSIdle>();
            }
        }

        KeepMeAlive = true; //Sinon on perds la tempo, l'init etc...
    }
}