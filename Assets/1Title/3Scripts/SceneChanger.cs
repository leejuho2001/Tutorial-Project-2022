using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneByName_A(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }
    public void ChangeSceneByName_B()
    {
        SceneManager.LoadScene("End Story");
    }
    // ĳ���Ϳ� scenemanager ���� �ؾ� �۵���

}
