using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour{
    GameObject player;
    public Camera FPScamera;
    public Camera TPScamera;
    bool mainCamera = true; // main camera = third person camera

    // Start is called before the first frame update
    void Start(){
        FPScamera.enabled = !mainCamera;
        TPScamera.enabled = mainCamera;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.RightShift)){
            mainCamera = !mainCamera;
            FPScamera.enabled = !mainCamera;
            TPScamera.enabled = mainCamera;

            if(FPScamera.enabled == true){
                Debug.Log("First Person Camera is on!");
            }else{
                Debug.Log("Third Person Camera is on!");
            }
        }
    }


}
