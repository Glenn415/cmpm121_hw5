using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour {

    // Goes to "Game" when called
    // 0: Game
    // 1: GameMenu
    public void PlayGame() {
        SceneManager.LoadScene(0);
    }
}
