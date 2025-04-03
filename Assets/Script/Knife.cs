using UnityEngine;

public class Knife : MonoBehaviour
{

    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;
    [SerializeField] private float lerpSpeed;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
        objectRB.linearDamping = 10f;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;
        objectRB.linearDamping = 1f;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            Vector3 nextPos = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.fixedDeltaTime * lerpSpeed);
            objectRB.MovePosition(nextPos);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            other.GetComponentInParent<GrabableObject>().Pain(3);
        }
    }
}
