using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public TMP_Text textoContador, textoGanar;
    private CameraController cameraController;
    private AudioSource audioSource;
    public ParticleSystem celebrateSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        contador = 0;

        setTextoContador();
        textoGanar.text = "";
        cameraController = FindObjectOfType<CameraController>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }


    void FixedUpdate()
    {
        Vector3 direccionMovimiento = cameraController.GetMovementDirection();

        rb.AddForce(direccionMovimiento * velocidad);
        celebrateSound.transform.position = rb.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable") || other.gameObject.CompareTag("Lingote"))
        {
            other.gameObject.SetActive(false);
            contador++;

            if (other.gameObject.CompareTag("Lingote"))
            {
                contador += 4;
            }
            setTextoContador();
            audioSource.Play();
        }
    }

    void setTextoContador()
    {

        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 20)
        {
            textoGanar.text = "¡Ganaste!";
            celebrateSound.gameObject.SetActive(true);
            StartCoroutine(ReturnToMainMenu(5f));
        }
    }
    private IEnumerator ReturnToMainMenu(float delay)
    {
        yield return new WaitForSeconds(delay);


        SceneManager.LoadScene(0);
    }

}

