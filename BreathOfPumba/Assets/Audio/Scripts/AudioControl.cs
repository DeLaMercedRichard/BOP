// Use: AudioControl.Main.Play("Sound name");

using System.Collections.Generic;
using UnityEngine;

//Responsible for Controlling Music Soundtracks
public class AudioControl : MonoBehaviour
{
    static AudioControl Main;
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] List<AudioClip> tracks;

    [SerializeField]  //?
    public enum TrackType
    {
        Default,
        Combat,
        Boss,
        Pause,
        Death,
        Menu
    }

    // Start is called before the first frame update
    void Start()
    {
        if (tracks == null)
            tracks = new List<AudioClip>(12);

        if (audioPlayer == null)
            audioPlayer = GetComponent<AudioSource>();

        Main = this;
    }
    
    public void AddTrackToPlaylist(string name, TrackType type)
    {
        tracks.Insert((int)type, Resources.Load<AudioClip>("Music/Tracks/" + name));
    }

    public void ReplaceTrack(string name, TrackType type)
    {
        tracks[(int)type] = Resources.Load<AudioClip>("Music/Tracks/" + name);
    }

    public void ClearPlayList()
    {
        tracks.Clear();
    }


    public void PlayTrack(TrackType type)
    {
        //If There is a Track added for it Play Track else Don't bother Trying
        audioPlayer.clip = tracks[(int)type];
        audioPlayer.Play();
        audioPlayer.loop = true;

    }

    public bool isEmpty()
    {
        bool empty;
        if (tracks.Count == 0)
            empty = true;
        else
            empty = false;
        return empty;
    }
}
