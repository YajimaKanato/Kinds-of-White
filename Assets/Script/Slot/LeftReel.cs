using UnityEngine;
using UnityEngine.UI;

public class LeftReel : ReelBase
{
    Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        LeftReelUpdate();
    }

    public void LeftReelUpdate()
    {
        _slot.MoveLeftReel(_image1, 3);
        _slot.MoveLeftReel(_image2, 2);
        _slot.MoveLeftReel(_image3, 1);
        _slot.MoveLeftReel(_image4, 0);
        _slot.LeftIndexNext();
    }

    public override void MoveReel(bool stop)
    {
        _anim.speed = 1;
        _anim.SetBool("Stop", stop);
    }

    public override void StopReel(bool stop)
    {
        _anim.speed = 0.8f;
        _anim.SetBool("Stop", stop);
    }
}
