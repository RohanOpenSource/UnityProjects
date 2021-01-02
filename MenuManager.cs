using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public InputField PlayerName;
    public Button PlayButton;
    void Start()
    {

    }
    void Update(){
      if(Input.GetKeyDown("p")){
        Play();
      }
    }



    public void Play(){
      SceneManager.LoadScene(1);

    }

}
