using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorb : MonoBehaviour {

    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controllocked = "n";

    public Transform boomObj;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, 4);

        if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && (controllocked == "n"))
        {
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controllocked = "y";
        }

        if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && (controllocked == "n"))
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controllocked = "y";

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.lvlCompStatus = "Fail";
        }

        if (other.gameObject.name == "Capsule(Clone)")
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "rampbottomtrig")
        {
            GM.vertVel = 1.5f;
        }

        if (other.gameObject.name == "ramptoptrig")
        {
            GM.vertVel = 0;
        }

        if (other.gameObject.name == "exit")
        {
            GM.lvlCompStatus = "Success !!!";
            SceneManager.LoadScene("levelComp");
        }

        if (other.gameObject.name == "coin(Clone)")
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controllocked = "n";
    }
}
