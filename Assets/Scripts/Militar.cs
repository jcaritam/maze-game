using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Militar : MonoBehaviour
{
    public float velMov = 2.0f;
    public float velRota = 50.0f;
    public float ejeX, ejeY;
    public TextMeshProUGUI textoLlave;
    public TextMeshProUGUI messageText;
    private int llave;
    private Animator animator;

    public Image barraVida;
    private float vida;
    void Start()
    {
        animator = GetComponent<Animator>();
        textoLlave.text = "0";
        llave = 0;
        vida = 100;
        barraVida.fillAmount = vida / 100;
        messageText = GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>();
        messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        ejeX = Input.GetAxis("Horizontal");
        ejeY = Input.GetAxis("Vertical");

        transform.Translate(0, 0, Time.deltaTime * velMov * ejeY);
        transform.Rotate(0, Time.deltaTime * velRota * ejeX, 0);

        animator.SetFloat("ejeX", ejeX);
        animator.SetFloat("ejeY", ejeY);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Llaves")
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
            llave++;
            textoLlave.text = llave.ToString();
            if (llave >= 5)
            {
                messageText.gameObject.SetActive(true);
            }
        }
        if (other.tag == "Vida")
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
            vida = vida + 20;
            barraVida.fillAmount = vida / 100;
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "zombies")
        {
            vida = vida - 20;
            barraVida.fillAmount = vida / 100;
            if (vida <= 0)
            { SceneManager.LoadScene(2); }
        }
        if (collision.collider.tag == "door")
        {
            if (llave >= 5)
            {
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject, 0.1f);
                messageText.text = "¡Felicidades! Superaste el nivel";
                messageText.fontSize = 35;
                messageText.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Aún faltan llaves");
            }
        }
    }

}
