using UnityEngine;
using UnityEngine.Audio;

namespace Theerapat_Boongrom.Code672110100
{
    [CreateAssetMenu(fileName = "SoundSetting", menuName = "Scriptable Objects/SoundSO")]
    public class SoundSetting : ScriptableObject
    {
        public AudioMixer AudioMixer;

        [Header("MasterVolume")]
        public string MasterVolumeName = "MasterVolume";
        [Range(-80,20)]
        public float MasterVolume;

        [Header("MusicVolume")]
        public string MusicVolumeName = "MusicVolume";
        [Range(-80,20)]
        public float MusicVolume;

        [Header("MasterSFXVolume")]
        public string MasterSFXVolumeName = "MasterSFXVolume";
        [Range(-80,20)]
        public float MasterSFXVolume;

        [Header("SFXVolume")]
        public string SFXVolumeName = "SFXVolume";
        [Range(-80,20)]
        public float SFXVolume;

        [Header("UIVolume")]
        public string UIVolumeName = "UIVolume";
        [Range(-80,20)]
        public float UIVolume;
    }
    
}
