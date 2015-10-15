using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace SIC_Editor
{
    internal class TaskManager
    {
        internal static string defaultLabel = "Idle.";
        static Queue<TaskInfo> pending = new Queue<TaskInfo>();

        static internal Action<TaskInfo> Started;
        static internal Action<TaskInfo> Finished;

        static bool taskrunning = false;
        internal static void Start(string label, Task task, bool showprogbar)
        {
            pending.Enqueue(new TaskInfo(label, task, showprogbar));
            if (!taskrunning)
                CheckNext(null);
        }

        private static void CheckNext(TaskInfo obj)
        {
            taskrunning = false;
            if (Finished != null && obj != null) Finished(obj);
            if (pending.Count > 0)
            {
                taskrunning = true;
                TaskInfo info = pending.Dequeue();
                info.Task.ContinueWith((t) => CheckNext(info));
                info.Task.Start();
                if (Started != null) Started(info);
            }
        }
    }
    class TaskInfo
    {
        internal string Label;
        internal bool ShowProg;
        internal Task Task;

        public TaskInfo(string label, Task task, bool showprogbar)
        {
            this.Label = label;
            this.Task = task;
            this.ShowProg = showprogbar;
        }
    }
}