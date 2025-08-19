using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class Card : MonoBehaviour
{
    [SerializeField] Sprite _sprite;
    GameObject _dontToutch;

    Image _image;
    PairManager _pairManager;

    Whites _whites;
    public Whites Whites { get { return _whites; } set { _whites = value; } }

    Color32 _whiteType = new Color(255, 255, 255);
    public Color32 WhiteType { get { return _whiteType; } set { _whiteType = value; } }

    bool _isOpened = false;
    public bool IsOpened { get { return _isOpened; } }
    int _num;
    public int Num { get { return _num; } set { _num = value; } }

    const int TURNFRAME = 30;
    private void Start()
    {
        if (this.tag != "Card")
        {
            this.tag = "Card";
        }
        _image = GetComponent<Image>();
        _image.sprite = _sprite;
        _pairManager = FindFirstObjectByType<PairManager>();
        _dontToutch = GameObject.Find("DontToutch");
        _dontToutch.SetActive(false);
    }

    [ContextMenu("Turn")]
    public void SelectCard()
    {
        Debug.Log(_num + ":" + _whites.ToString());
        StartCoroutine(SelectCoroutine());
    }

    IEnumerator SelectCoroutine()
    {
        _dontToutch.SetActive(true);
        float delta = 0;
        Vector3 startRot = transform.rotation.eulerAngles;
        Vector3 rot = new Vector3(0, 180, 0);
        while (true)
        {
            delta++;
            transform.rotation *= Quaternion.AngleAxis(rot.y / TURNFRAME, Vector3.up);

            if (transform.rotation.eulerAngles.y <= -90 || 90 <= transform.rotation.eulerAngles.y)
            {
                _image.sprite = null;
                _image.color = _whiteType;
            }
            else
            {
                _image.sprite = _sprite;
                _image.color = Color.white;
            }

            if (delta > TURNFRAME)
            {
                _dontToutch.SetActive(false);
                transform.rotation = Quaternion.Euler(startRot + rot);
                if (!_isOpened)
                {
                    _pairManager.SelectedCrad(this);
                    _isOpened = true;
                }
                else
                {
                    _isOpened = false;
                }
                yield break;
            }
            yield return null;
        }
    }
}
