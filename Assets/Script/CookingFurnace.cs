using UnityEngine;

public class CookingFurnace : MonoBehaviour
{
    private GrabableObject grabableObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            other.GetComponentInParent<GrabableObject>().Pain(0);
        }
    }
}
