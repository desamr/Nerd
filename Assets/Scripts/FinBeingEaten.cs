using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinBeingEaten : MonoBehaviour {

	private Sprite EmptySprite;

	public void GotoContabiliza(){
		//GameController.NerdSpriteRenderer.sprite = EmptySprite;
		GameController.status = 1;
		GameController.Contabiliza ();
	}
}
