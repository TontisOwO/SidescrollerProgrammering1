using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string aSceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(aSceneName);
    }

    public void MoveCamera(float Move)
    {
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = Move;

        if (camPos.x <= 0)
        {
            camPos.x = 0;
        }

        gameObject.transform.position = camPos;
    }
}
