using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UOGame
{
    public class LogManager : MonoBehaviour
    {
        [SerializeField] bool enableDebugLogging = true;

        private void Awake()
        {
            Debug.unityLogger.logEnabled = enableDebugLogging;
        }
    }
}
