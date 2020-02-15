using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    private int score = 0;
    private bool isPlayerWin = false;
    public int winningScore = 500;
    public Text scoreText;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(isPlayerWin)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction*hit.distance, Color.green, 0.5f);

                if (!hit.transform.GetComponent<Mole>().IsDead)
                {
                    score += 100;
                }
                
                hit.transform.GetComponent<Mole>().Dead();
                Debug.Log(message:$"Current score {score}");
                if (score == winningScore)
                {
                    isPlayerWin = true;
                    Debug.Log(message: "End");
                    StartCoroutine(("SetWinningStage"));
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction*100, Color.red, 0.5f);
            }
            
        }

        scoreText.text = $"SCORE: {score}";
    }

    IEnumerator SetWinningStage()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("WinningScene");
    }
    
}
