using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int time_mins { get => (int)Mathf.Floor(m_time/60.0f); }
    public int time_seconds { get => (int)Mathf.Floor(m_time - (m_time / 60.0f)); }

    public TMP_Text score_display;
    public TMP_Text time_display;


    void Start()
    {
        Debug.Assert(score_display, "No TMP text to display Score");
        Debug.Assert(time_display, "No TMP text to display Time");
        m_time = 0;
        score = 0;
    }

    void Update()
    {
        m_time += Time.deltaTime;

        if (time_display)
        {
            string mins = time_mins.ToString();
            string seconds = time_seconds.ToString();
            if (seconds.Length == 1) { seconds = "0" + seconds; }
            time_display.text = mins + ":" + seconds;
        }
    }

    public void AddScore(int damage)
    {
        score += damage;
        if (score_display) { score_display.text = score.ToString(); }
    }

    private float m_time;
}
