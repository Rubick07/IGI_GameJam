using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _SfxSlider;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSfx()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SfxVolume()
    {
        AudioManager.Instance.SFXVolume(_SfxSlider.value);
    }
}
