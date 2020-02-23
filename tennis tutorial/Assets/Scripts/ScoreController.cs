using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreController : MonoBehaviour
{
    public int hitter;
    public int homeScore;
    public int awayScore;
    public TextMeshProUGUI homeText;
    public TextMeshProUGUI awayText;
    // Update is called once per frame
    public void changeScore(string Where)
    {
        if (Where == "Net")
        {
            if (hitter == 1)
            {
                awayScore ++;
                awayText.text = awayScore.ToString();
            }
            else if (hitter == 2)
            {
                homeScore ++;
                homeText.text = homeScore.ToString();
            }
            else
            {
                Debug.Log("Glitch, Shouldn't happen");
            }
        }
        else if(Where == "Wall")
        {
            if (hitter == 1)
            {
                homeScore ++;
                homeText.text = homeScore.ToString();
            }
            else if (hitter == 2)
            {
                awayScore ++;
                awayText.text = awayScore.ToString();
            }
            else
            {
                Debug.Log("Glitch, Shouldn't happen");
            }
        }
        
    }
    private void Update()
    {
        if (homeScore >= 12)
        {
            SceneManager.LoadScene("Win");
        }
        else if (awayScore >= 12)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
