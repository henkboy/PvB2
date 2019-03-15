using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour {

    public bool Lvl1Complete = false;
    public bool Lvl2Complete = false;
    public GameObject Boss;
    public GameObject Player;
    public int Range;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Lvl1Complete == true && Lvl2Complete == true && Boss.activeInHierarchy == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Player.transform.position - transform.position, out hit, Range))
            {
                Boss.SetActive(true);
                Player.transform.position = new Vector3(-1, 0.6f, 18);
                Player.GetComponent<Player>().CurrentLevel = 3;
            }
        }
    }
}
