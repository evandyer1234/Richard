using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canon : MonoBehaviour
{
    public Animator anim;
    public float launchTime = 5f;
    bool launching = false;
    public Flying flying;
    public GameObject LaunchPoint;
    public float EndTime = 2f;
    bool ending = false;
    public GameObject cap;
    bool shot = false;
    public GameObject Player;
    public AudioClip canonboom;
    public AudioSource source;
    public float hitVol = 5f;
    bool animating = false;
    float animTime = 0.6f;
    public int NextScene = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        cap.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (launching)
        {
            launchTime -= Time.fixedDeltaTime;
        }
        if (launchTime <= 0 && !shot)
        {
            Launch();
            ending = true;
            shot = true;
        }
        if (ending)
        {
            EndTime -= Time.fixedDeltaTime;
        }
        if (EndTime <= 0)
        {
            LevelEnd();
        }
        if (animating)
        {
            animTime -= Time.fixedDeltaTime;
        }
        if (animTime <= 0)
        {
            animating = false;
            anim.SetBool("fire", false);
        }
    }
    public void Launch()
    {
        anim.SetBool("fire", true);
        animating = true;
        source.PlayOneShot(canonboom, hitVol);
        Flying clone = (Flying)Instantiate(flying, LaunchPoint.transform.position, LaunchPoint.transform.rotation);
    }
    public void StartLaunch()
    {
        cap.SetActive(true);
        launching = true;
        Player.SetActive(false);
       
    }
    public void LevelEnd()
    {
        SceneManager.LoadScene(NextScene);
    }
}
