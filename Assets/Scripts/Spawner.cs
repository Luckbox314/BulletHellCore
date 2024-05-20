using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject wave_intro_prefab;

    [Header("Spawns")]
    public List<Wave> waves;
    public List<Transform> spawn_points;

    public int wave_index;
    public Wave current_wave;
    private GameObject waveDisplay;

    private void Start()
    {
        Debug.Assert(waves.Count > 0);
        Debug.Log("Wave: " + wave_index);
        WaveIntro(wave_index);
        current_wave = Instantiate(waves[wave_index++]);
        current_wave.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_wave == null)
        {
            Debug.Assert(false, "Level has waves!");
            return;
        }

        current_wave.OnFrameTick(Time.deltaTime);

        if (current_wave.IsComplete)
        {
            if (wave_index < waves.Count)
            {
                Debug.Log("Wave: " + wave_index);
                WaveIntro(wave_index);
                current_wave = GameObject.Instantiate(waves[wave_index++]);
                current_wave.Init(this);
            }
            else
            {
                // TODO: Next level / Game over
                GameManager.Instance.Win();

                Debug.Log("Level Complete");
                Destroy(this);
            }
        }
    }

    void WaveIntro(int index)
    {
        TMP_Text waveText;
        index++;

        GameObject wave_intro = Instantiate(wave_intro_prefab, GameManager.Instance.GetPlayerHud().transform);
        Debug.Assert(GameManager.Instance.GetPlayerHud().transform, "No HUD");
        Debug.Assert(wave_intro, "no instance of wave_intro");
        waveText = wave_intro.GetComponentInChildren<TMP_Text>();
        Debug.Assert(waveText, "Route not found TMP Text");
        Debug.Log("Wave " + index );
        waveText.text = "Wave " + index;
    }
}


