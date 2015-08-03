using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Effects;

public class ExplosionScript : MonoBehaviour {

	public enum Mode
	{
		Activate,
		Instantiate,
		Trail
	}
	
	public enum AlignMode
	{
		Normal,
		Up
	}
	
	
	public DemoParticleSystemList demoParticles;
	public float spawnOffset = 0.5f;
	public float multiply = 1;
	public bool clearOnChange = false;
	public Text titleText;
	public Transform sceneCamera;
	public GraphicRaycaster graphicRaycaster;
	public EventSystem eventSystem;
	
	
	private ParticleSystemMultiplier m_ParticleMultiplier;
	private List<Transform> m_CurrentParticleList = new List<Transform>();
	private Transform m_Instance;
	private static int s_SelectedIndex = 0;
	private Vector3 m_CamOffsetVelocity = Vector3.zero;
	private Vector3 m_LastPos;
	private static DemoParticleSystem s_Selected;

	private bool spellsActive = false;
	
	
	private void Awake()
	{
		Select(s_SelectedIndex);
		
	}
	
	
	private void OnDisable()
	{
	}

	public void TriggerSpells()
	{
		spellsActive = !spellsActive;
		GameObject button = GameObject.Find ("SpellsTriggerButton");
		if (spellsActive)
			button.GetComponentsInChildren<Text> ()[0].text = "Deactivate explosions";
		else
			button.GetComponentsInChildren<Text> ()[0].text = "Activate explosions";
			
	}
	
	
	/*private void Previous()
	{
		s_SelectedIndex--;
		if (s_SelectedIndex == -1)
		{
			s_SelectedIndex = demoParticles.items.Length - 1;
		}
		Select(s_SelectedIndex);
	}
	
	
	public void Next()
	{
		s_SelectedIndex++;
		if (s_SelectedIndex == demoParticles.items.Length)
		{
			s_SelectedIndex = 0;
		}
		Select(s_SelectedIndex);
	}*/
	
	
	private void Update()
	{
		
		#if !MOBILE_INPUT
		KeyboardInput();
		#endif
		
		
		
		sceneCamera.localPosition = Vector3.SmoothDamp(sceneCamera.localPosition, Vector3.forward*-s_Selected.camOffset,
		                                               ref m_CamOffsetVelocity, 1);
		
		if (s_Selected.mode == Mode.Activate)
		{
			// this is for a particle system that just needs activating, and needs no interaction (eg, duststorm)
			return;
		}
		
		if (CheckForGuiCollision()) return;
		
		bool oneShotClick = (Input.GetMouseButtonDown(0) && s_Selected.mode == Mode.Instantiate);
		bool repeat = (Input.GetMouseButton(0) && s_Selected.mode == Mode.Trail);
		
		if ((oneShotClick || repeat) && spellsActive)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				var rot = Quaternion.LookRotation(hit.normal);
				
				if (s_Selected.align == AlignMode.Up)
				{
					rot = Quaternion.identity;
				}
				
				var pos = hit.point + hit.normal*spawnOffset;
				
				if ((pos - m_LastPos).magnitude > s_Selected.minDist)
				{
					if (s_Selected.mode != Mode.Trail || m_Instance == null)
					{
						m_Instance = (Transform) Instantiate(s_Selected.transform, pos, rot);
						
						/*if (m_ParticleMultiplier != null)
						{
							m_Instance.GetComponent<ParticleSystemMultiplier>().multiplier = multiply;
						}
						
						m_CurrentParticleList.Add(m_Instance);
						
						if (s_Selected.maxCount > 0 && m_CurrentParticleList.Count > s_Selected.maxCount)
						{
							if (m_CurrentParticleList[0] != null)
							{
								Destroy(m_CurrentParticleList[0].gameObject);
							}
							m_CurrentParticleList.RemoveAt(0);
						}*/
					}
					else
					{
						m_Instance.position = pos;
						m_Instance.rotation = rot;
					}
					
					if (s_Selected.mode == Mode.Trail)
					{
						//m_Instance.transform.GetComponent<ParticleSystem>().enableEmission = false;
						//m_Instance.transform.GetComponent<ParticleSystem>().Emit(1);
					}
					
					//m_Instance.parent = hit.transform;
					m_LastPos = pos;
				}
			}
		}
	}
	
	
	#if !MOBILE_INPUT
	void KeyboardInput()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow))
			Previous();
		
		if (Input.GetKeyDown(KeyCode.RightArrow))
			Next();
	}
	#endif
	
	
	bool CheckForGuiCollision()
	{
		PointerEventData eventData = new PointerEventData(eventSystem);
		eventData.pressPosition = Input.mousePosition;
		eventData.position = Input.mousePosition;
		
		List<RaycastResult> list = new List<RaycastResult>();
		graphicRaycaster.Raycast(eventData, list);
		return list.Count > 0;
	}
	
	public void Select(int i)
	{
		s_Selected = demoParticles.items[i];
		m_Instance = null;
		foreach (var otherEffect in demoParticles.items)
		{
			if ((otherEffect != s_Selected) && (otherEffect.mode == Mode.Activate))
			{
				otherEffect.transform.gameObject.SetActive(false);
			}
		}
		if (s_Selected.mode == Mode.Activate)
		{
			s_Selected.transform.gameObject.SetActive(true);
		}
		m_ParticleMultiplier = s_Selected.transform.GetComponent<ParticleSystemMultiplier>();
		multiply = 1;
		if (clearOnChange)
		{
			while (m_CurrentParticleList.Count > 0)
			{
				Destroy(m_CurrentParticleList[0].gameObject);
				m_CurrentParticleList.RemoveAt(0);
			}
		}
		
		titleText.text = s_Selected.transform.name;
	}
	
	
	[Serializable]
	public class DemoParticleSystem
	{
		public Transform transform;
		public Mode mode;
		public AlignMode align;
		public int maxCount;
		public float minDist;
		public int camOffset = 15;
		public string attackName;
	}
	
	[Serializable]
	public class DemoParticleSystemList
	{
		public DemoParticleSystem[] items;
	}
}
