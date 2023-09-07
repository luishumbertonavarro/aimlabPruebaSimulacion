using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text result;

    public static float veces;
    public static float calculado;


    void Start()
    {
        result=GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        result.text="Hay una probabilidad de "+calculado+"% de que acierten menos de 15 veces en el blanco, ud. le dio "+veces+" veces al blanco";
    }
}
