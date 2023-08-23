using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkill : MonoBehaviour
{
    [SerializeField] private float shootCoolDown;

    private Animator animator;
    public GameObject firePoint;
    CoinSystem coinSystem;
    // public List<GameObject> VFXs = new List<GameObject>();
    public float fireVelocity;

    private GameObject effectToSpawn;
    private float coolDownTimer = Mathf.Infinity;
    // public GameObject vfx;

    private void Start()
    {
        // Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
       coinSystem = FindObjectOfType<CoinSystem>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Z) && coolDownTimer > shootCoolDown)
        {
            Shoot();
            SpawnVFX();
        }
        coolDownTimer += Time.deltaTime;
        effectToSpawn = ShopManager.Ins.skills[Pref.CurSkillId].SkillPb;
    }
    private void Shoot()
    {
        animator.SetTrigger("Skill");
        coolDownTimer = 0;
    }

    public void SpawnVFX()
    {
        GameObject vfx;
        if(firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            effectToSpawn.GetComponent<Rigidbody>().velocity = transform.forward * fireVelocity;
            Debug.Log(effectToSpawn);
        } else
        {
            vfx = Instantiate(effectToSpawn);
            
        }
        
        var ps = vfx.GetComponent<ParticleSystem>();
        if(vfx.transform.childCount > 0)
        {
            ps = vfx.transform.GetChild(0).GetComponent<ParticleSystem>();
        } 
    }
}
