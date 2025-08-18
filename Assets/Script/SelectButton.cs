using UnityEngine;

public class SelectButton : MonoBehaviour
{
    float _defaultPosY;

    private void Start()
    {
        _defaultPosY = transform.position.y;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, _defaultPosY, transform.position.z);
        Debug.Log(transform.position);
    }
}
