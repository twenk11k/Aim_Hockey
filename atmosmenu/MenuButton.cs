using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButton : MonoBehaviour
{
    //[SerializeField] AnimatorFunctions animatorFunctions;
    Animator animator;
    [SerializeField] int thisIndex;
    [SerializeField] AudioClip audioClip;
    // Update is called once per frame

    private void Start()
    {
        animator = GetComponent<Animator>();
        OpenFirst();
    }

    private void OpenFirst()
    {
        animator.SetTrigger("openFirst");
      //  animator.SetBool("selected", true);

    }

    public void TriggerAnimation()
    {
        //  animator.SetBool("selected",true);
        PlaySound();

    }

    public void SetDeselect()
    {
        animator.SetTrigger("Normal");

    }
    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 0.7f);
    }

    public void Open1Player()
    {
        PlaySound();
        TriggerAnimation();
        SceneManager.LoadScene("SoloGame");
    }
    public void Open2Players()
    {
        PlaySound();
        TriggerAnimation();
        SceneManager.LoadScene("MultiGame");
    }
}
