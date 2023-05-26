using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public void ReloadCurrentScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeSceneByName(string name)
    {
        if (name != null)
        {
            if (name == "MainMenu") 
            {
                Destroy(PlayerStats.playerStats.playerModel);
                Destroy(PlayerStats.playerStats);
            }
            //PlayerStats.playerStats.player.SetActive(true);
            SceneManager.LoadScene(name);
        }
    }
}
