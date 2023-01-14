using System;
using System.Diagnostics;

namespace FlStudioInfoHelper
{
    /// <summary>
    /// Class, intended to retreive project info from FL Studio
    /// </summary>
    public class FlStudioInfoRetreiver
    {
        /// <summary>
        /// <see cref="Process"/> instance, representing FL Studio process.
        /// </summary>
        public Process FlStudioProcess { get; }

        /// <summary>
        /// Representing array of possible FL Studio process names. It is <i>{"FL", "FL64"}</i> <b>by default</b>.
        /// </summary>
        public string[] FlStudioProcessNames { get; init; } =
        {
            "FL",
            "FL64"
        };

        /// <summary>
        /// Creates new instance of the <see cref="FlStudioInfoRetreiver"/> class.
        /// </summary>
        public FlStudioInfoRetreiver()
        {
            foreach (string name in FlStudioProcessNames)
            {
                FlStudioProcess = Process.GetProcessesByName(name).IfNotEmptyReturnFirst();

                if (FlStudioProcess != null) return;
            }
            
            throw new ApplicationException("FL Studio process couldn't be found.");
        }

        /// <summary>
        /// Creates new instance of the <see cref="FlStudioInfoRetreiver"/> class.
        /// </summary>
        public FlStudioInfoRetreiver(Process flstudio)
        {
            FlStudioProcess = flstudio ?? throw new ArgumentNullException(nameof(flstudio), "Provided argument is incorrect, it can't be null.");
        }

        /// <summary>
        /// <see cref="DateTime"/> structure, representing start time of FL Studio.
        /// </summary>
        public DateTime StartTime => FlStudioProcess.StartTime;

        /// <summary>
        /// Representing currently open FL Studio project name.
        /// </summary>
        public string ProjectName
        {
            get
            {
                FlStudioProcess.Refresh();

                string title = FlStudioProcess.MainWindowTitle;
                if (title == null) throw new InvalidOperationException("Main window title must be not null.");

                string[] parsed;

                if ((parsed = title.Split(" - FL Studio")).Length > 1)
                {
                    return parsed[0];
                }
                else return string.Empty;
            }
        }
    }
}
