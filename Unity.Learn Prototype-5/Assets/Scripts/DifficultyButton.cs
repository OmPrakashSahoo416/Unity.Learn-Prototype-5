using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManagerScript;
    public float difficultyParameter;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        gameManagerScript.StartGame(difficultyParameter);
    }
}
