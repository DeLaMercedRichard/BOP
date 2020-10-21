using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public int selectedTrack = 0;
    
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int PreviousTrack = selectedTrack;
        if (PreviousTrack != selectedTrack)
        {
            SelectedTrack();
        }
    }
    private void SelectedTrack()
    {
        int i = 0;
        foreach (Transform Track in transform)
        {
            if (i == selectedTrack)
            {
                Track.gameObject.SetActive(true);
            }
            else
            {
                Track.gameObject.SetActive(false);
            }
            i++;

        }

    }
    public void BattleTrack()
    {
        
        if(selectedTrack == 1)
        {
            Debug.Log("already in Battle");
        }
        else { selectedTrack = 1; }
    }
}
