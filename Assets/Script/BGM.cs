using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    static BGM _instance;
    static AudioMixer _audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_instance)
        {
            _instance = this;
            _audioMixer = _mixer;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// BGM�̑傫����ύX����֐�
    /// </summary>
    /// <param name="slider"> ���ʂ�ύX����Ƃ��Ɏg�p���Ă���X���C�_�[</param>
    public static void MixerSetting(float value)
    {
        _audioMixer.SetFloat("BGM", value);
    }
}
