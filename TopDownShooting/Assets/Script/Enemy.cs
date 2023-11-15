using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent mPathFinder;
    Transform mTarget;

    void Start()
    {
        mPathFinder = GetComponent<NavMeshAgent>();
        mTarget = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        // mPathFinder.SetDestination(mTarget.position); // 매 프레임마다 새로운 경로를 찾는 방식이다. 호출 비용을 줄일 필요가 있따.
    }

    // 코루틴은 한 번 실행되면 루프를 돌면서 refreshRate를 기다린 후 반환한다.
    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        while (mTarget != null)
        {
            Vector3 targetPosition = new Vector3(mTarget.position.x, 0, mTarget.position.z);
            mPathFinder.SetDestination(targetPosition);

            yield return new WaitForSeconds(refreshRate); //
        }
    }
}
