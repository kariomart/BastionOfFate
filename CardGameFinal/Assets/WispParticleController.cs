using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispParticleController : MonoBehaviour {

	public float timeTakenDuringLerp = 10f;
	public float distanceToMove;	
	private bool _isLerping;
	public float speed = 5f;
	public Vector2 defaultPos = new Vector2(49.25f, -2.23f);
	public ParticleSystem particles;

	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private float _timeStartedLerping;
	Transform boop;


	public void StartLerping(Vector2 destination)
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;

		_startPosition = transform.position;
		_endPosition = destination;
		//boop = destination;
	}


	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		
		if(_isLerping)
		{
			//_endPosition = boop.position;
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;


			transform.position = Vector3.Lerp (_startPosition, _endPosition, speed * percentageComplete);

			//When we've completed the lerp, we set _isLerping to false
			if(percentageComplete == 0.99f)
				Global.me.DoStuffAfterParticleLands ();

			
			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
				particles.Stop ();
				transform.position = defaultPos;
			}
		}
	}
		
}
