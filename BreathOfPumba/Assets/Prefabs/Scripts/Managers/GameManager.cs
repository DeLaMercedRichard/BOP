using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioControl musicPlayer;
    SceneManagement sceneManagement;
   
    public bool inBattle = false, isPause = false, isInMenu = false, isPlayerDead = false;
    public bool battlingBoss;
    private void Awake()
    {
        SetDefaultsIfNoneSet();

       

        //Play the Menu Music At Start (assuming menu is the first scene that loads up) else play default Music

        musicPlayer.PlayTrack(AudioControl.TrackType.Default);

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /************************************************************Music Controls*/
    ///Toggles Battle Music when called to be used on Player class
    public void ToggleBattleMusic()
    {
        inBattle = !inBattle;
        if (!battlingBoss)
        {
            if (inBattle)
            {
                //Play Battle Music
                musicPlayer.PlayTrack(AudioControl.TrackType.Combat);
            }
            else
            {
                //Play Non Battle Music
                musicPlayer.PlayTrack(AudioControl.TrackType.Default);
            }
        }
        else
        {
            musicPlayer.PlayTrack(AudioControl.TrackType.Boss);
        }
        
    }
    public void ToggleMenuMusic()
    {
        isInMenu = !isInMenu;
        if (isInMenu)
        {
            musicPlayer.PlayTrack(AudioControl.TrackType.Menu);
        }
        else
        {
            //Play default music
            musicPlayer.PlayTrack(AudioControl.TrackType.Default);
        }
    }

    public void TogglePauseMusic()
    {
        isPause = !isPause;
        if (isPause)
        {
            musicPlayer.PlayTrack(AudioControl.TrackType.Pause);
        }
        else
        {
            //Play default music
            musicPlayer.PlayTrack(AudioControl.TrackType.Default);
        }

    }
    public void ToggleDeathMusic()
    {
        isPlayerDead = !isPlayerDead;
        if (isPlayerDead)
        {
            musicPlayer.PlayTrack(AudioControl.TrackType.Death);
        }
        else
        {
            //Play default music
            musicPlayer.PlayTrack(AudioControl.TrackType.Default);
        }
    }
    //Loads "Assets/Resources/Music/Tracks/..."
    public void AddTrackToPlaylist(string name, AudioControl.TrackType type)
    {
        musicPlayer.AddTrackToPlaylist(name, type);
    }

    public void ClearPlaylist()
    {
        musicPlayer.ClearPlayList();
    }
    //***************************************************************************Just Chunk Code Put into Functions For Easier Reading

    //Just Covering basis for incase variables not set in inspector
    void SetDefaultsIfNoneSet()
    {
        if (musicPlayer == null)
            musicPlayer = GetComponent<AudioControl>();
        if (sceneManagement == null)
            sceneManagement = GetComponent<SceneManagement>();

    }
    
    
    // Update is called once per frame
    void Update()
    {

    }

}//end class
