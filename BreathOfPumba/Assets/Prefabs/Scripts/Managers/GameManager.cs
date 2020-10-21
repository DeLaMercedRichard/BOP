using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioControl musicPlayer;
  
    // Start is called before the first frame update
    void Start()
    {
        //Play the Menu Music At Start (assuming menu is the first scene that loads up)
        musicPlayer.PlayTrack(AudioControl.TrackType.Menu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeTrack(AudioControl.TrackType trackType)
    {
        musicPlayer.PlayTrack(trackType);
    }
}
