using UnityEngine;
using static SO_FaceStates;

public class GrabableObject : MonoBehaviour
{

    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float painDelay;
    public bool notIngredient = false;
    private float painTimer = 5f;
    [SerializeField] private Collider knifeCollider;

    [SerializeField] private int painState = 0;

    public FaceManager faceManager;
    public AudioManager audioManager;
    [SerializeField] private GameObject spriteGameObject;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool isAlive = false;
    //public SO_FaceStates state;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        if (isAlive == false)
        {
            GetAlive();
            isAlive = true;
        }

        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
        objectRB.linearDamping = 10f;
        objectRB.angularDamping = 10f;

        if (notIngredient)
        {
            knifeCollider.enabled = false;
        }
    }

    private void GetAlive()
    {
        spriteGameObject.SetActive(true);
        meshRenderer.enabled = false;
    }

    public void Drop()
    {
        
        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;
        objectRB.linearDamping = 1f;
        objectRB.angularDamping = 0.05f;

        if (notIngredient)
        {
            knifeCollider.enabled = false;
        }
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

                faceManager.StateCommand(SO_FaceStates.BasicStates.Shocked);
                audioManager.AudioCommand(SO_FaceStates.Audio.Pain);

                GetComponent<AudioSource>().Play();

                Debug.Log("aled ausecour");

                PainEffects(typeOfPain, painState);

                audioManager.enabled = false;

                break;
            case 1:
                //water
                faceManager.StateCommand(SO_FaceStates.BasicStates.Shocked);
                audioManager.AudioCommand(SO_FaceStates.Audio.Drowning);

                GetComponent<AudioSource>().Play();

                Debug.Log("ydfavfauydauyhdvzautvd");
                painDelay = 0;
                PainEffects(typeOfPain, painState);

                audioManager.enabled = false;

                break;
            case 2:
                //oil
                painDelay = 0;
                faceManager.StateCommand(SO_FaceStates.BasicStates.Mad);
                PainEffects(typeOfPain, painState);
                break;
            case 3:
                //knife
                faceManager.StateCommand(SO_FaceStates.BasicStates.Shy);
                Debug.Log("aiouch euurrghhh");
                painDelay = 0;

                PainEffects(typeOfPain, painState);
                break;
            case 4:
                //pan
                faceManager.StateCommand(SO_FaceStates.BasicStates.Dead);
                painDelay = 0;
                PainEffects(typeOfPain, painState);
                break;
        }
    }

    private void PainEffects(int  typeOfPain, int _painState)
    {
        if (_painState >= 4)
        {
            //ded
            return;
        }

        if (_painState == 3)
        {
            switch (typeOfPain)
            {
                case 0:
                    //furnace
                    break;
                case 1:
                    //water
                    break;
                case 2:
                    //oil
                    break;
                case 3:
                    //knife
                    break;
                case 4:
                    //pan
                    break;
            }
            painState = 4;
        }

        if (_painState == 2)
        {
            switch (typeOfPain)
            {
                case 0:
                    //furnace
                    break;
                case 1:
                    //water
                    break;
                case 2:
                    //oil
                    break;
                case 3:
                    //knife
                    break;
                case 4:
                    //pan
                    break;
            }
            painState = 3;
        }

        if (_painState == 1) 
        {
            switch (typeOfPain)
            {
                case 0:
                    //furnace
                    break;
                case 1:
                    //water
                    break;
                case 2:
                    //oil
                    break;
                case 3:
                    //knife
                    break;
                case 4:
                    //pan
                    break;
            }
            painState = 2;
        }

        if (_painState == 0)
        {
            switch (typeOfPain)
            {
                case 0:
                    //furnace
                    break;
                case 1:
                    //water
                    break;
                case 2:
                    //oil
                    break;
                case 3:
                    //knife
                    break;
                case 4:
                    //pan
                    break;
            }
            painState = 1;
        }
    }

    private void OnDestroy()
    {
        
    }
}
