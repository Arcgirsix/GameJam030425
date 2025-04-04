using UnityEngine;

public class DetectItem : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private float range = 10f;

    [SerializeField] private GameObject handImage;

    [SerializeField] private LayerMask allLayer = 3;

    public bool isItemHeld;
    void Update()
    {
        var targ = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        if (!Physics.Raycast(targ, range, allLayer) && !isItemHeld)
        {
            handImage.SetActive(false);
        }
        else
        {
            handImage.SetActive(true);
        }
    }
}
