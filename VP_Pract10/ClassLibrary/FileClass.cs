using System;
using System.IO;
using System.Reflection.PortableExecutable;

namespace ClassLibrary
{


    public class FileClass: IDisposable
    {

        private bool _isDisposed = false;
        private StreamReader _reader;
        private StreamWriter _writer;
        private Stream _stream;

        private FileClass(Stream stream)
        {
            this._stream = stream;
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream);
        }

        private static Stream CreateStream(string path)
        {
            return new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
        }

        private static Stream OpenStream(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
        }

        public static FileClass Create(string path)
        {
            Stream stream = CreateStream(path);
            return new FileClass(stream);
        }

        public static FileClass Open(string path)
        {
            Stream stream = OpenStream(path);
            return new FileClass(stream);
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }

        public string Read(int count)
        {
            char[] buffer = new char[count];
            int bytesRead = _reader.Read(buffer, 0, count);
            if (bytesRead == 0) // Если ничего не прочитано, вернуть пустую строку
                return "";

            return new string(buffer, 0, bytesRead); // Вернуть только прочитанные символы
        }

        public void Dispose()
        {
            Dispose(true);
            //Не отправлять объект в очередь финализации
            GC.SuppressFinalize(this);
        }
        ~FileClass()
        {
            Dispose(false);
        }

        protected  virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
              
                //Освобождаем неуправляемые ресурсы
                if (_writer != null)
                {
                    _writer.Flush();
                    _writer.Close();
                    _writer = null;
                }

                //Освобождаем неуправляемые ресурсы
                if (_reader != null)
                {
                    _reader.Close();
                    _reader = null;
                }

                //Ресурсы были освобождены
                _isDisposed = true;

                //вызываем метод Dispose базового класса
                Dispose(isDisposing);
            }
        }

        public void WriteLine(string line)
        {
            _writer.WriteLine(line);
        }

        public void Write(string text)
        {
            _writer.Write(text);
        }

        public void Close()
        {
            _writer.Dispose();
            _reader.Dispose();
            _stream.Dispose();
        }
    }

}
