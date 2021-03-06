using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    private TextMeshProUGUI playerOne;
    //private TextMeshProUGUI playerPoint;
    public HealthBar hp;


    
    private void Start()
    {
         playerOne = GameObject.Find("PlayerStats").GetComponent<TextMeshProUGUI>();
        // playerPoint = GameObject.Find("PlayerStats").GetComponent<TextMeshProUGUI>();
       // playerOne = GameObject.FindWithTag("Player").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        

        GameObject playerObject = GameObject.FindWithTag("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        hp.setMaxHealth(100);

    }
    void Update()
    {
        if(GameObject.FindWithTag("Player") != null){ 
        GameObject playerObject = GameObject.FindWithTag("Player");//GameObject.Find("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();

            float set = playerController.Health / playerController.MaxHealth;

            hp.setHealth(set);

            playerOne.text = "<br><br>Player points: " + playerController.Points;
            
            //"Player health: " 
            //  + playerController.Health.ToString() + "/"
            // + playerController.MaxHealth.ToString() + "<br>Player points: " + playerController.Points;
        }
    }   
    
}
