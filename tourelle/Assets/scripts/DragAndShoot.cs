using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]


public class DragAndShoot : MonoBehaviour
{
    public float forceMultiplier = 2;
    // [SerializeField] DynamicJoystick joystick;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    public bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Debug.Log("Distance: " + Vector2.Distance(mousePressDownPos, mouseReleasePos));
        if (Vector2.Distance(mousePressDownPos, mouseReleasePos ) < 30)
        {
            return;
        }

        Shoot((mousePressDownPos - mouseReleasePos).normalized);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Vector3 direction = (mousePressDownPos - Input.mousePosition).normalized;

            transform.forward = new Vector3(direction.x, 0, direction.y);
        }




    }

    void Shoot(Vector3 direction)
    {
        if (isShoot)
            return;

        rb.AddForce(new Vector3(direction.x, direction.y, direction.y) * forceMultiplier);
        isShoot = true;

        transform.forward = new Vector3(direction.x, 0, direction.y);
        Destroy(gameObject, 0.5f);

        FindObjectOfType<GameManager>().SpawnArrow();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        
    }

}




