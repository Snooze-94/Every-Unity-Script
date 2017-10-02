using UnityEngine;
using System.Collections;

public class CrouchTrigger : MonoBehaviour {

	private static int amountOfCols;

	void Start(){
		amountOfCols = 0;
	}

	void OnTriggerEnter(Collider col){
		--amountOfCols;
	}

	void OnTriggerExit(Collider col){
		++amountOfCols;
	}

	public static bool isEmpty(){
		return amountOfCols == 0;
	}


}
