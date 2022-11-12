public class TSTSBase : FSMState<TSTStateInfo>
{
    public float SeuilBonneSante = 30;
    public override void doState(ref TSTStateInfo infos)
    {
        if (infos.PcentLife > SeuilBonneSante)
            addAndActivateSubState<TSTSBonneSante>();
        else
            addAndActivateSubState<TSTSFuite>();

        KeepMeAlive = true;
    }
}