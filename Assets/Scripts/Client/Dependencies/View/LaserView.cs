using System;
using System.Collections;
using System.Collections.Generic;
using Client.Dependencies.Addressable;
using CustomEcs;
using GameLogic.Dependencies.View;
using GameLogic.Events;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Client.Dependencies.View
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserView : BaseView, ILaserView
    {
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void Shoot(Vector2 startPosition, Vector2 direction, float duration)
        {
            _lineRenderer.SetPosition(0, new Vector3(startPosition.X, startPosition.Y, 0));
            var start = new UnityEngine.Vector2(startPosition.X, startPosition.Y);
            var uDirection = new UnityEngine.Vector2(direction.X, direction.Y);
            _lineRenderer.SetPosition(1, start + uDirection * 100);

            var hits = new RaycastHit2D [20];
            Physics2D.RaycastNonAlloc(start, uDirection, hits, 100);
            foreach (var raycastHit2D in hits)
            {
                if (raycastHit2D.collider)
                {
                    var senderView = GetComponent<IView>();
                    var targetView = raycastHit2D.collider.GetComponent<IView>();

                    if (senderView != null && targetView != null && senderView.EntityLink.IsAlive && targetView.EntityLink.IsAlive)
                    {
                        if (targetView.EntityLink.Has<CollisionEvent>())
                        {
                            targetView.EntityLink.Get<CollisionEvent>().CollisionList.Add((senderView.EntityLink, targetView.EntityLink));
                        }
                        else
                        {
                            targetView.EntityLink.Get<CollisionEvent>().CollisionList = new List<(EcsEntity sender, EcsEntity target)>() { ((targetView.EntityLink, targetView.EntityLink)) };
                        }
                    }
                }
            }

            StartCoroutine(DisableLaser(duration));
        }

        public event Action<ILaserView> Disabled = delegate {  };

        private IEnumerator DisableLaser(float duration)
        {
            yield return new WaitForSeconds(duration);
            _lineRenderer.enabled = false;
            Disabled(this);
        }
    }
}