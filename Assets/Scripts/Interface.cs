using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Interface : MonoBehaviour {



    public static Interface Gm;

    public Image[] UIImage;

    // Use this for initialization
    void Awake () {
        Screen.fullScreen = false;

        Gm = this;
    }
	
	// Update is called once per frame
	void Update () {

        KeyUPDownchange();


    }


    void InitColor()
    {

        for (int i = 0; i < UIImage.Length; i++)
        {
            UIImage[i].color = new Color(255, 255, 255);


        }

    }

    public void KeyUPDownchange()
    {
        // wsad
        if (Input.GetKeyUp(KeyCode.A))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Interface.Gm.UIImage[2].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Interface.Gm.UIImage[3].color = myColor;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Interface.Gm.UIImage[2].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Interface.Gm.UIImage[3].color = myColor;
        }

        ///
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Interface.Gm.UIImage[4].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Interface.Gm.UIImage[5].color = myColor;
        }

   


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Interface.Gm.UIImage[4].color = myColor;

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {



            Color myColor = new Color32(180, 180, 180, 255);

            Interface.Gm.UIImage[5].color = myColor;

        }

    

        if (Input.GetKeyDown(KeyCode.E))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Interface.Gm.UIImage[6].color = myColor;
        }


    
        if (Input.GetKeyUp(KeyCode.E))
        {

            Color myColor = new Color32(255, 255, 255, 255);

            Interface.Gm.UIImage[6].color = myColor;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Interface.Gm.UIImage[7].color = myColor;
        }



        if (Input.GetKeyUp(KeyCode.Space))
        {

            Color myColor = new Color32(255, 255, 255, 255);

            Interface.Gm.UIImage[7].color = myColor;
        }


    }

}
