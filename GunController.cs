using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {


	public Transform weaponHold;
	public Transform player;
	public Gun startingGun;
	Gun equippedGun;

	void Start(){
		if (startingGun != null) {
			EquipGun(startingGun);
		}
	}

	public void EquipGun(Gun gunToEquip){
		if (equippedGun != null) {
			Destroy(equippedGun.gameObject);
		}

		equippedGun = Instantiate (gunToEquip, weaponHold.position,weaponHold.rotation) as Gun;
		equippedGun.transform.parent = weaponHold;
	}

	public void TrowGun(){
		Destroy (equippedGun.gameObject);
	}

}
