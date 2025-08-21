using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class Card : MonoBehaviour
{
    [SerializeField] Sprite _sprite;
    [SerializeField] Sprite _sprite2;
    [SerializeField] GameObject _dontToutch;
    [SerializeField] GameObject _particle;

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
        _dontToutch.SetActive(false);
    }

    [ContextMenu("Turn")]
    public void SelectCard()
    {
        Debug.Log(_num + ":" + _whites.ToString());
        SEManager.SEPlay("CardSelect");
        StartCoroutine(SelectCoroutine());
    }

    public void InstantiateParticle()
    {//ÉèÅ[ÉãÉhç¿ïWÇ…ïœä∑
        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);
        pos.z = 0;
        Instantiate(_particle, pos, Quaternion.identity);
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
            if (90 <= transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y <= 270)
            {
                _image.sprite = _sprite2;
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
