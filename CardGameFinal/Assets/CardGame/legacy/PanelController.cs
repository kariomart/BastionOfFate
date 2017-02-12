using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PanelController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


	public GameStateController GameState;
	public bool MouseOver; 

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log ("MOUSE OVER PANEL");
		MouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log ("MOUSE LEFT PANEL");
		MouseOver = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
