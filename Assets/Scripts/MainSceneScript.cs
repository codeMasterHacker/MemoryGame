using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void GotoMemoryScene()
    {
        SceneManager.LoadScene("MemoryScene");
    }

    public void GotoReasoningScene()
    {
        SceneManager.LoadScene("ReasoningScene");
    }

    public void GotoSpeedScene()
    {
        SceneManager.LoadScene("SpeedScene");
    }
}
