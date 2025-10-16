using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionBrillo : MonoBehaviour
{
    public Image imagenBrillo;
    void Start()
    {
        imagenBrillo.color = new Color(0, 0, 0, PlayerPrefs.GetFloat("Brillo", 0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
