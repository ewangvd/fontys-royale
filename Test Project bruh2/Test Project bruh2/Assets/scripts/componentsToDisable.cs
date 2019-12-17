using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Networking
{
  public class componentsToDisable : NetworkBehaviour
    {
        public List<Behaviour> Components = new List<Behaviour>();

        private void Start()
        {
            if (!isLocalPlayer)
            {
                for (int i = 0; i < Components.Count; i++)
                {
                    Components[i].enabled = false;
                }
            }
            else
            {
                Camera.main.gameObject.SetActive(false);
            }
        }
    }
}
