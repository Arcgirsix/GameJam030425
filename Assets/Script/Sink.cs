using UnityEngine;

public class Sink : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            other.GetComponentInParent<GrabableObject>().Pain(1);
        }
    }
}
