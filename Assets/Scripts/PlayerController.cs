using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;
    CharacterController characterController;
    public float gravity = -10;

    public Transform groundCheck;
    public LayerMask GroundMask;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CheckGround();
    }

    void PlayerMove()
    {
       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
    private void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),
          out hit, 0.4f, GroundMask))
        {
            string TerrainType = hit.collider.gameObject.tag;

            switch(TerrainType)
            {
                default:
                    speed = 12;
                    break;
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
            }
                }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
            hit.gameObject.GetComponent<Pickup>().Picked();
    }

}
