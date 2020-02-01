using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private SoundTrackFadeSwitch[] audioTracks;
    
    // Start is called before the first frame update
    void Start()
    {
        ActivateTrack(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTrack(int trackNr)
    {
        if (trackNr > 0 && trackNr < audioTracks.Length + 1)
            audioTracks[trackNr - 1].Activate();
    }
}
