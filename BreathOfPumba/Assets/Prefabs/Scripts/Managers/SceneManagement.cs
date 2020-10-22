using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField] int WaitTime = 4;
    Player player;
    public int currentSceneIndex;
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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

    private void Update()
    {
       
        if (player != null)
        {
            if (gameManager.inBattle)
            {
                gameManager.ToggleBattleMusic();
            } 
        }

    }


    void AddPlayerReferenceToGameManager(Player player_)
    {
        player = player_;
    }
}
