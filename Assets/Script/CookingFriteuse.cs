using UnityEngine;

public class CookingFriteuse : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            Debug.Log("Item in Friteuse");
            other.GetComponentInParent<GrabableObject>().Pain(3);
        }
    }
}
