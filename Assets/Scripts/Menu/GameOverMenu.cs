using Cinemachine;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameOverMenu : Menu
{
    [Header("Layout")]
    [SerializeField]
    public CinemachineVirtualCamera virtual_camera;
    private ScoreManager score_manager;

    protected override void OnActivate()
    {
        Debug.Log("GameOverMenu");
        GameManager.Instance.IndefinedStop();
        GameManager.Instance.GetPlayerHud().gameObject.SetActive(false);


        score_manager = FindObjectOfType<ScoreManager>();

        Debug.Assert(virtual_camera != null, "No camera selected");
        Debug.Assert(score_manager != null, "No ScoreManager found");

        TMP_Text mainTitle = transform.Find("Title").gameObject.GetComponent<TMP_Text>();
        Debug.Assert(mainTitle, "scoreDisplay not found");
        if (GameManager.Instance.game_won) { mainTitle.text = "Level Completed!"; }
        else { mainTitle.text = "You Died."; }

        DisplayScore();

        //virtual_camera.m_Lens.OrthographicSize = 2.5f;  
        //virtual_camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0.0f, 1.5f, -10.0f);

        if (GameManager.Instance.GetPlayer() == null)
        {
            return;
        }
    }

    protected override void OnDeactivate()
    {
        GameManager.Instance.GetPlayerHud().gameObject.SetActive(true);
        GameManager.Instance.GameOver();

        //virtual_camera.m_Lens.OrthographicSize = m_default_orthographic_size;
        //virtual_camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0.0f, 1.5f, -10.0f);
    }

    void DisplayScore()
    {
        // get TMP to display
        TMP_Text scoreDisplay  = transform.Find("TotalScore/Score").gameObject.GetComponent<TMP_Text>();

        TMP_Text timeDisplay = transform.Find("TotalTime/Time").gameObject.GetComponent<TMP_Text>();

        scoreDisplay.text = ((int)score_manager.score).ToString();
        string mins = score_manager.time_mins.ToString();
        string seconds = score_manager.time_seconds.ToString();
        if (seconds.Length == 1) { seconds = "0" + seconds; }
        timeDisplay.text = mins + ":" + seconds;
    }

    private Vector3 m_default_offset;
    private float m_default_orthographic_size;
}
