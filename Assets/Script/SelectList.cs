using UnityEngine;

public class SelectList : MonoBehaviour
{
    [SerializeField] GameObject _obj;
    bool _isActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isActive = true;
        Active();

    }

    public void Active()
    {
        _isActive = !_isActive;
        _obj.SetActive(_isActive);
    }

    public void SEPlay()
    {
        SEManager.SEPlay("NormalButton");
    }
}
