using System;
using System.Diagnostics;
using System.Globalization;

using Artech.Architecture.Common.Services;
using Artech.MsBuild.Common;
using GXTasks;

namespace Artech.Samples.GXTasks
{
	public class KnowledgeBaseInfo : ArtechTask
	{
		public override bool Execute()
		{
			bool isSuccess = true;

			Stopwatch watch = null;
			try
			{
				OutputSubscribe();
				CommonServices.Output.StartSection(Resources.TaskName);

				watch = new Stopwatch();
				watch.Start();


				if (KB == null)
				{
					CommonServices.Output.AddErrorLine(Resources.NoKB);
					isSuccess = false;
				}
				else
				{
					CommonServices.Output.AddLine(string.Format(CultureInfo.CurrentCulture, Resources.WorkingOnKnowledgeBase, KB.Name, KB.Location));
					CommonServices.Output.AddLine(Resources.AdditionalAndImportantInfo);
				}

				CommonServices.Output.AddLine(string.Format(CultureInfo.CurrentCulture, Resources.TaskTime, Resources.TaskName, watch.Elapsed.Seconds.ToString()));
			}
			catch (Exception ex)
			{
				CommonServices.Output.AddErrorLine(ex.Message);
				isSuccess = false;
			}
			finally
			{
				if (watch != null)
					watch.Stop();

				CommonServices.Output.EndSection(Resources.TaskName, isSuccess);
				OutputUnsubscribe();
			}

			return isSuccess;
		}
	}
}
