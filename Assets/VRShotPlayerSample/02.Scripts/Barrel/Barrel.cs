using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
	private int limitHitCount = 1;
	public GameObject expEffect;

	private int hitCount = 0;
	private GameObject barrel = null;

	private void Start()
	{
		barrel = this.gameObject;

		expEffect.SetActive(false);
	}

	public void OnDamage()
	{
		hitCount += 1;

		if (hitCount == limitHitCount) { ExpBarrelImmediatelyProcess(); }
	}

	private void ExpBarrelImmediatelyProcess()
	{
		float endExpEffectTime = 2.0f;
		HideBarrelandImpactMeshandEffects();
		ShowExpEffect();
		Destroy(barrel, endExpEffectTime);
		GetComponent<BarrelSound>().ExpSfx();
	}

	private void HideBarrelandImpactMeshandEffects()
	{
		barrel.GetComponent<MeshRenderer>().enabled = false;
	}

	private void ShowExpEffect()
	{
		expEffect.SetActive(true);
	}
}