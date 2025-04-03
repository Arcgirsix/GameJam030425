using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{

    [SerializeField] private List<Sprite> eyes;
    [SerializeField] private List<Sprite> mouths;
    [SerializeField] private List<int> states;

    public void Start()
    {
        #region DEBUG - Conditions

        #region Eyes
        bool conditionEyesLeft = Input.GetKeyDown(KeyCode.Alpha1);
        bool conditionEyesRight = Input.GetKeyDown(KeyCode.Alpha3);
        #endregion

        #region Mouths
        bool conditionMouthLeft = Input.GetKeyDown(KeyCode.Alpha7);
        bool conditionMouthRight = Input.GetKeyDown(KeyCode.Alpha9);
        #endregion

        #endregion

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StateCommand(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StateCommand(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StateCommand(2);
        }

    }

    public void StateCommand(int stateIndex)
    {
        SelectEyes(stateIndex);
        SelectMouths(stateIndex);
    }

    private void SelectEyes(int eyeIndex)
    {

        Debug.Log(eyes[eyeIndex]);
    }

    private void SelectMouths(int mouthIndex)
    {
        Debug.Log(mouths[mouthIndex]);
    }

    private void InitElements(SpriteRenderer sprites)
    {
        
    }
}