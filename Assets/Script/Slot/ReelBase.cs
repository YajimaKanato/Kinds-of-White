using UnityEngine;

public abstract class ReelBase : MonoBehaviour
{
    public abstract void ReelUpdate();
    public abstract void MoveReel(bool stop);
    public abstract void StopReel(bool stop);
}
