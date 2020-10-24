using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField] int WaitTime = 6;
    Player player;
    public int currentSceneIndex;
    bool slowFlag;
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        slowFlag = false;
    }
    private void Start()
    {
        if (currentSceneIndex == 0)
        {
            //Turn On Menu Music
            gameManager.ToggleMenuMusic();
            StartCoroutine(WaitForTime());
        }
    }


    private IEnumerator WaitForTime()
    {

        yield return new WaitForSeconds(WaitTime);
        //Turn Off Menu Music 
        gameManager.ToggleMenuMusic();
        LoadNextScene();

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
            gameManager.ToggleSafeMusic();

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
