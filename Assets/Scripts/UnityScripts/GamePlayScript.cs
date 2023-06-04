using Assets.Scripts.Applications;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets.Scripts.UnityScripts
{
    public class GamePlayScript : MonoBehaviour
    {
        [SerializeField] public XRSocketInteractor SocketSphere;
        [SerializeField] public XRSocketInteractor SocketBox;
        [SerializeField] public XRSocketInteractor SocketCylinder;

        public void Update()
        {
            var mainApp = MainApplication.GetInstance();
            var session = mainApp.Session;

            var globeInSocket = CheckSocket(SocketSphere, "sphere");
            var boxInSocket = CheckSocket(SocketBox, "cube");
            var cylinderInSocket = CheckSocket(SocketCylinder, "cylinder");

            if (globeInSocket && boxInSocket && cylinderInSocket)
            {
                session.CompleteTime = DateTime.Now;
            }
        }

        private bool CheckSocket(XRSocketInteractor socket, string tag)
        {
            if (socket == null)
            {
                return false;
            }

            var selected = socket.GetOldestInteractableSelected();
            return selected != null && selected.transform.CompareTag(tag);
        }

    }
}
