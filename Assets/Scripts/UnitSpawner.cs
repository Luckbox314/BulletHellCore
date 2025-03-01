using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    float spawn_interval = 0.0f;

    [SerializeField]
    float spawn_radius = 0.0f;

    [SerializeField]
    int max_units = 1;

    [SerializeField]
    List<GameObject> units;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(units.Count > 0);
        time_elapsed = spawn_interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (max_units <= 0)
        {
            return;
        }

        time_elapsed += Time.deltaTime;
        if (time_elapsed > spawn_interval)
        {
            int unit_index = Random.Range(0, units.Count);
            Vector3 location = transform.position + new Vector3(Random.Range(5, spawn_radius), 0, Random.Range(5, spawn_radius));
            Instantiate(units[unit_index], location, Quaternion.identity, GetComponentInParent<Room>().transform);
            time_elapsed = 0.0f;
            max_units--; 
        }
    }

    private float time_elapsed = 0.0f;
}

