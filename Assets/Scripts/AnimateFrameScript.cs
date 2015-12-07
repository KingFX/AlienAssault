using UnityEngine;
using System.Collections;

public class AnimateFrameScript : MonoBehaviour {

    public GameObject[] models;
    public Sprite[] sprites;

    public float frameDelay;
    private float delay = 0;
    private bool modelAni;
    private int frame = 0;

    void Start() {
        if (models.Length > 0) {
            modelAni = true;
        } else {
            modelAni = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (delay <= 0) {
            frame++;
            //print("Frame: " + (frame - 1));
            GameObject model = null;
            for (int i = 0; i < models.Length; i++) {
                //print("i: " + i + " Frame: " + (frame - 1));
                //print("Current Model: " + models[i]);
                //print("Don't Disable: " + model);
                if (i == frame - 1) {
                    //print("Enabled: " + models[i]);
                    models[i].SetActive(true);
                    model = models[i];
                } else if (model != models[i]){
                    //print("Disabled: " + models[i]);
                    models[i].SetActive(false);
                }
            }
            if (frame > models.Length - 1) {
                frame = 0;
            }
            delay = frameDelay * Time.deltaTime;
        } else {
            delay -= Time.deltaTime;
        }
    }
}
