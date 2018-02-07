using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Gun : MonoBehaviour {
	// Is gun automatic ?
	public bool automatic;

	private bool canShoot = true;

    // Where the projectile should be shoot from
    public Transform gunEnd;

    private Camera fpsCam;

    // Gun basic informations
    public int capacity;
	public int magazineSize;
	public int magazine;
	public int ammo;
    public float range = 50;
    public int damage = 1;

    // Timers to handle gun controls
    public float shootingTime = 1f;
	public float reloadTime = 1f;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    // Animations
    private Animation animationController;

	public AnimationClip animationShotClip;
	public AnimationClip animationReloadingClip;

	// Sounds
	private AudioSource audioSourceGunSound;
	private AudioSource audioSourceGunClick;
	private AudioSource audioSourceGunReloading;

	public AudioClip audioClipGunSound;
	public AudioClip audioClipGunClickSound;
	public AudioClip audioClipGunSoundReloading;

	// Use this for initialization
	public void Start () {
		// Initializing gun's elements
		this.initializeAnimations();
		this.initializeSounds();
        
        fpsCam = GetComponentInParent<Camera>();
    }

	/// <summary>
	/// Initialize the various gun animations
	/// </summary>
	private void initializeAnimations() {
		// Adding component to the game object
		this.animationController = this.gameObject.AddComponent<Animation> ();
		this.animationController.playAutomatically = false;

		this.animationController.AddClip (this.animationShotClip, this.animationShotClip.name);
		this.animationController.AddClip (this.animationReloadingClip, this.animationReloadingClip.name);

		// Marking animations as legacy
		this.animationShotClip.legacy = true;
		this.animationReloadingClip.legacy = true;
	}

	/// <summary>
	/// Initialize the various gun sounds
	/// </summary>
	private void initializeSounds() {
		// Adding components to the game object
		this.audioSourceGunSound = this.gameObject.AddComponent<AudioSource> ();
		this.audioSourceGunClick = this.gameObject.AddComponent<AudioSource> ();
		this.audioSourceGunReloading = this.gameObject.AddComponent<AudioSource> ();

		// Stopping caudio from playing on awake
		this.audioSourceGunSound.playOnAwake = false;
		this.audioSourceGunClick.playOnAwake = false;
		this.audioSourceGunReloading.playOnAwake = false;

		// Assigning clips to their source
		this.audioSourceGunSound.clip = this.audioClipGunSound;
		this.audioSourceGunClick.clip = this.audioClipGunClickSound;
		this.audioSourceGunReloading.clip = this.audioClipGunSoundReloading;
	}

	// Update is called once per frame
	public virtual void Update () {
        Debug.DrawRay(gunEnd.transform.position, gunEnd.transform.forward, Color.green);
        // If this instance of gun is automatic : 
        // Check event MouseButton - Allows to detect click and when key is kept held
        // Else only check event MouseButtonDown, so even if the key is held down, the gun will only shoot once
        if (automatic) {
			if (Input.GetMouseButton (0)) {
				this.HandleShot ();
			}
		} else {
			if (Input.GetMouseButtonDown (0)) {
				this.HandleShot ();
			}
		}
			
	}

	/// <summary>
	/// Handles the shot of the gun
	/// </summary>
	private void HandleShot() {
		if (this.IsAnimationPlaying()) {
			return;
		}

		// If out of ammo, play the sound of the gun clicking
		if (!this.HasMunition ()) {
			this.audioSourceGunClick.Play ();
			return;
		}

		// If the magazine is empty we reload the gun
		if (!IsMagazineEmpty ()) {
			this.Reload ();
			return;
		}
			
		// Play the shooting animation and the gun sound
		this.PlayAnimationClip(this.animationShotClip);
		this.audioSourceGunSound.Play ();

        //Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.Log("fpsCam = " + fpsCam);
        
        RaycastHit hit;

        // Counting down ammos
        ammo--;
        magazine--;

        if (Physics.Raycast(gunEnd.transform.position, gunEnd.transform.forward, out hit, range))
        {
            IDamageable health = hit.collider.GetComponent<IDamageable>();
            if (health != null)
            {
                Debug.Log("touché");
                health.Damage(damage, hit.point);
            }
        }
        if (Physics.Raycast(gunEnd.transform.position, gunEnd.transform.forward, out hit, range))
        {
            WeaponSelected weapon = hit.collider.GetComponent<WeaponSelected>();
            weapon.setSelectedWeapon();
        }
    }

	/// <summary>
	/// Determines whether this instance has munition.
	/// </summary>
	/// <returns><c>true</c> if this instance has munition; otherwise, <c>false</c>.</returns>
	public bool HasMunition() {
		return (ammo != 0);
	}

	/// <summary>
	/// Determines whether this instance is magazine empty.
	/// </summary>
	/// <returns><c>true</c> if this instance is magazine empty; otherwise, <c>false</c>.</returns>
	public bool IsMagazineEmpty() {
		return (magazine != 0);
	}

	/// <summary>
	/// Reload the gun
	/// </summary>
	public void Reload() {
		if (magazineSize <= ammo) {
			magazine = magazineSize;
		} else {
			magazine = ammo;
		}

		// Playing the animation and the osund of the gun reloading
		this.PlayAnimationClip(this.animationReloadingClip);
		this.audioSourceGunReloading.Play ();
	}

	/// <summary>
	/// Determines whether this instance is playing sound.
	/// </summary>
	/// <returns><c>true</c> if this instance is playing sound; otherwise, <c>false</c>.</returns>
	private bool IsSoundPlaying() {
		return (this.audioSourceGunSound.isPlaying || this.audioSourceGunClick.isPlaying || this.audioSourceGunReloading.isPlaying);
	}

	private bool IsAnimationPlaying() {
		return this.animationController.isPlaying;
	}

	/// <summary>
	/// Plays the given animation clip.
	/// </summary>
	/// <param name="animationClip">Animation clip.</param>
	private void PlayAnimationClip(AnimationClip animationClip) {
		this.animationController.Play (animationClip.name);
	}

    private IEnumerator ShotEffect()
    {
        yield return shotDuration;
    }
}