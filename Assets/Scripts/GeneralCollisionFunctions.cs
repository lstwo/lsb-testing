using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class GeneralCollisionFunctions : MonoBehaviour
{
        // General Config
    [Tooltip("If 'true' then collision will be detected for a trigger")]
    [Label("Is Trigger?")] public bool boolIsTrigger;

    [Tooltip("If 'true' then code will be run when collision exited")]
    [Label("On Exit?")] public bool boolOnExit;

        // Enabling / Disabling
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

    // Teleport
    [Tooltip("Whether you want objects to be teleported")]
    [Label("Teleport")] public bool boolTeleport;

    [EnableIf("boolTeleport")]
    [Tooltip("Where the objects should be teleported")]
    [Label("Teleport Location")] public Vector3 teleportLocation;

    // Kill Player
    [Header("Kill Player")]

    [Tooltip("Whether to kill the player on touch")]
    [Label("Kill Player")] public bool boolKillPlayer;

    // Scene Switching
    [Header("Scene Switching")]

    [Tooltip("Whether to load a Scene")]
    [Label("Load Scene")] public bool boolLoadScene;

    [Tooltip("Whether to load the Scene asynchronously")] [EnableIf("boolLoadScene")]
    [Label("Load Scene Async")] public bool boolLoadAsync;

    [Tooltip("What Scene To Load")] [EnableIf("boolLoadScene")]
    [Label("Scene To Load")] public string sceneToLoad;

    [Tooltip("Whether to Restart the current Scene")] [EnableIf("boolLoadScene")]
    [Label("Restart Scene")] public bool boolRestartScene;

        // Force
    [Header("Force")]

    [Tooltip("Whether to add a Force to the collision Rigidbody")]
    [Label("Add Force")] public bool boolAddForce;

    [Tooltip("Whether the Force should be Type Impulse")] [EnableIf("boolAddForce")]
    [Label("ForceMode Impulse")] public bool boolImpulseForce;

    [Tooltip("Whether to use a direction from the transform")] [EnableIf("boolAddForce")]
    [Label("Use Direction")] public bool boolUseDirection;

    [Tooltip("Whether the Force should be Type Impulse")] [EnableIf("boolUseDirection")]
    public Direction forceDirection;

    [Tooltip("The amount of Force Applied on Collision")] [EnableIf("boolAddForce")]
    [Label("Force Direction")] public Vector3 forceAmount;

    [Tooltip("The amount of Force Apllied on Collision if Direction is used")] [EnableIf("boolUseDirection")]
    [Label("Force Amount")] public float forceAmountDir;

    // Velocity
    [Header("Velocity")]

    [Tooltip("Whether to change the velocity of the collision Rigidbody")]
    [Label("Change Velocity")] public bool boolChangeVelocity;

    [Tooltip("The amount of Velocity Applied on Collision")]
    [EnableIf("boolChangeVelocity")]
    [Label("Velocity Override")] public Vector3 velocityOverride;

    private void OnCollisionEnter(Collision collision)
    {
        if(!boolIsTrigger && !boolOnExit)
            DoFunctions(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (boolIsTrigger && !boolOnExit)
            DoFunctions(other);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!boolIsTrigger && boolOnExit)
            DoFunctions(collision.collider);
    }

    private void OnTriggerExit(Collider other)
    {
        if (boolIsTrigger && boolOnExit)
            DoFunctions(other);
    }

    void DoFunctions(Collider collider)
    {
            // Scene Loading
        if (boolLoadScene)
        {
            if(boolRestartScene && boolLoadAsync)
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            else if(boolRestartScene && !boolLoadAsync)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

            // Teleporting
        if(boolTeleport)
        {
            collider.transform.position = teleportLocation;
        }

            // Adding Force
        if(boolAddForce)
        {
            if(!boolUseDirection)
                AddForce(collider, forceAmount);

            if (boolUseDirection)
            {
                if(forceDirection == Direction.down)
                    AddForce(collider, -transform.up * forceAmountDir);

                if (forceDirection == Direction.up)
                    AddForce(collider, transform.up * forceAmountDir);

                if (forceDirection == Direction.left)
                    AddForce(collider, -transform.right * forceAmountDir);

                if (forceDirection == Direction.right)
                    AddForce(collider, transform.right * forceAmountDir);

                if (forceDirection == Direction.backward)
                    AddForce(collider, -transform.forward * forceAmountDir);

                if (forceDirection == Direction.forward)
                    AddForce(collider, transform.forward * forceAmountDir);
            }

        }

            // Change Velocity
        if(boolChangeVelocity)
        {
            collider.attachedRigidbody.velocity = velocityOverride;
        }

        // Kill Player

        if(boolKillPlayer && collider.gameObject.name == "Player")
        {
            UIManager.Instance.openDeathScreen();
        }
            
    }

    void AddForce(Collider collider, Vector3 force)
    {
        if (boolImpulseForce && collider.GetComponent<Rigidbody>() != null)
            collider.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        if (!boolImpulseForce && collider.GetComponent<Rigidbody>() != null)
            collider.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);
    }

    public enum Direction
    {
        forward,
        backward,
        right,
        left,
        up,
        down
    }

}

