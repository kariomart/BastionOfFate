using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public PanelController panel;
	public GameStateController gamestate;
	public GameObject canvasHand;
	public float originalX = 0;
	public float originalY = 0;


	public void Start() {
		panel = Global.me.battlefieldPanel;
	}

	public void OnBeginDrag(PointerEventData eventData) {
		originalX = transform.position.x;
		originalY = transform.position.y;
		Debug.Log (originalX + " " + originalY);

	}

	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("OnDrag");
		this.transform.position = eventData.position;
		if (panel.MouseOver) {
			Debug.Log ("Dropped on Battlefield");
			transform.SetParent (panel.transform, false);
		}

	}

	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log ("OnEndDrag");
		// transform.SetParent ();
		if (panel.MouseOver) {
			Debug.Log ("Dropped on Battlefield");
			transform.SetParent (panel.transform, false);

		} else {

			transform.position = new Vector3 (originalX, originalY, 0);
		}



		}
	}







