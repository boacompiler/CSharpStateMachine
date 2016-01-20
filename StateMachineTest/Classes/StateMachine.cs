using StateMachineTest.States;

namespace StateMachineTest.Classes
{
    public class StateMachine
    {
        private BaseEntity owner;
        private State currentState;
        private State globalState;
        private State previousState;

        public State CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public State GlobalState
        {
            get
            {
                return globalState;
            }

            set
            {
                globalState = value;
            }
        }

        public State PreviousState
        {
            get
            {
                return previousState;
            }
        }

        public StateMachine(BaseEntity owner)
        {
            this.owner = owner;
            
        }

        public void ChangeState(State newState)
        {
            if (currentState != null)
            {
                currentState.Exit(owner);
            }
            previousState = currentState;
            currentState = newState;
            currentState.Enter(owner);
        }

        public void HandleMessage(Telegraph.Telegram telegram)
        {
            globalState.OnMessage(EntityManager.Instance.GetEntityByID(telegram.Sender), (Telegraph.MessageType)telegram.Message);
            currentState.OnMessage(EntityManager.Instance.GetEntityByID(telegram.Sender), (Telegraph.MessageType)telegram.Message);
        }

        public void Update()
        {
            if (globalState != null) { globalState.Update(owner); }
            if (currentState != null){ currentState.Update(owner); }
        }
    }
}
