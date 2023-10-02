using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOB.StateMachine.States
{
    public partial class OverworldStartupState : State
    {
        public override IEnumerator End()
        {
            return base.End();
        }

        public override IEnumerator Execute()
        {
            return base.Execute();
        }

        public override IEnumerator Pause()
        {
            return base.Pause();
        }

        public override IEnumerator Resume()
        {
            return base.Resume();
        }

        //This method should load the first tilemap in the game
        public override IEnumerator Start()
        {

            return base.Start();
        }
    }
}
