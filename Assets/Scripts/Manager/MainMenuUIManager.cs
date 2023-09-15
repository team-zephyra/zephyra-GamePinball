using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    public void SceneSwitcher(string sceneNameToLoad)
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
