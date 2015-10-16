using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ASMSharp
{
    // This is a limited implementation of Task to avoid editing other code
    class Task
    {
        Thread main;
        public Task(Action torun)
        {
            main = new Thread(() =>
            {
                torun();
                Finished();
            }
            );
        }
        Task next = null;
        private void Finished()
        {
            if (next != null) next.Start();
        }

        public void Start()
        {
            main.Start();
        }

        internal void ContinueWith(Action p)
        {
            next = new Task(p);
        }
    }
}
