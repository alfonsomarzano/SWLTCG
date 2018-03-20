using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuilder : MonoBehaviour
{
    private CardConfiguration config;
    private GameObject cardPrefab;
	void Awake ()
	{
	    cardPrefab = Instantiate(cardPrefab);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
