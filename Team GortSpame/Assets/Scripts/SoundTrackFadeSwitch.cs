using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackFadeSwitch : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioClip _audioClip;
    [SerializeField] private KeyCode _triggerCode;
    private bool _fadeIn = false;
    private int _fadeCount = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioClip = _audioSource.clip;
        _audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_triggerCode))
        {
            _fadeIn = !_fadeIn;
        }

        float vol = _audioSource.volume;
        if (_fadeIn && vol < 1)
        {
            vol += 0.0001f * _fadeCount++;
            vol = Mathf.Min(vol, 1);
        }
        if (!_fadeIn && vol > 0)
        {
            vol -= 0.0001f * _fadeCount--;
            vol = Mathf.Max(0, vol);
        }
        _audioSource.volume = vol;
    }
}
