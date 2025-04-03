using UnityEngine;

public class GrabableObject : MonoBehaviour
{

    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float painDelay;
    private float painTimer = 5f;

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
        if ( objectGrabPointTransform !=null)
        {
            Vector3 nextPos = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.fixedDeltaTime * lerpSpeed);
            objectRB.MovePosition(nextPos);
        }
    }

    public void Pain(int typeOfPain)
    {
        if (painDelay < painTimer)
        {
            painDelay += Time.deltaTime;
            return;
        }


        switch (typeOfPain)
        {
            case 0:
                //furnace
                painDelay = 0;
                Debug.Log("nnnnnnnnnnnnnnnnn");
                break;
            case 1:
                //water
                painDelay = 0;
                break;
            case 2:
                //oil
                painDelay = 0;
                break;
            case 3:
                //knife
                Debug.Log("aiouch euurrghhh");
                painDelay = 0;
                break;
            case 4:
                //pan
                Debug.Log("IIIIIIIIIIIII");
                painDelay = 0;
                break;
        }
    }
}
