using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin_Script : MonoBehaviour {

    //private int coin_Count;
    [SerializeField]
    private ParticleSystem coin_Particles;
    [SerializeField]
    private GameObject door;

    public GameObject player;
    public Player_Script _playerScript;
    private Animator door_Animation;

    private bool all_coins;

    // Start is called before the first frame update
    void Start() {
        //coin_Count = 0;
        //all_coins = false;

        door_Animation = door.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        _playerScript = player.GetComponent<Player_Script>();
    }

    // Update is called once per frame
    void FixedUpdate() {
       
    }

    // Checks for colliders 
    private void OnTriggerEnter(Collider col) {

        //Collects coins
        if (col.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
            coin_Particles.gameObject.SetActive(true);
            _playerScript.coin_Count++;
            _playerScript.coin_text.text = "Coins: " + _playerScript.coin_Count.ToString();
            if (_playerScript.coin_Count >= 7) {
                //all_coins = true;
                door_Animation.SetBool("open_Door", true);

            }
        }
    }



}