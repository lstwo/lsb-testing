using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float reachDistance = 2.0f;
    public LayerMask interactableLayer;

    private Camera camera;
    private Rigidbody rigidbodyToPick;
    private Transform holdingPoint;
    private Transform targetPoint;

    private void Start()
    {
        camera = GetComponentInChildren<Camera>();
        holdingPoint = camera.transform.GetChild(0);
        targetPoint = holdingPoint.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, reachDistance, interactableLayer))
            {
                rigidbodyToPick = hit.collider.GetComponent<Rigidbody>();

                if (rigidbodyToPick != null)
                {
                    rigidbodyToPick.velocity = Vector3.zero;
                    rigidbodyToPick.angularVelocity = Vector3.zero;
                    targetPoint.position = hit.point;
                }
            }
        }

        if (Input.GetMouseButton(0) && rigidbodyToPick != null)
        {
            rigidbodyToPick.velocity = (targetPoint.position - rigidbodyToPick.position) * 10.0f;
        }

        if (Input.GetMouseButtonUp(0) && rigidbodyToPick != null)
        {
            rigidbodyToPick = null;
        }
    }
}
