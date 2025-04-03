using UnityEngine;

public class CookingFurnace : MonoBehaviour
{
    private GrabableObject grabableObject;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GrabableObject>() != null)
        {
            Debug.Log(other);
        }
    }
}
