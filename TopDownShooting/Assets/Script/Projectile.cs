using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask mCollisionMask;
    float mSpeed = 10f;

    public void SetSpeed(float speed)
    {
        mSpeed = speed;
    }

    void Update()
    {
        float moveDistance = mSpeed * Time.deltaTime;
        CheckCollisions(moveDistance);

        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward); // 투사체의 위치와 방향으로 만든 직선
        RaycastHit hit;

        // QueryTriggerInteraction.Collide하면 isTrigger도 받아올 수 있다.
        // 이번 프레임에 움직인만큼의 선분과 충돌하는 적이 있다면?
        if (Physics.Raycast(ray, out hit, moveDistance, mCollisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);
    }
}
