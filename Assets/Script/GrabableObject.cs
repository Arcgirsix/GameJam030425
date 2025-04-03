using UnityEngine;

public class GrabableObject : MonoBehaviour
{

    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float painDelay;
    [SerializeField] private bool notIngredient = false;
    private float painTimer = 5f;
    [SerializeField] private Collider knifeCollider;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        knifeCollider.enabled = true;
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
        objectRB.linearDamping = 10f;
        objectRB.angularDamping = 10f;
    }

    public void Drop()
    {
        knifeCollider.enabled = false;
        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;
        objectRB.linearDamping = 1f;
        objectRB.angularDamping = 0.05f;
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
        if (notIngredient)
        {
            return;
        }

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
                Debug.Log("aled ausecour");
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
                painDelay = 0;
                break;
        }
    }
}
