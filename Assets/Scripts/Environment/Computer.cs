using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
  
        [SerializeField]private TaskQueue<Task> tasks = null; // Put your stack/queue here :)

        public void OnInteract() {
            tasks.DeQueue().Execute();
        }
    }
}
