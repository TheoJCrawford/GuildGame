using UnityEngine;
using System.Collections;
using GG.CharacterSystem;

namespace GG.AISystem {
    [RequireComponent(typeof(BaseCharacter))]
    public class AllyMovement : MonoBehaviour {
        private GameObject _player;
        private FSMSystem _fsm;
        // Use this for initialization
        void Start() {
            MakeFSM();
        }

        // Update is called once per frame
        void FixedUpdate() {
            _fsm.currentState.Reason(_player, gameObject);
            _fsm.currentState.Act(_player, gameObject);
        }
        private void MakeFSM()
        {
            _fsm = new FSMSystem();
           // _fsm.AddState(follow);
           
        }
    }
}