using UnityEngine;
using UnityEngine.Rendering;
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

    [Header("## Managers ## ")]
    public FaceManager faceManager;
    public AudioManager audioManager;
    //public AnimationManager animationManager;

    [SerializeField] private GameObject spriteGameObject;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool isAlive = false;

    [SerializeField] private SO_FaceStates.Items itemType;


    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        if (isAlive == false)
        {
            if (notIngredient)
            {
                return;
            }
            GetAlive();
            isAlive = true;
        }

        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
        objectRB.linearDamping = 10f;
        objectRB.angularDamping = 10f;

        if (notIngredient)
        {
            knifeCollider.enabled = true;
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
        if (objectGrabPointTransform != null)
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

                faceManager.StateCommand(SO_FaceStates.BasicStates.Scared);
                audioManager.AudioCommand(SO_FaceStates.AudioStates.Pain, itemType);
                //animationManager.AnimationCommand(SO_FaceStates.AnimationEffect.ScaleVertical);

                faceManager.StateCommand(SO_FaceStates.BasicStates.Dead);
                SoundsLikeA(SO_FaceStates.AudioStates.BigPain, itemType);

                GetComponent<AudioSource>().Play();

                //Debug.Log("aled ausecour");

                PainEffects(typeOfPain, painState);

                //animationManager.AnimationCommand(SO_FaceStates.AnimationEffect.NoTransform);
                audioManager.enabled = false;

                break;
            case 1:
                //water

                //Debug.Log("ydfavfauydauyhdvzautvd");

                faceManager.StateCommand(SO_FaceStates.BasicStates.Shocked);
                SoundsLikeA(SO_FaceStates.AudioStates.Drowning, itemType);

                GetComponent<AudioSource>().Play();

                //Debug.Log("ydfavfauydauyhdvzautvd");
                painDelay = 0;
                PainEffects(typeOfPain, painState);

                audioManager.enabled = false;

                break;
            case 2:
                //oil
                painDelay = 0;
                faceManager.StateCommand(SO_FaceStates.BasicStates.Mad);
                SoundsLikeA(SO_FaceStates.AudioStates.Pleasure, itemType);

                GetComponent<AudioSource>().Play();

                PainEffects(typeOfPain, painState);

                audioManager.enabled = false;

                break;
            case 3:
                //knife
                faceManager.StateCommand(SO_FaceStates.BasicStates.Shy);
                SoundsLikeA(SO_FaceStates.AudioStates.Pleasure, itemType);

                GetComponent<AudioSource>().Play();

                //Debug.Log("aiouch euurrghhh");
                painDelay = 0;

                PainEffects(typeOfPain, painState);

                audioManager.enabled = false;

                break;
            case 4:
                //pan
                faceManager.StateCommand(SO_FaceStates.BasicStates.Dead);
                SoundsLikeA(SO_FaceStates.AudioStates.BigPain, itemType);

                GetComponent<AudioSource>().Play();

                painDelay = 0;

                PainEffects(typeOfPain, painState);

                audioManager.enabled = false;
                break;
        }
    }

    private void PainEffects(int typeOfPain, int _painState)
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

    private void SoundsLikeA(SO_FaceStates.AudioStates audioStates, SO_FaceStates.Items item )
    {
        audioManager.AudioCommand(audioStates, item);
    }
}
