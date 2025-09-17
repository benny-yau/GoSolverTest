using Go;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;


namespace UnitTestProject
{
    [TestClass]
    public class Program
    {
        static void Main(string[] args)
        {
        }

        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext testContext)
        {
            //set to true to start leela zero, to remove redundant neural net moves in LeelaSharp project
            MonteCarloGame.useLeelaZero = false;

            try
            {
                if (!MonteCarloGame.useLeelaZero) return;
                Process process = new Process();
                process.StartInfo.FileName = @"..\..\..\LeelaSharp\leelazero\leelaz";
                process.StartInfo.Arguments = @"--gtp --lagbuffer 0 --weights ..\..\..\LeelaSharp\LeelaSharp\lznetwork.gz";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.OutputDataReceived += new DataReceivedEventHandler(MonteCarloGame.MyProcess_OutputDataReceived);
                process.ErrorDataReceived += new DataReceivedEventHandler(MonteCarloGame.MyProcess_OutputDataReceived);
                Boolean processStarted = process.Start();
                MonteCarloGame.inputWriter = process.StandardInput;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            catch (Exception ex)
            {
                MonteCarloGame.useLeelaZero = false;
            }
        }
    }
}
