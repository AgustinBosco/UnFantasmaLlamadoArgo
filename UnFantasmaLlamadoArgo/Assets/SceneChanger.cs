using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{

    [SerializeField] Argo argoso;
    private void Update()
    {
        if(argoso.puntaje == 3)
        {
            SceneManager.LoadScene(1);
            Debug.Log(argoso.puntaje);
        }
        Debug.Log(argoso.puntaje);
    }
}
