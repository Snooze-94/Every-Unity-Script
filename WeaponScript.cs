using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

  public enum Weapon { Glock = 0, M1911 = 1};
  public Weapon whichWeapon; 

  Animator anim;
  AudioSource audi;
  LineRenderer lineRenderer;

  public bool pointing;
  public bool hasMag;
  public float shootRNG;

  private int bullets;
  private int maxBullets;
  private float minSpread;
  private bool wasntPointing;
  private float maxSpread;
  private float currentSpread;
  
  public Config.Weapon construct;
  public GameObject casingPrefab;
  public GameObject MuzzleFlash;
  public Transform shootPosition;
  public GameObject player;
  public GameObject markerPrefab;
  public NetworkScript network;
  public LineRenderer laser;

  float elapsed = 0f;

  private void Start()
  {
    maxBullets = Config.Weapons[(int)whichWeapon].magazineSize;
    construct = Config.Weapons[(int)whichWeapon];
    anim = GetComponent<Animator>();
    audi = GetComponent<AudioSource>();
    lineRenderer = GetComponent<LineRenderer>();
    currentSpread = construct.maxSpread;

    if (hasMag)
    {
      Reload();
    }
  }

  

  void Update()
  {

    if (pointing)
    {
      if (wasntPointing) currentSpread = construct.maxSpread;
      currentSpread -= construct.maxSpread * (construct.focusTime * Time.deltaTime);
      currentSpread = Mathf.Clamp(currentSpread, construct.minSpread, construct.maxSpread);
      print(currentSpread);

      laser.enabled = true;

      laser.SetPosition(0, shootPosition.position);
      

      RaycastHit hit;
      if (Physics.Raycast(shootPosition.position, transform.forward, out hit, 100))
      {
        laser.SetPosition(1, hit.point);
        player.GetComponent<Player>().hudControl.SetChrosshairPosition(hit.point, hit.distance);
      }
      else
      {
        laser.SetPosition(1, shootPosition.position + transform.forward * 100f);
      }

      

      wasntPointing = false;
    }
    else
    {
      laser.enabled = false;
      wasntPointing = true;
    }


    if (MuzzleFlash.activeSelf)
    {
      elapsed += Time.deltaTime;
      if (elapsed > .03f)
      {
        MuzzleFlash.SetActive(false);
        elapsed = 0f;
        lineRenderer.enabled = false;
      }
    }
  }

  public void Reload()
  {
    bullets = maxBullets;
    anim.SetBool("HasBullet", true);
    currentSpread = construct.maxSpread;
    string path = construct.name + "Cock" + Mathf.RoundToInt(Random.Range(1f, 1f)).ToString();
    AudioClip cock = (AudioClip)Resources.Load(path, typeof(AudioClip));
    audi.PlayOneShot(cock, 1f);
  }

  public void Shoot()
  {

    if (bullets <= 0)
    {
      string patha = construct.name + "Cock" + Mathf.RoundToInt(Random.Range(1f, 1f)).ToString();
      AudioClip cock = (AudioClip)Resources.Load(patha, typeof(AudioClip));
      audi.PlayOneShot(cock, 1f);
      return;
    }
    bullets--;
    Vector3 fwd = transform.forward;
    //fwd += new Vector3(Random.Range(-shootRNG, shootRNG), Random.Range(-shootRNG, shootRNG), Random.Range(-shootRNG, shootRNG));
    fwd += transform.right * Random.Range(-currentSpread, currentSpread);
    fwd += transform.up * Random.Range(-currentSpread, currentSpread);
    RaycastHit hit;
    //print(fwd);

    currentSpread += construct.maxSpread * (construct.focusTime / 2);
    MuzzleFlash.SetActive(true);
    anim.SetTrigger("Shoot");
    string pathb = construct.name + Mathf.RoundToInt(Random.Range(1f, 8f)).ToString();
    //AudioClip shot = (AudioClip) AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
    AudioClip shot = (AudioClip)Resources.Load(pathb, typeof(AudioClip));
    audi.PlayOneShot(shot,1f);
    GameObject casing = Instantiate(casingPrefab, transform.position + new Vector3(-0.1f, 0.2f, 0f), transform.rotation * Quaternion.Euler(Vector3.right));
    casing.GetComponent<Rigidbody>().velocity = (transform.right * Random.Range(1f,4f)) + (transform.forward * Random.Range(-0f, -2f));

    lineRenderer.enabled = true;
    lineRenderer.SetPosition(0, shootPosition.position);

    

    if (Physics.Raycast(shootPosition.position, fwd, out hit, 100))
    {
      Instantiate(markerPrefab, hit.point, transform.rotation);
      lineRenderer.SetPosition(1, hit.point);
      //Debug.DrawRay(shootPosition.position, transform.forward * hit.distance, Color.red);
      network.SendShot(shootPosition.position, hit.point);
    }
    else
    {
      lineRenderer.SetPosition(1, shootPosition.position + transform.forward * 100f);
      network.SendShot(shootPosition.position, shootPosition.position + transform.forward * 100f);
    }

    if (bullets <= 0) anim.SetBool("HasBullet", false);

    

  }

  public void NetworkShoot(Vector3 shotOrigin, Vector3 shotDest)
  {
    MuzzleFlash.SetActive(true);
    anim.SetTrigger("Shoot");
    string path = construct.name + Mathf.RoundToInt(Random.Range(1f, 8f)).ToString();
    //AudioClip shot = (AudioClip) AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
    AudioClip shot = (AudioClip)Resources.Load(path, typeof(AudioClip));
    audi.PlayOneShot(shot, 1f);
    GameObject casing = Instantiate(casingPrefab, transform.position + new Vector3(-0.1f, 0.2f, 0f), transform.rotation * Quaternion.Euler(Vector3.right));
    casing.GetComponent<Rigidbody>().velocity = (transform.right * Random.Range(1f, 4f)) + (transform.forward * Random.Range(-0f, -2f));

    lineRenderer.enabled = true;
    lineRenderer.SetPosition(0, shotOrigin);
    lineRenderer.SetPosition(1, shotDest);

    Instantiate(markerPrefab, shotDest, transform.rotation);
    
  }
}
