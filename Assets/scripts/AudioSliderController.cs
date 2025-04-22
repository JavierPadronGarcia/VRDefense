using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class AudioSliderController : MonoBehaviour
{
    private PinchSlider slider;

    void Start()
    {
        slider = GetComponent<PinchSlider>();

        slider.SliderValue = AudioManager.instance.musicSource.volume;

        slider.OnValueUpdated.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(SliderEventData eventData)
    {
        AudioManager.instance.SetVolume(eventData.NewValue);
    }
}
