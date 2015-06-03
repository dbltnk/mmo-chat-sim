using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticipantHandler : MonoBehaviour {

	public int ChatParticipantsToCreate;
	public GameObject ParticipantBlueprint;
	public GameObject PlayerRoot;

	public float minTimeOutInSeconds;
	public float maxTimeOutInSeconds;

	// Use this for initialization
	void Start () 
	{
		createParticipants(ChatParticipantsToCreate);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void createParticipants (int amount)
	{
		for (int i = 0; i < amount; i++) 
		{
			GameObject participantObject = (GameObject)Instantiate(ParticipantBlueprint);
			participantObject.transform.SetParent(PlayerRoot.transform);
		}
	}
}

