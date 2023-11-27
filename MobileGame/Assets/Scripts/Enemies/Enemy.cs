using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
	[Header("Stats")]
	[SerializeField] protected float damage;
	[SerializeField] protected float _attkRange = 5f;
	[SerializeField] protected Transform _attckSpawnPoint;

	public bool isAlive;
	[Header("Animator")]
	[SerializeField] protected Animator _anim;

	[Header("NavMesh")]
	protected NavMeshAgent _agent;
	[SerializeField] protected float _speed = 5f;
	[SerializeField] private float _rangeToChase = 5f;
	[SerializeField] protected float _rangeToAttack = 2f;

	[Header("Audio")]
	[SerializeField] AudioSource _source;



	protected Transform _target;
	protected float _distance;
	public bool canMove = true;

	public float RangeToChase
	{
		get => _rangeToChase;

	}
	public Transform Target
	{
		get => _target;
	}

	protected virtual void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
		_target = GameManager.instance.PlayerPos; //una referencia desde el playerManager para que incluso los prefabs sepan donde esta el player.
		_agent.speed = _speed;
		_source.enabled = false;
	}
	private void Update()
	{
		_target = GameManager.instance.PlayerPos; //una referencia desde el playerManager para que incluso los prefabs sepan donde esta el player.
		_distance = (transform.position - _target.position).sqrMagnitude;

		if (moveCondition())
		{
			Move();
			if (attackCondition())
			{
				Attack();
			}
		}
		else if (!moveCondition())
		{
			StopMoving();
		}

	}

	public void StopMoving()
	{
		_anim.SetBool("InChaseRange", false);
		_agent.velocity = Vector3.zero;
		_source.enabled = false;
	}


	#region Functions()

	protected virtual bool moveCondition()
	{
		if (_distance <= Mathf.Pow(_rangeToChase, 2) && isAlive)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	protected abstract void Move();
	protected abstract bool attackCondition();
	protected abstract void Attack();
	public virtual void CheckDeath(float health)
	{
		if (health <= 0)
		{
			Death();
		}
	}
	public abstract void Death();
	#endregion

	#region Animationevents
	public void stopMovement()
	{
		_agent.isStopped = true;
		_agent.speed = 0;
		_agent.velocity = Vector3.zero;
		canMove = false;
	}
	public void startMovement()
	{
		_agent.isStopped = false;
		_agent.speed = _speed;
		_anim.SetBool("InAttackRange", false);
		canMove = true;
	}

	public abstract void animationAttack();

	public void destroyOnAnimation()
	{
		Destroy(this.gameObject);
	}

	public void PlayAudioOnAnimation(AudioClip clip)
	{
		if (_source.enabled == false) _source.enabled = true;
		if (_source.clip == clip) return;
		_source.Stop();
		_source.clip = clip;
		_source.Play();
	}


	//private void OnDrawGizmosSelected()//Se usa para ver el rango de atq, No hace falta llamarla (siempre esta activa en la scene). Comentar cuando se deje de usar
	//{
	//	Gizmos.color = Color.red;
	//	Gizmos.DrawWireSphere(_attckSpawnPoint.position, _attkRange);
	//}


	#endregion
}