using TMPro;
using UnityEngine;

public class Militar : MonoBehaviour
{
    public float velMov = 2.0f;
    public float velRota = 50.0f;
    public float ejeX, ejeY;
    public TextMeshProUGUI textoLlave;

    private int llave;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        textoLlave.text = "0";
        llave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ejeX = Input.GetAxis("Horizontal");
        ejeY = Input.GetAxis("Vertical");

        transform.Translate(0, 0, Time.deltaTime * velMov * ejeY);
        transform.Rotate(0, Time.deltaTime * velRota * ejeX, 0);

        animator.SetFloat("ejeX", ejeX);
        animator.SetFloat("ejeY", ejeY);
        
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * velRota * Time.deltaTime, 0);

        animator.SetFloat("ejeX", ejeX);
        animator.SetFloat("ejeY", ejeY);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -velRota * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, velRota * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Llaves")
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
            llave++;
            textoLlave.text = llave.ToString();
        }
    }
}
