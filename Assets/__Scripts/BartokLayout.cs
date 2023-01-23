using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class JSONHand {
    public int          player;
    public float        x;
    public float        y;
    public float        rot;
    public int          layer = 0;

}
[System.Serializable]
public class JSONPileTarget {
    
    public float        x;
    public float        y;
    public int          layer = 0;
    public float        xStagger = .05f;
}
[System.Serializable]
public class JSONReader {
    public JSONMultiplier   multiplier;
    public JSONHand[]       hand;
    public JSONPileTarget   drawPile;
    public JSONPileTarget   discardPile;
    public JSONPileTarget   target;
}

[System.Serializable]
public class SlotDef {
    public float        x;
    public float        y;
    public bool         faceUp = false;
    public string       layerName = "Default";
    public int          layerID = 0;
    public int          id;
    public List<int>    hiddenBy = new List<int>();
    public float        rot;
    public string       type = "slot";
    public Vector2      stagger;
    public int          player;
    public Vector3      pos;
}

public class BartokLayout : MonoBehaviour {
    [Header("Set Dynamically")]
    public JSONReader       jsonr;
    public Vector2          multiplier;
    public List<SlotDef>    slotDefs;
    public SlotDef          drawPile;
    public SlotDef          discardPile;
    public SlotDef          target;

    public void ReadLayout(string jsonText) {
        jsonr = JsonUtility.FromJson<JSONReader>(jsonText);

        multiplier.x = jsonr.multiplier.x;
        multiplier.y = jsonr.multiplier.y;

        slotDefs = new List<SlotDef>();
        SlotDef tSD;
        foreach (JSONHand hand in jsonr.hand) {
            tSD = new SlotDef() {x = hand.x,
                                 y = hand.y,
                                 pos = new Vector3(hand.x * multiplier.x,
                                                   hand.y * multiplier.y,
                                                   0),
                                 layerID = hand.layer,
                                 layerName = hand.layer.ToString(),
                                 player = hand.player,
                                 rot = hand.rot,
                                 type = "hand" };
            slotDefs.Add(tSD);
        }

        drawPile = new SlotDef() {x = jsonr.drawPile.x,
                                  y = jsonr.drawPile.y,
                                  pos = new Vector3(jsonr.drawPile.x * multiplier.x,
                                                    jsonr.drawPile.y * multiplier.y,
                                                    0),
                                  layerID = jsonr.drawPile.layer,
                                  layerName = jsonr.drawPile.layer.ToString(),
                                  stagger = new Vector2(jsonr.drawPile.xStagger,
                                                        0),
                                  type = "drawpile" };
        
        discardPile = new SlotDef() {x = jsonr.discardPile.x,
                                     y = jsonr.discardPile.y,
                                     pos = new Vector3(jsonr.discardPile.x * multiplier.x,
                                                       jsonr.discardPile.y * multiplier.y,
                                                       0),
                                     layerID = jsonr.discardPile.layer,
                                     layerName = jsonr.discardPile.layer.ToString(),
                                     type = "discardpile" };
        
        target = new SlotDef() {x = jsonr.target.x,
                                y = jsonr.target.y,
                                pos = new Vector3(jsonr.target.x * multiplier.x,
                                                  jsonr.target.y * multiplier.y,
                                                  0),
                                layerID = jsonr.target.layer,
                                layerName = jsonr.target.layer.ToString(),
                                type = "target" };
    }
}
