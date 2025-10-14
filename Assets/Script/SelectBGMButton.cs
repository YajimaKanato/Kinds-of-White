using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectBGMButton : MonoBehaviour
{
    [SerializeField] List<SelectBGM> _selectBGM;
    AudioSource _audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audio = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
        foreach (var selectBGM in _selectBGM)
        {
            selectBGM.Init(_audio.clip);
        }
    }

    public void BGMChange(int index)
    {
        for (int i = 0; i < _selectBGM.Count; i++)
        {
            if (i == index)
            {
                if (_audio.clip != _selectBGM[i].Clip)
                {
                    _audio.clip = _selectBGM[i].Clip;
                    _audio.Play();
                    _selectBGM[i].Check.SetActive(true);
                }
            }
            else
            {
                _selectBGM[i].Check.SetActive(false);
            }
        }
    }

    [System.Serializable]
    class SelectBGM
    {
        [SerializeField] string _bgmName;
        [SerializeField] AudioClip _clip;
        [SerializeField] GameObject _check;
        [SerializeField] Text _text;

        public AudioClip Clip => _clip;
        public GameObject Check => _check;

        public void Init(AudioClip clip)
        {
            _text.text = _bgmName;
            _check.SetActive(clip == _clip);
        }
    }
}
