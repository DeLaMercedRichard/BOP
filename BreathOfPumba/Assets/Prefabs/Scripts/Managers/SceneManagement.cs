using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject controls;
    [SerializeField] int WaitTime = 6;
    Player player;
    public int currentSceneIndex;
    bool slowFlag;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        slowFlag = false;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (gameManager == null)
        {

            gameManager = FindObjectOfType<GameManager>();

        }
        currentSceneIndex = level;
        Debug.Log("Scene Index is " + SceneManager.GetActiveScene().buildIndex);
        //Plant Level
        if (currentSceneIndex == 2)
        {
            gameManager.musicPlayer.ReplaceTrack("5_-_Fifth_Theme", AudioControl.TrackType.Default);
        }
        //Machine Level
        if (currentSceneIndex == 3)
        {
            gameManager.musicPlayer.ReplaceTrack("6_-_SixthTheme", AudioControl.TrackType.Default);
        }
        //Germ Level
        if (currentSceneIndex == 4)
        {
            gameManager.musicPlayer.ReplaceTrack("SeventhTheme", AudioControl.TrackType.Default);
        }
        //Survival Level
        if (currentSceneIndex == 5)
        {
            gameManager.musicPlayer.ReplaceTrack("Third_Theme", AudioControl.TrackType.Default);
        }
        //Tutorial Level
        if (currentSceneIndex == 6)
        {
            gameManager.musicPlayer.ReplaceTrack("Second_Theme", AudioControl.TrackType.Default);
        }


        //Start Menu Songs
        if (currentSceneIndex == 0 || currentSceneIndex == 1)
        {
            if (!gameManager.isInMenu)
                gameManager.ToggleMenuMusic();
            gameManager.isInMenu = true;
        }
        else
        {
            if (gameManager.isInMenu)
                gameManager.ToggleMenuMusic();
        }
    }
    private void Start()
    {
        if (gameManager == null)
        {

            gameManager = FindObjectOfType<GameManager>();
          
        }
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene Index is " + SceneManager.GetActiveScene().buildIndex);
        //Plant Level
        if (currentSceneIndex == 2)
        {
            gameManager.musicPlayer.ReplaceTrack("5_-_Fifth_Theme", AudioControl.TrackType.Default);
        }
        //Machine Level
        if (currentSceneIndex == 3)
        {
            gameManager.musicPlayer.ReplaceTrack("6_-_SixthTheme", AudioControl.TrackType.Default);
        }
        //Germ Level
        if (currentSceneIndex == 4)
        {
            gameManager.musicPlayer.ReplaceTrack("SeventhTheme", AudioControl.TrackType.Default);
        }
        //Survival Level
        if (currentSceneIndex == 5)
        {
            gameManager.musicPlayer.ReplaceTrack("Third_Theme", AudioControl.TrackType.Default);
        }
        //Tutorial Level
        if (currentSceneIndex == 6)
        {
            gameManager.musicPlayer.ReplaceTrack("Second_Theme", AudioControl.TrackType.Default);
        }
        

        //Start Menu Songs
        if (currentSceneIndex == 0 || currentSceneIndex == 1 )
        {
            if (!gameManager.isInMenu)
                gameManager.ToggleMenuMusic();
            gameManager.isInMenu = true;
        }
        else
        {
            if (gameManager.isInMenu)
                gameManager.ToggleMenuMusic();
        }

    }

    public void ShowControls()
    {
        controls.SetActive(true);
    }
    
    private IEnumerator WaitForTime()
    {

        yield return new WaitForSeconds(WaitTime);
        //Turn Off Menu Music 

        LoadNextScene();

    }
    public void HideControls()
    {
        controls.SetActive(false);
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
    public void Loadscene3()
    {
        SceneManager.LoadScene(2);
    }
    public void Loadscene4()
    {
        SceneManager.LoadScene(3);
    }
    public void Loadscene5()
    {
        SceneManager.LoadScene(4);
    }
    public void Loadscene6()
    {
        SceneManager.LoadScene(5);
    }
    private void Update()
    {
        //Prevent Quick Toggling and lets music play for a bit
        if (!slowFlag)
        {
            if (player != null)
            {
                if (player.isEnteringBattle || player.isLeavingBattle)
                {
                    slowFlag = true;
                    StartCoroutine(ToggleTrack("Battle"));
                }
            }
            
        }

    }
    //Passes in a string for future iterations to change toggles
    private IEnumerator ToggleTrack(string type)
    {
        if(type == "Battle")
            gameManager.ToggleBattleMusic();

        if (type == "Menu")
            gameManager.ToggleMenuMusic();

        if (type == "Boss")
        {
            gameManager.battlingBoss = !gameManager.battlingBoss;
            gameManager.ToggleBattleMusic();
        }

        if (type == "Safe")
            gameManager.TogglePauseMusic();

        if (type == "Death")
            gameManager.ToggleDeathMusic();

        yield return new WaitForSeconds(WaitTime);
        
        slowFlag = false;
    }
        void AddPlayerReferenceToGameManager(Player player_)
    {
        player = player_;
    }
}
