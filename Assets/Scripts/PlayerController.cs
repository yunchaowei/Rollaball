using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;int count;
    Rigidbody rb;
    float move_X;
    float move_Y;
    public TextMeshProUGUI Count_Text;
    public GameObject Win_Text_Object;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Count_Text.text = $"Count: {count}";
        Win_Text_Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 vec = new Vector3(move_X, 0, move_Y);
        rb.AddForce(vec *speed);
    }

    void OnMove(InputValue move_Value)
    {
        Vector2 move_Vec = move_Value.Get<Vector2>();
        move_X = move_Vec.x;
        move_Y = move_Vec.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count++;
            other.gameObject.SetActive(false);
            Count_Text.text = $"Count: {count}";
            if(count >= 4)
                Win_Text_Object.SetActive(true);
        }
    }
}
