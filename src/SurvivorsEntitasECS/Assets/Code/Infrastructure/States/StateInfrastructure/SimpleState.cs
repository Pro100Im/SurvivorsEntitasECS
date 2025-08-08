//using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class SimpleState : IState
    {
        public virtual void Enter()
        {
        }

        protected virtual void Exit()
        {
        }

        void IExitableState.Exit()
        {
            Exit();
        }

        //IPromise IExitableState.BeginExit()
        //{
        //  Exit();
        //  return Promise.Resolved();
        //}

        //void IExitableState.EndExit(){}
    }
}