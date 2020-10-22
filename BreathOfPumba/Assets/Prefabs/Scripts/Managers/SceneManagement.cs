using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] int WaitTime = 4;
    public int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }


    private IEnumerator WaitForTime()
    {

        yield return new WaitForSeconds(WaitTime);
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

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
