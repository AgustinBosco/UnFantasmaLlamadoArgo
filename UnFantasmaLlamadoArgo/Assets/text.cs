using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{

    [SerializeField] Argo argos;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        switch (argos.currentstate)
        {
            case Argo.States.ATTACK:
                texto.text = "Objetivo: Escapa de argo";
                break;
            case Argo.States.IDLE:
                texto.text = "Objetivo: Argo te espera";
                break;
            case Argo.States.CORREWACHIN:
                texto.text = "Objetivo: atrapalo al wachin de argo";
                break;
        }
    }
}
