using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {


	public PanelController Panel;
	public GameObject PanelView;
	public GameStateController Gamestate;
	public GameObject CanvasHand;
	public float originalX = 0;
	public float originalY = 0;




	public void OnBeginDrag(PointerEventData eventData) {
		originalX = transform.position.x;
		originalY = transform.position.y;
		Debug.Log (originalX + " " + originalY);

	}

	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("OnDrag");
		this.transform.position = eventData.position;
		if (Panel.MouseOver) {
			Debug.Log ("Dropped on Battlefield");
			transform.SetParent (PanelView.transform, false);
		}

	}

	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log ("OnEndDrag");
		// transform.SetParent ();
		if (Panel.MouseOver) {
			Debug.Log ("Dropped on Battlefield");
			transform.SetParent (PanelView.transform, false);

		} else {

			transform.position = new Vector3 (originalX, originalY, 0);
		}



		}
	}







