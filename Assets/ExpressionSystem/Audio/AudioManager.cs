using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> Tomato;
    [SerializeField] private List<AudioClip> Potato;
    [SerializeField] private List<AudioClip> Carot;
    [SerializeField] private List<AudioClip> Egg;
    [SerializeField] private List<AudioClip> Steak;

    [SerializeField] private AudioSource audioSource;

    private SO_FaceStates.Items items;

    public void AudioCommand(SO_FaceStates.AudioStates audioIndex, SO_FaceStates.Items currentItem)
    {
        switch (currentItem)
        {
            case SO_FaceStates.Items.Potato:
                SelectPotatoAudio(audioIndex);
                break;
            case SO_FaceStates.Items.Tomato:
                SelectTomatoAudio(audioIndex);
                break;
            case SO_FaceStates.Items.Carrot:
                SelectCarrotAudio(audioIndex);
                break;
            case SO_FaceStates.Items.Egg:
                SelectEggAudio(audioIndex);
                break;
            case SO_FaceStates.Items.Steak:
                SelectSteakAudio(audioIndex);
                break;
        }
    }

    private void SelectPotatoAudio(SO_FaceStates.AudioStates audioState)
    {
        int audioIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AudioStates)), audioState);
        audioSource.resource = Potato[audioIndex];

    }

    private void SelectTomatoAudio(SO_FaceStates.AudioStates audioState)
    {
        Debug.Log("Tomato Audio Selected");
        int audioIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AudioStates)), audioState);
        audioSource.resource = Tomato[audioIndex];
    }

    private void SelectCarrotAudio(SO_FaceStates.AudioStates audioState)
    {
        int audioIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AudioStates)), audioState);
        audioSource.resource = Carot[audioIndex];
    }

    private void SelectEggAudio(SO_FaceStates.AudioStates audioState)
    {
        int audioIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AudioStates)), audioState);
        audioSource.resource = Egg[audioIndex];
    }

    private void SelectSteakAudio(SO_FaceStates.AudioStates audioState)
    {
        int audioIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AudioStates)), audioState);
        audioSource.resource = Steak[audioIndex];
    }

}