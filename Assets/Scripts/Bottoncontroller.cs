using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottoncontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        Debug.Log("クリックされた");
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
