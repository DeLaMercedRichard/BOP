using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Responsible for Controlling Audio Soundtracks
public class SFXControl : MonoBehaviour
{
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] List<AudioClip> sfx_clips;
    //public AudioMixerGroup amgGame;

    public string[] sfx_names = {
        // Astro-Player
        "Player - Shoot",
        "Player - Death",
        "Player - Damage",
        "Player - Reload",
        "Player - Step",
        "Player - Step",
        "Player - Step",
        "Player - Step",
        
        // Planet Enemies
        "Daughter Beetle - Cry",
        "Daughter Beetle - Tunnel Burst",
        // "Root - Death",  SADLY, UNUSED
        // "Root - Death",  SADLY, UNUSED
        // "Root - Dance",  SADLY, UNUSED
        // "Root - Laugh",  SADLY, UNUSED

        // Germ enemies
        "Spot Germ - Splitting",
        "Snake Germ - Shoot",
        "Snake Germ - Slither",

        // Machine enemies
        "Turret - Shoot",
        // "Spike Trap - Activate",  UNUSED

        // Pick-ups
        "Ammo Pick-up - Creation",
        "Ammo Pick-up - Pick up",
        "Ammo Pick-up - Pick up",
        "Health Pick-up - Creation",
        "Health Pick-up - Pick up",
        
        // Rocket
        "Rocket - Door Close",
        "Rocket - Launch",
        "Rocket - Loop",  // ?
        //"Rocket - Door Open", UNNEEDED CURRENTLY
        //"Rocket - Land", UNNEEDED CURRENTLY

        // UI
        "Button Select",
        
        // MISC
        "Blood Splatter",
        "Blood Splatter",
        "Machine Spark",
    };

    private Dictionary<string, AudioClip> sfx;

    uint player_step_count = 0;
    uint ammo_pickup_pickup_count = 0;
    uint blood_splatter_count = 0;

    void Start()
    {
        if (sfx_clips == null)
            sfx_clips = new List<AudioClip>(1);

        if (audioPlayer == null)
            audioPlayer = GetComponent<AudioSource>();

        sfx = new Dictionary<string, AudioClip>();

        for (int i = 0; i < sfx_clips.Count; i++)
        {
            switch (sfx_names[i])
            {
                case "Player - Step":
                    sfx.Add(sfx_names[i] + " #" + (++player_step_count).ToString(), sfx_clips[i]);
                    break;
                case "Ammo Pick-up - Pick up":
                    sfx.Add(sfx_names[i] + " #" + (++ammo_pickup_pickup_count).ToString(), sfx_clips[i]);
                    break;
                case "Blood Splatter":
                    sfx.Add(sfx_names[i] + " #" + (++blood_splatter_count).ToString(), sfx_clips[i]);
                    break;
                default:
                    sfx.Add(sfx_names[i], sfx_clips[i]);
                    break;
            }
        }
    }

    public void PlaySound(string sfx_name)
    {
        switch (sfx_name)
        {
            case "Player - Step":
                // Choose random out of # sounds
                audioPlayer.PlayOneShot(sfx[sfx_name + " #" + Random.Range(1, player_step_count).ToString()]);
                break;
            case "Ammo Pick-up - Pick up":
                // Choose random out of # sounds
                audioPlayer.PlayOneShot(sfx[sfx_name + " #" + Random.Range(1, ammo_pickup_pickup_count).ToString()]);
                break;
            case "Blood Splatter":
                // Choose random out of # sounds
                audioPlayer.PlayOneShot(sfx[sfx_name + " #" + Random.Range(1, blood_splatter_count).ToString()]);
                break;
            default:
                audioPlayer.PlayOneShot(sfx[sfx_name]);
                break;
        }
    }

    // https://answers.unity.com/questions/362629/how-can-i-check-if-an-animation-is-being-played-or.html
    /*private bool IsPlaying()
    {
        return GetComponent<AudioSource>().clip.length >
               GetComponent<AudioSource>().time;
    }

    // https://answers.unity.com/questions/362629/how-can-i-check-if-an-animation-is-being-played-or.html
    private bool IsPlaying(string clipName)
    {
        return IsPlaying() && GetComponent<AudioSource>().clip.name == clipName;
    }

    private bool FinishedPlaying(string clipName)
    {
        return GetComponent<AudioSource>().clip.name == clipName && !IsPlaying();
    }*/
}
