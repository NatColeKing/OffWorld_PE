using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geyser : MonoBehaviour {

	public ParticleSystem Bubbles;
	public ParticleSystem MainColumn;

	public float minTimeActive = 1f;
	public float maxTimeActive = 5f;
	public float minTimeInactive = 5f;
	public float maxTimeInactive = 10f;
	public float bubbleLingerDuration = 1f;

	// Use this for initialization
	void Start ()
	{
		//MainColumn = GetComponentInChildren<geyser_ColumnController>().GetComponent<ParticleSystem>();
		//Bubbles = transform.Find("Bubbles").GetComponent<ParticleSystem>();
		Bubbles.Stop();
		DisableColumn();
	}

	void DisableColumn()
	{
			// Stop Column animation
			MainColumn.Stop();
			Invoke("DisableBubbles", bubbleLingerDuration);
	}

	void DisableBubbles()
	{
			// Stop bubble animation
			Bubbles.Stop();
			float delay = Random.Range(minTimeInactive, maxTimeInactive);
			Invoke("EnableBubbles", delay);
	}

	void EnableBubbles()
	{
			//Start bubble animation
			Bubbles.Play();
			Invoke("EnableColumn", bubbleLingerDuration);
	}

	void EnableColumn()
	{
			//Start geyser animation
			MainColumn.Play();
			float delay = Random.Range(minTimeActive, maxTimeActive);
			Invoke("DisableColumn", delay);
	}
}
