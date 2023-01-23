using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundResultUI : MonoBehaviour {
    private TMP_Text    txt;

    private void Awake() {
        txt = GetComponent<TMP_Text>();
        txt.text = "";
    }

    private void Update() {
        if (Bartok.S.phase != TurnPhase.gameOver) {
            txt.text = "";
            return;
        }
        Player cP = Bartok.CURRENT_PLAYER;
        if (cP == null || cP.type == PlayerType.human) {
            txt.text = "";
        } else {
            txt.text = "Player " + cP.playerNum + " won";
        }
    }
}
