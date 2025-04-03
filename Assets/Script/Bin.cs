using Unity.VisualScripting;
using UnityEngine;

public class Bin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            if (other.GetComponent<GrabableObject>() != null)
            {
                if (other.GetComponent <GrabableObject>().notIngredient == false)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
