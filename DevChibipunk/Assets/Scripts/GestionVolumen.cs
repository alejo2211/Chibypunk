using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionVolumen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("VolumenAudio", 0.5f);
        print(PlayerPrefs.GetFloat("VolumenAudio", 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
