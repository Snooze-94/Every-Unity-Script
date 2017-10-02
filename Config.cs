using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config {



  /*
   * 
   * SERVER SETTINGS
   * 
  */



  public static int SERVERTICKRATE = 60;



  /*
   * 
   * WEAPONS
   * 
  */
  
    
  public static List<Weapon> Weapons = new List<Weapon>();
  
  public static Weapon Glock = new Weapon("Glock", 15, 0.1f, 1f, 0.1f, 0.01f);


  

  /*
   * 
   * STRUCTS
   * 
  */

  public struct Weapon{
    public int magazineSize;
    public float shootDelay;
    public float focusTime;
    public float maxSpread;
    public float minSpread;
    public string name;

    public Weapon(string name, int mag, float shoot, float focus, float maxS, float minS)
    {
      this.name = name;
      magazineSize = mag;
      shootDelay = shoot;
      focusTime = focus;
      maxSpread = maxS;
      minSpread = minS;

      Weapons.Add(this);
    }

    

  }
	
}
