using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject otherGameObject;
    [SerializeField] private bool isOn = false;

    public void _Button()
    {

        if (!isOn)
        {
            otherGameObject.SetActive(true);
            isOn = true;
        }
        else
        {
            otherGameObject.SetActive(false);
            isOn = false;
        }
        
    }
}
