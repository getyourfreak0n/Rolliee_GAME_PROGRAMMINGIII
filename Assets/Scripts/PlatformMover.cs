using System.Collections;
using UnityEngine;

public class PlatformMover : MonoBehaviour, IPlatformMover
{
   [SerializeField] Transform[] _transforms;
   [SerializeField] float _speed = 0.3f;
   [SerializeField] float _startDelay = 1.0f;
   [SerializeField] float _waitDelay = 1.0f;

   Vector3 targetA;
   Vector3 targetB;
   Vector3 currentTarget;
   Rigidbody _rb;

   void Awake()
   {
      _rb = GetComponent<Rigidbody>();

      targetA = _transforms[0].position;
      targetB = _transforms[1].position;

      currentTarget = targetB;
   }

   void Start()
   {
      StartCoroutine(MoveRoutine());
   }

   private IEnumerator MoveRoutine()
   {
      yield return new WaitForSeconds(_startDelay);

      while (true)
      {
         while (Vector3.Distance(_rb.position, currentTarget) > 0.1f)
         {
            Move();
            yield return new WaitForFixedUpdate();
         }

         yield return new WaitForSeconds(_waitDelay);
         currentTarget = (currentTarget == targetA) ? targetB : targetA;
      }
   }

   public void Move()
   {
      Vector3 moveValue = Vector3.MoveTowards
         (_rb.position, currentTarget, _speed * Time.fixedDeltaTime);

      _rb.MovePosition(moveValue);
   }
}
