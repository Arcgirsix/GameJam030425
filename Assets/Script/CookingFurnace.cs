using UnityEngine;

public class CookingFurnace : MonoBehaviour
{
    private GrabableObject grabableObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
<<<<<<< Updated upstream
            Debug.Log(other);
=======
            other.GetComponentInParent<GrabableObject>().Pain(0);
>>>>>>> Stashed changes
        }
    }
}
