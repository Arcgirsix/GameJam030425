using UnityEngine;
using System;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour
{
    //[SerializeField] private AudioSource AudioSource;
    [SerializeField] private List<AudioClip> AudioClipList;

    public void AudioCommand(SO_FaceStates.Audio audioIndex)
    {
        SelectAudio(audioIndex);
    }

    private void SelectAudio(SO_FaceStates.Audio audioState)
    {
        int audioIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.Audio)), audioState);

        GameObject.Find("Apple").GetComponent<AudioSource>().resource = AudioClipList[audioIndex];
    }

}