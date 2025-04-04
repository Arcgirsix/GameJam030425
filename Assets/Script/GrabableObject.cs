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
<<<<<<< Updated upstream
    public AnimationManager animationManager;
=======
    [SerializeField] private GameObject spriteGameObject;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool isAlive = false;

    [SerializeField] private SO_FaceStates.Items itemType;
>>>>>>> Stashed changes

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

        faceManager.StateCommand(SO_FaceStates.BasicStates.Dumb);
    }

    public void Drop()
    {
<<<<<<< Updated upstream
        knifeCollider.enabled = false;
=======

>>>>>>> Stashed changes
        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;
        objectRB.linearDamping = 1f;
        objectRB.angularDamping = 0.05f;

        faceManager.enabled = false;
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

<<<<<<< Updated upstream
                faceManager.StateCommand(SO_FaceStates.BasicStates.Scared);
                audioManager.AudioCommand(SO_FaceStates.Audio.Pain);
                animationManager.AnimationCommand(SO_FaceStates.AnimationEffect.ScaleVertical);

=======
                faceManager.StateCommand(SO_FaceStates.BasicStates.Shocked);
                SoundsLikeA(SO_FaceStates.AudioStates.BigPain, itemType);
>>>>>>> Stashed changes

                GetComponent<AudioSource>().Play();

                Debug.Log("aled ausecour");

                PainEffects(typeOfPain, painState);

                //animationManager.AnimationCommand(SO_FaceStates.AnimationEffect.NoTransform);
                audioManager.enabled = false;

                break;
            case 1:
                //water
<<<<<<< Updated upstream
=======
                Debug.Log("ydfavfauydauyhdvzautvd");

>>>>>>> Stashed changes
                faceManager.StateCommand(SO_FaceStates.BasicStates.Shocked);
                SoundsLikeA(SO_FaceStates.AudioStates.Drowning, itemType);

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
                SoundsLikeA(SO_FaceStates.AudioStates.Pleasure, itemType);

                PainEffects(typeOfPain, painState);
                break;
            case 3:
                //knife
                faceManager.StateCommand(SO_FaceStates.BasicStates.Shy);
                SoundsLikeA(SO_FaceStates.AudioStates.Pleasure, itemType);

                Debug.Log("aiouch euurrghhh");
                painDelay = 0;

                PainEffects(typeOfPain, painState);
                break;
            case 4:
                //pan
                faceManager.StateCommand(SO_FaceStates.BasicStates.Dead);
                SoundsLikeA(SO_FaceStates.AudioStates.BigPain, itemType);
                painDelay = 0;
                PainEffects(typeOfPain, painState);
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
