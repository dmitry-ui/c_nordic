using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson14_Home
{

	public class FileLogWriter : BaseLogWriter, IDisposable
	{
		private StreamWriter _streamWriter;
		//реализован синглтон
		//private static FileLogWriter _instance;

		//public string FullFileName;

		public FileLogWriter(string path)
		{
			//FullFileName = path;
			_streamWriter = new StreamWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.Read));
			_streamWriter.BaseStream.Seek(0, SeekOrigin.End);  //в конец файла
		}

		public void Dispose()
		{
			if (_streamWriter != null)
				_streamWriter.Dispose();
		}

		//public static FileLogWriter GetFileLogWriter(string path = @"C:\SomeDir\ath.txt")
		//{
		//	if (_instance == null)
		//		_instance = new FileLogWriter(path);
		//	return _instance;
		//}

		public override void LogSingleRecord(LogMessageType logMessageType, string message)
		{
			try
			{
				_streamWriter.WriteLine(GetMessage(logMessageType, message));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		
	}

}
