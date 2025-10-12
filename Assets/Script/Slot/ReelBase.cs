using UnityEngine;
using UnityEngine.UI;

public abstract class ReelBase : MonoBehaviour
{
    [SerializeField] protected Image _image1, _image2, _image3, _image4;
    [SerializeField] protected SlotManager _slot;

    public abstract void MoveReel(bool stop);
    public abstract void StopReel(bool stop);
}
