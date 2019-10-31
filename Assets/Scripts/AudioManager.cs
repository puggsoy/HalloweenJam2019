using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public GameObject kidSFX;
    private AudioSource[] kidAS;
    private int allKidSFX;
    public GameObject grandMaSFX;
    private AudioSource[] grandMaAS;
    private int allGrandMaSFX;
    public GameObject musicMusic;
    private AudioSource[] musicAS;
    private int allMusic;

    // Start is called before the first frame update
    void Start()
    {
        kidAS = kidSFX.GetComponentsInChildren<AudioSource>();
        allKidSFX = kidAS.Length;
        grandMaAS = grandMaSFX.GetComponentsInChildren<AudioSource>();
        allGrandMaSFX = grandMaAS.Length;
        musicAS = musicMusic.GetComponentsInChildren<AudioSource>();
        allMusic = musicAS.Length;
        MUSICmusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SFXkid()
    {
        int randomKidSFX = Random.Range(0, allKidSFX);
        kidAS[randomKidSFX].Play();
    }

    public void SFXgrandma()
    {
        int randomGrandMaSFX = Random.Range(0, allGrandMaSFX);
        grandMaAS[randomGrandMaSFX].Play();
    }

    public void MUSICmusic()
    {
        int randomMusic = Random.Range(0, allMusic);
        musicAS[randomMusic].Play();
    }

}
