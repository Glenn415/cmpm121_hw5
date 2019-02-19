using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour{
    [SerializeField]
    private float walk_speed;
    [SerializeField]
    private float rotate_speed;
    [SerializeField]
    private float jump_force;
    [SerializeField]
    private Animator player_animator;
    [SerializeField]
    private Rigidbody player_rb;

    private bool is_grounded;
    public int coin_Count;
    public Text coin_text;
    public Text start_Text;
    private bool display_Text;


    //
    private void Start(){
        coin_Count = 0;
        display_Text = true;
        player_rb = GetComponent<Rigidbody>();

        coin_text.text = "Coins: " + coin_Count.ToString();
    }

    //
    private void Update(){
        Initial_Text();
        Player_Movement();
        Player_Jump();
        Camera_Rotation();

        player_animator.SetBool("Grounded", is_grounded);

    }

    private void Initial_Text() {
        if (display_Text == true) {
            start_Text.text = "Can you escape from this world?";
        } else {
            start_Text.text = "";
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            display_Text = false;
        }
    }

    //
    private void Player_Movement(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //player_rb.AddForce(movement * walk_speed);
        player_rb.AddForce(Camera.main.transform.TransformDirection(movement) * walk_speed);
        player_animator.SetFloat("MoveSpeed", movement.magnitude);

    }

    private void Player_Jump() {
        // Player Jump
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded) {
            //Debug.Log("Player Jump");
            //is_grounded = false;
            player_rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        } else if (!is_grounded) {
            player_rb.AddForce(Vector3.down * jump_force, ForceMode.Force);
        }

        if (is_grounded == false) {
            player_animator.SetTrigger("Jump");
        } 

        if (is_grounded == true) {
            player_animator.SetTrigger("Land");
        }
    }

    private void Camera_Rotation() {
        // Camera rotation control
        if (Input.GetKey(KeyCode.LeftArrow)) {
            //Debug.Log("turn camera left");
            transform.Rotate(0, -rotate_speed * Time.deltaTime, 0);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            //Debug.Log("turn camera right");
            transform.Rotate(0, rotate_speed * Time.deltaTime, 0);
        }
    }

    //
    private void OnCollisionStay(Collision col) {
        if (col.gameObject.CompareTag("Floor")) {
            is_grounded = true;
            //Debug.Log("Colliding with floor: " + is_grounded);
        }
    }

    private void OnCollisionExit(Collision col) {
        if (col.gameObject.CompareTag("Floor")) {
            is_grounded = false;
            //Debug.Log("Colliding with floor: " + is_grounded);
        }
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Floor")) {
            is_grounded = true;
            //Debug.Log("Colliding with floor: " + is_grounded);
        }
    }

    private void OnTriggerEnter(Collider col) {
        // Restarts the game
        if (col.gameObject.CompareTag("Respawn")) {
            //col.gameObject.SetActive(false);
            //Debug.Log("restart game");
            SceneManager.LoadScene(1);
        }
    }


}
