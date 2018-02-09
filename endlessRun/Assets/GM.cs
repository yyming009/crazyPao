using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public float zScenePos = 56;

    public static float zVelAdj = 1;

    public static string lvlCompStatus = "";

    public Transform bbNoPit;
    public Transform bbPitMid;

    public Transform coinObj;
    public Transform obstObj;
    public Transform capsuleObj;

    public int randNum;

	// Use this for initialization
	void Start () {
        Instantiate(bbNoPit, new Vector3(0, 2.25f, 40), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 2.25f, 44), bbNoPit.rotation);
        Instantiate(bbPitMid, new Vector3(0, 2.25f, 48), bbPitMid.rotation);
        Instantiate(bbPitMid, new Vector3(0, 2.25f, 52), bbPitMid.rotation);

       

    }

    // Update is called once per frame
    void Update () {

        if (zScenePos < 120)
        {
            randNum = Random.Range(0, 10);

            //coin set up
            if (randNum < 3)
            {
                Instantiate(coinObj, new Vector3(-1, 3.25f, zScenePos), coinObj.rotation);
            }

            if (randNum > 7)
            {
                Instantiate(coinObj, new Vector3(1, 3.25f, zScenePos), coinObj.rotation);
            }

            //abst set up
            if (randNum == 4)
            {
                Instantiate(obstObj, new Vector3(1, 3.25f, zScenePos), obstObj.rotation);
            }

            if (randNum == 5)
            {
                Instantiate(obstObj, new Vector3(0, 3.25f, zScenePos), obstObj.rotation);
            }

            //pit set up
            Instantiate(bbNoPit, new Vector3(0, 2.25f, zScenePos), bbNoPit.rotation);
            zScenePos += 4;
        }

        timeTotal += Time.deltaTime;

        if (lvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;
        }

        if (waittoload > 2)
        {
            SceneManager.LoadScene("levelComp");
        }
	}
}
