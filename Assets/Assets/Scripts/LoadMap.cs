using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMap : MonoBehaviour
{
    // Variables para la barra de carga
    public GameObject PantallaDeCarga; 
    public Slider Slider; 

    // Método para cargar una escena de manera asíncrona
    public void chargerMap(int SceneId)
    {
        // Inicia la carga asincrónica de la escena
        StartCoroutine(loadAsync(SceneId));
    }

    // CoRutina para cargar una escena de manera asíncrona
    IEnumerator loadAsync(int SceneId)
    {
    
        AsyncOperation operacion = SceneManager.LoadSceneAsync(SceneId);

       
        PantallaDeCarga.SetActive(true);


        while (!operacion.isDone)
        {
         
            float progreso = Mathf.Clamp01(operacion.progress / .9f);
            
         
            Slider.value = progreso;

        
            yield return null;
        }
    }
}