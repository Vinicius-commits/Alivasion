using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Inverter("Olá Mundo Invertido"));
    }
    public string Inverter(string s)
    {
        string invertido = "";
        for(int i = s.Length - 1; i >= 0; i--)
        {
            invertido += s[i];
        }
        return invertido;
    } 

    
}
