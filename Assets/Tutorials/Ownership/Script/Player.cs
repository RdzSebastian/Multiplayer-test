using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    //[SerializeField] private Vector3 movement = new Vector3();
    [SerializeField] public float horizontalMove;
    [SerializeField] public float verticalMove;
    [SerializeField] public CharacterController player;

    [Client]
    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    [Client]
    private void Update()
    {

        if(!hasAuthority) { return; }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        player.Move(new Vector3(horizontalMove, 0, verticalMove));

        //if(!Input.GetKeyDown(KeyCode.Space)) { return; }

        //transform.Translate(movement);
    }
}
