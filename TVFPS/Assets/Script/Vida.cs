using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
    private int saludJ = 1000;
    bool isVulnerable;
    public GameObject GameOverMenuUI;
    public GameObject Jugador;
    public GameObject JuegoUI;

    public Text UIsaludJ;
    // Use this for initialization
    void Start()
    {
        isVulnerable = true;
        GameOverMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        UIsaludJ.text = saludJ.ToString();
        if (saludJ <= 0)
        {
            Time.timeScale = 0f;
            Jugador.SetActive(false);
            JuegoUI.SetActive(false);
            GameOverMenuUI.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision _other)
    {
        Debug.Log("Me esta tocando " + _other.transform.tag);
        if (_other.transform.tag == "enemigo" && isVulnerable == true)
        {
            StartCoroutine(Daño());
            Debug.Log("me hicieron daño");
        }

    }

    void OnTriggerEnter(Collider _other)
    {
        Debug.Log("Me esta tocando" + _other.transform.tag);
        if (_other.transform.tag == "enemigo" && isVulnerable == true)
        {
            StartCoroutine(Daño());
            Debug.Log("me hicieron daño");
        }
    }

    IEnumerator Daño()
    {
        saludJ -= 50;
        isVulnerable = false;

        yield return new WaitForSeconds(.5f);
        isVulnerable = true;
    }
}
