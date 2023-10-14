using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Needed to create delegates

public class SpeakToHealthBar : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    private float slider;

    public static Action<float> UpdateHealthBar = delegate { };
    void Update()
    {
        UpdateHealthBar(slider);
    }
}
