using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] Argo argoso;
    private void Update()
    {
        if((argoso.t / 60) > 1.0f)
        {
            if(argoso.argoPuntaje == argoso.puntaje)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
