using UnityEngine;
using System.Collections;

public class SetActive : MonoBehaviour
{
    public GameObject ExplodeFx;

    void Start()
    {
        ExplodeFx.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ExplodeFx.SetActive(true);
            
        }
        if (ExplodeFx.activeSelf) 
        {
            StartCoroutine(ExampleCoroutine());

        }   
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
        ExplodeFx.SetActive(false);
    }

}
