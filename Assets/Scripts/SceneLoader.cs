using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        SetRatio(4, 3);
    }
    void SetRatio(float w, float h)
    {
        if ((((float)Screen.width) / ((float)Screen.height)) > w / h)
        {
            Screen.SetResolution((int)(((float)Screen.height) * (w / h)), Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (h / w)), true);
        }
    }
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
