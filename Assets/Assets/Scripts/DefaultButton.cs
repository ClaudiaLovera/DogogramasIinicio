using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class defaultButton : MonoBehaviour
{
    // Metodo para cambiar a la escena "AR camera"
    public void Scene(int SceneId)
    {
        SceneManager.LoadScene(SceneId);    
    }
    
}


