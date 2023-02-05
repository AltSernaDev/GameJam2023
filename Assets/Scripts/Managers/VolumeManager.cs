using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Text volumeValueText;

    private void Start()
    {
        LoadVolume();
    }

    public void VolumeSlider2Text(float volume)
    {
        volumeValueText.text = volume.ToString("P");
    }
    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue" , volumeValue);
    }

    public void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        volumeValueText.text = volumeValue.ToString("P");
        AudioListener.volume = volumeValue;
    }
}
