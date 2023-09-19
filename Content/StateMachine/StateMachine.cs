using System.Collections;
using System.Collections.Generic;
public abstract class StateMachine
{
    protected State state;
    /// <summary>
    /// Set the state
    /// </summary>
    /// <param name="state"></param>
    public void SetState(State s) {
        state = s;
        state.Start().MoveNext();
    }
    public State GetState(){
        State s = state;
        return s;
    }
}