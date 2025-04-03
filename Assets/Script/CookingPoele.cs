using UnityEngine;

public class CookingPoele : MonoBehaviour
{
    private GrabableObject grabableObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            other.GetComponentInParent<GrabableObject>().Pain(4);
        }
    }
}
