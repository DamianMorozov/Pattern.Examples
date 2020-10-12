using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesignPatterns.IDisposable
{
    public class DisposableExample : System.IDisposable
    {
        #region Public and private fields and properties

        private bool Disposed { get; set; }
        private string FileName { get; set; }

        #endregion

        #region Constructor and destructor

        public DisposableExample(string fileName)
        {
            FileName = fileName;
        }

        ~DisposableExample()
        {
            Dispose();
        }

        #endregion

        #region Public and private methods

        /// <summary>
        /// Releasing managed resources.
        /// </summary>
        private void DisposeManagedResources()
        {
        }

        /// <summary>
        /// Releasing unmanaged resources.
        /// </summary>
        private void DisposeUnmanagedResources()
        {
            // Open files, file descriptors / open files.
            // Open network connections, connection to the database / open network connections.
            // Unmanaged memory.
        }

        /// <summary>
        /// The Dispose method will be called once.
        /// </summary>
        public void Dispose()
        {
            lock (this)
            {
                if (!Disposed)
                {
                    // Releasing managed resources
                    DisposeManagedResources();

                    // Releasing unmanaged resources
                    DisposeUnmanagedResources();

                    // Resource release flag
                    Disposed = true;
                }

                // Disable the garbage collector from calling the destructor
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Throw exception if disposed.
        /// </summary>
        private void CheckIfDisposed([CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (Disposed)
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                throw new ObjectDisposedException($@"File {fileName}. Member {memberName}. Object has been disposed off!");
            }
        }

        /// <summary>
        /// Some method.
        /// </summary>
        /// <returns></returns>
        public StringBuilder ReadFile()
        {
            var sb = new StringBuilder();

            CheckIfDisposed();

            using var reader = new StreamReader(FileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }

            return sb;
        }

        #endregion
    }
}
