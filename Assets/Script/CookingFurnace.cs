using UnityEngine;

public class CookingFurnace : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GrabableObject>() != null)
        {
            other.gameObject.GetComponent<GrabableObject>().Pain(0);
        }
    }
}
