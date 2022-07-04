
namespace Enemy.StateMachine.Transitions
{
    public class TargetDieTransition : Transition
    {
        private void Update()
        {
            if (Target == null)
            {
                NeedTransit = true;
            }
        }
    }
}