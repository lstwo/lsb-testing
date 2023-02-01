using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GeneralCollisionFunctions : MonoBehaviour
{
    /* 
     * CONFIGURATION
     * c123 = 
     * (c = configuration)
     * (Collision type)
     * (Function to execute)
     * (Attribute of that function)
     */

    [Header("On Collision Enter")]

    [Tooltip("Whether you want an object to be enabled")]
    [Label("Enable an object")] public bool c110;

    [Tooltip("What objects you want to enable")] [EnableIf("c110")]
    [Label("Objects to enable")]public GameObject[] c111;

    [Space(5)]

    [Tooltip("Whether you want an object to be disabled")]
    [Label("Disable an Object")] public bool c120;

    [Tooltip("What objects you want to disable")] [EnableIf("c120")]
    [Label("Objects to disable")] public GameObject[] c121;


}
