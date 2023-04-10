using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject BGMusic;
    public Slider VolValue;
    public static float musicVolume;
    private AudioSource audioSrc;

    void Awake()
    {
        var soundObjects = GameObject.FindGameObjectsWithTag("Sound");
        if (soundObjects.Length == 0)
        {
            BGMusic = Instantiate(BGMusic);
            BGMusic.name = "BGMusic"; 
            DontDestroyOnLoad(BGMusic.gameObject);
        }
        else
        {
            BGMusic = GameObject.Find("BGMusic"); 
        }
        if (!PlayerPrefs.HasKey("MusicVol"))
        {
            musicVolume = 0.1f; 
        }
        else
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVol"); 
            VolValue.value = PlayerPrefs.GetFloat("MusicVol"); 
        }
    }

    private void OnEnable()
    {
        VolValue.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        VolValue.onValueChanged.RemoveListener(SetVolume);
    }

    void Start()
    {
        audioSrc = BGMusic.GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = musicVolume; 
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol);
    }

    public void MusicOff()
    {
        audioSrc.Stop();
    }

    public void MusicOn()
    {
        audioSrc.Play();
    }
}