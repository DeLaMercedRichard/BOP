using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Track Types to Keep Track of Max size = 6
  public enum TrackType
    {
        Default,
        Combat,
        Boss,
        Safe,
        Death,
        Menu
    }
 */
public class GameManager : MonoBehaviour
{
    AudioControl musicPlayer;
    SceneManagement sceneManagement;
    bool inBattle;
    bool battlingBoss;
    // Start is called before the first frame update
    void Start()
    {
        SetDefaultsIfNoneSet();

        if (musicPlayer.isEmpty())
        {
            PopulateDefaultMusic();  
        }
        
        //Play the Menu Music At Start (assuming menu is the first scene that loads up) else play default Music
        if(sceneManagement.currentSceneIndex == 0)
        musicPlayer.PlayTrack(AudioControl.TrackType.Menu);
        else
        musicPlayer.PlayTrack(AudioControl.TrackType.Default);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerNextScene()
    {

        sceneManagement.LoadNextScene();
    }

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


    //***************************************************************************Just Chunk Code Put into Functions For Easier Reading

    //Just Covering basis for incase variables not set in inspector
    void SetDefaultsIfNoneSet()
    {
        inBattle = false;
        battlingBoss = false;
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
    
}//end class
