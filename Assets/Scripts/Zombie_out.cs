using UnityEngine;

public class Zombie_out : MonoBehaviour
{
    GameObject character;
    Rigidbody rb;
    public float speed = 2f;

    void Start()
    {
        character = GameObject.Find("Ch15_nonPBR");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(character.transform);
        transform.Rotate(0, 270, 0);

    }
}
