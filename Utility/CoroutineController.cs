using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
namespace HelperForChallenge.Utility
{
    internal class CoroutineController : MonoBehaviour
    {
        private static CoroutineController? Instance { get; set; }

        static CoroutineController()
        {
            Initialize();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            if (Instance != null)
            {
                return;
            }

            var container = new GameObject("1");
            Instance = container.AddComponent<CoroutineController>();
        }
        public static Coroutine Start(IEnumerator routine)
        {
            return Instance.StartCoroutine(routine);
        }

    }
}