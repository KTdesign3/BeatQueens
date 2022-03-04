using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    public float PlayerJumpSpeed = 12;
    public bool OnFloor;
    public Rigidbody PlayerRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Jump()
    {
        Debug.Log("Character jumped using player input script");
        PlayerRB.velocity = Vector2.up * PlayerJumpSpeed; //Makes player jump
    }
}
