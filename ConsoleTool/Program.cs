using Artech.Architecture.Common.Objects;
using Artech.Common.Exceptions;
using Artech.Common.Helpers.Assemblies;
using Artech.Common.Helpers.IO;
using Artech.Genexus.Common.Objects;
using System;
using System.IO;

namespace GXextensions.ConsoleTool
{
    class Program
	{
		static CommandParser cmdParser = new CommandParser();

		static void Main(string[] args)
		{
			if (!cmdParser.ParseArguments(args))
				return;

			string kbPath = cmdParser.KB;
			if (!Directory.Exists(kbPath))
			{
				Console.WriteLine(Messages.CouldNotFindKbAt, kbPath);
				return;
			}

			StartGxBL();
			DoWork(kbPath);
		}

		private static void StartGxBL()
		{
			string configurationFile = Path.Combine(AssemblyHelper.GetAssemblyDirectory(), "genexus.exe.config");
			ExceptionManager.ConfigurationFile = configurationFile;
			PathHelper.SetAssemblyInfo("Artech", "Genexus", "10Ev1");
			Artech.Core.Connector.StartBL();
		}

		private static void DoWork(string kbPath)
		{
			try
			{
				KnowledgeBase.OpenOptions options = new KnowledgeBase.OpenOptions(cmdParser.KB);
				options.EnableMultiUser = false;

				KnowledgeBase kb = KnowledgeBase.Open(options);
				KBModel model = kb.DesignModel;

				ListTransactions(model);
			}
			catch (Exception exception)
			{
				Console.Write(exception.Message);
			}
		}

		private static void ListTransactions(KBModel model)
		{
			Console.WriteLine(Messages.Transactions);

			foreach (Transaction trn in Transaction.GetAll(model))
			{
				Console.WriteLine(Messages.TransactionLine, trn.Name);
			}
		}
	}
}
