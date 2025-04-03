using UnityEngine;

public class Knife : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            other.GetComponentInParent<GrabableObject>().Pain(3);
        }
    }
}
