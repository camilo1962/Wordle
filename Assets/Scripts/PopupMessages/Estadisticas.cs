using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadisticas : MonoBehaviour
{
    public static Estadisticas instance;

    public GameObject estadisticasPrefab;


    private void Awake()
    {
        instance = this;
    }

    public void NewMessage(string message, float time)
    {
        var newMes = Instantiate(estadisticasPrefab, transform);
        newMes.GetComponent<Message>().InitMessage(message, time);
    }
   
    void Update()
    {
        
    }
}
