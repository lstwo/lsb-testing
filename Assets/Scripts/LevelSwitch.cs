using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public string name;
    public bool noUI;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync(name);
        if(!noUI)
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
}
