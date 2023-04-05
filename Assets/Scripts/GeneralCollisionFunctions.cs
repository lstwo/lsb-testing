using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class GeneralCollisionFunctions : MonoBehaviour
{

    [Tooltip("If 'true' then collision will be detected for a trigger")]
    [Label("Is Trigger?")] public bool boolIsTrigger;

    [Tooltip("If 'true' then code will be run when collision exited")]
    [Label("On Exit?")] public bool boolOnExit;

    [Header("Enabling / Disabling ")]

    [Tooltip("Whether you want objects to be enabled")]
    [Label("Enable objects")] public bool boolEnableObject;

    [Tooltip("What objects you want to enable")] [EnableIf("boolEnableObject")]
    [Label("Objects to enable")] public GameObject[] enableObjects;

    [Space(5)]

    [Tooltip("Whether you want an object to be disabled")]
    [Label("Disable Objects")] public bool boolDisableObject;

    [Tooltip("What objects you want to disable")] [EnableIf("boolDisableObject")]
    [Label("Objects to disable")] public GameObject[] disableObjects;

    [Header("Scene Switching")]

    [Tooltip("Whether to load a Scene")]
    [Label("Load Scene")] public bool boolLoadScene;

    [Tooltip("Whether to load the Scene asynchronously")] [EnableIf("boolLoadScene")]
    [Label("Load Scene")] public bool boolLoadAsync;

    [Tooltip("What Scene To Load")] [EnableIf("boolLoadScene")]
    [Label("Scene To Load")] public string sceneToLoad;

    private void OnCollisionEnter(Collision collision)
    {
        if(!boolIsTrigger && !boolOnExit)
            DoFunctions();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (boolIsTrigger && !boolOnExit)
            DoFunctions();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!boolIsTrigger && boolOnExit)
            DoFunctions();
    }

    private void OnTriggerExit(Collider other)
    {
        if (boolIsTrigger && boolOnExit)
            DoFunctions();
    }

    void DoFunctions()
    {
        // Scene Loading
        if (boolLoadScene)
        {
            if (boolLoadAsync)
                SceneManager.LoadSceneAsync(sceneToLoad);
            else
                SceneManager.LoadScene(sceneToLoad);
        }

        // Enabling Object
        if (boolEnableObject)
        {
            foreach (GameObject go in disableObjects)
                go.SetActive(true);
        }
            

        // Disabling Object
        if (boolDisableObject)
        {
            foreach (GameObject go in disableObjects)
                go.SetActive(false);
        }
            
    }


}
