using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioControl musicPlayer;
    SceneManagement sceneManagement;
   
    public bool inBattle, isInSafeZone, isInMenu, isPlayerDead;
    public bool battlingBoss;
    private void Awake()
    {
        SetDefaultsIfNoneSet();

        if (musicPlayer.isEmpty())
        {
            PopulateDefaultMusic();
        }

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

    public void ToggleSafeMusic()
    {
        isInSafeZone = !isInSafeZone;
        if (isInSafeZone)
        {
            musicPlayer.PlayTrack(AudioControl.TrackType.Safe);
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
        musicPlayer.AddTrackToPlaylist(Resources.Load<AudioClip>("Music/Tracks/" + name), type);
    }

    //***************************************************************************Just Chunk Code Put into Functions For Easier Reading

    //Just Covering basis for incase variables not set in inspector
    void SetDefaultsIfNoneSet()
    {
        inBattle = false;
        battlingBoss = false;
        isPlayerDead = false;
        isInMenu = false;
        isInSafeZone = false;
        if (musicPlayer == null)
            musicPlayer = GetComponent<AudioControl>();
        if (sceneManagement == null)
            sceneManagement = GetComponent<SceneManagement>();

    }
    //Populates music player with some tracks
    void PopulateDefaultMusic()
    {
        //Create a Default Playlist
        //Loads "Assets/Resources/Music/Tracks/..."
        musicPlayer.AddTrackToPlaylist(Resources.Load<AudioClip>("Music/Tracks/First_Theme"), AudioControl.TrackType.Menu);
        musicPlayer.AddTrackToPlaylist(Resources.Load<AudioClip>("Music/Tracks/4_-_Fourth_Theme"), AudioControl.TrackType.Default);
        musicPlayer.AddTrackToPlaylist(Resources.Load<AudioClip>("Music/Tracks/Second_Theme"), AudioControl.TrackType.Death);
        musicPlayer.AddTrackToPlaylist(Resources.Load<AudioClip>("Music/Tracks/Third_Theme"), AudioControl.TrackType.Combat);
        musicPlayer.AddTrackToPlaylist(Resources.Load<AudioClip>("Music/Tracks/6_-_SixthTheme"), AudioControl.TrackType.Boss);
        musicPlayer.AddTrackToPlaylist(Resources.Load<AudioClip>("Music/Tracks/First_Theme"), AudioControl.TrackType.Safe);
    }

    
    // Update is called once per frame
    void Update()
    {

    }

}//end class
