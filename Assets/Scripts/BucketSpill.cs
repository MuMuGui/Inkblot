using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BucketSpill : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject PaintAmmo;
    Animator anim;
    bool spillonce;
    PlayerController BossCount;
    bool allFlip = true;
    IEnumerator Countdown()
    {

        yield return new WaitForSeconds(10);
        if (allFlip == true)
        {
            Respawn();
            if (SceneManager.GetActiveScene().name == "BossLevel")
            {
                allFlip = false;
            }
        }


    }
    void Start()
    {
        anim = GetComponent<Animator>();
        spillonce = false;
        anim.SetBool("Turn", false);
        //StartCoroutine(Respawn());
        BossCount = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (SceneManager.GetActiveScene().name != "BossLevel")
        {
            allFlip = true;
        }
        else if (SceneManager.GetActiveScene().name == "BossLevel")
        {
            allFlip = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (BossCount.allTurned == true)
        {
            allFlip = true;
        }
    }
    public void Spill()
    {
        if (spillonce == false)
        {
            GameObject.Find("PlayerAudio").GetComponent<PlayerAudio>().Dump();
            GameObject goodBlob = Instantiate(PaintAmmo) as GameObject;
            goodBlob.transform.position = transform.position;
            // transform.eulerAngles = new Vector3(0, 0, 90);
            anim.SetBool("Turn", true);
            //GetComponent<Animator>().Play("OragneFlip", -1, 0f);
            //anim.SetBool("Turn", false);
            StartCoroutine(Countdown());

        }
        spillonce = true;

    }
    void Respawn()
    {
        anim.SetBool("Turn", false);
        spillonce = false;
    }
}
