using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
   
    public void Load1Player()
    {
        SceneManager.LoadScene("SoloGame");
    }

    public void Load2Player()
    {
        SceneManager.LoadScene("MultiGame");

    }
}
