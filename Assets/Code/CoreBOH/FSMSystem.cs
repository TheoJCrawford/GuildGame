using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GG
{
    /// <summary>
    /// This class represents the States in the Finite State System.
    /// Each state has a Dictionary with pairs (transition-state) showing
    /// which state the FSM should be if a transition is fired while this state
    /// is the current state.
    /// Method Reason is used to determine which transition should be fired .
    /// Method Act has the code to perform the actions the NPC is supposed do if it's on this state.
    /// </summary>
    public abstract class FSMState
    {
        protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();
        protected StateID stateID;
        public StateID ID { get { return stateID; } }


        public void AddTransition(Transition trans, StateID id)
        {
            if (trans == Transition.NullTransition)
            {
                Debug.LogError("FSMState ERROR: NullStateID is not allowed tfor a real ID");
                return;
            }
            if (map.ContainsKey(trans))
            {
                Debug.LogError("MSMState ERROR: State " + stateID.ToString() + " already has transistion" + trans.ToString() + "Impossible to assign to another state");
                return;
            }
            map.Add(trans, id);
        }

        /// <summary>
        /// This method deletes a pair transition-state from this state's map.
        /// If the transition was not inside the state's map, an ERROR message is printed.
        /// </summary>
        public void DeleteTransition(Transition trans)
        {
            if (trans == Transition.NullTransition)
            {
                Debug.LogError("FSMState ERROR: NullTransition is not allowed");
                return;
            }

            if (map.ContainsKey(trans))
            {
                map.Remove(trans);
            }
            Debug.LogError("FSMState ERROR: Transition " + trans.ToString() + " passed to " + stateID.ToString() + " was not on the state's transition list");
        }

        /// <summary>
        /// This method returns the new state the FSM should be if
        ///    this state receives a transition and 
        /// </summary>
        public StateID GetOutputState(Transition trans)
        {
            if (map.ContainsKey(trans))
            {
                return map[trans];
            }

            return StateID.NullStateID;
        }

        public virtual void DoBeforeEntering() { }
        public virtual void DoBeforeLeaving() { }

        public abstract void Reason(GameObject player, GameObject npc);
        public abstract void Reason(GameObject player, GameObject npc, GameObject target);
        public abstract void Act(GameObject player, GameObject npc);
        public abstract void Act(GameObject player, GameObject npc, GameObject target);
    }
    public class FSMSystem
    {
        #region variables
        private List<FSMState> _states;

        private StateID _curentStateID;
        private FSMState _currentState;
        #endregion
        #region Getters
        public StateID currentStateID { get { return _curentStateID; } }
        public FSMState currentState { get { return _currentState; } }
        #endregion
        #region Constructores
        public FSMSystem()
        {
            _states = new List<FSMState>();
        }
        #endregion
        #region Fucntions
        public void AddState(FSMState s)
        {
            if (s == null)
            {
                Debug.LogError("FSM ERROR: Null reference is not allowed");
            }
            if (_states.Count == 0)
            {
                _states.Add(s);
                _curentStateID = s.ID;
                return;
            }

            //add the state to the list if it's not inside it
            foreach (FSMState state in _states)
            {
                if (state.ID == s.ID)
                {
                    Debug.LogError("FSM Error:  Impossible to add state " + s.ID.ToString() + " because state has already been added");
                    return;
                }
            }
            _states.Add(s);
        }
        public void DeleteState(StateID id)
        {
            if (id == StateID.NullStateID)
            {
                Debug.LogError("FSM ERROR: NullStateID is not allowed for a real state");
            }
            foreach (FSMState state in _states)
            {
                if (state.ID == id)
                {
                    _states.Remove(state);
                    return;
                }
            }
            Debug.LogError("FSM ERROR: Impossible to delete state " + id.ToString() + ". It was note on the list of states");
        }
        public void PerformTransition(Transition trans)
        {
            if (trans == Transition.NullTransition)
            {

                Debug.LogError("FSM ERROR: NullTransition is not allowed for a real transition");
                return;
            }

            StateID id = _currentState.GetOutputState(trans);
            if (id == StateID.NullStateID)
            {
                Debug.LogError("FSM ERROR: State " + " does not have a target state " + "fore transition " + trans.ToString());
                return;
            }

            _curentStateID = id;
            foreach (FSMState state in _states)
            {
                if (state.ID == currentStateID)
                {
                    currentState.DoBeforeLeaving();

                    _currentState = state;

                    currentState.DoBeforeEntering();
                    break;
                }
            }
        }
        #endregion
    }
    #region Enums
    public enum Transition
    {
        NullTransition = 0, //use this transition to represent a non-existing transition in your system
    };
    public enum StateID
    {
        NullStateID = 0, // Use this ID to represent a non-existing State in your system
    };
    #endregion
}