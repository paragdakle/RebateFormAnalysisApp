using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_pxd160530
{
    /// <remarks>
    /// Author: Parag Pravin Dakle
    /// Course: Human Computer Interaction CS 6326 Spring 2017
    /// Net ID: pxd160530
    /// </remarks>
    /// <summary>
    /// <c>class RecordWriter</c>
    /// This class carries out direct file writing operations using the <c>StreamWriter</c> class.
    /// </summary>
    class RecordWriter
    {
        /// <summary>
        /// filePath: The path of the file, which includes name, to perform write operations on.
        /// stream: The StreamWriter object.
        /// </summary>
        string filePath { get; }

        StreamWriter stream;

        /// <summary>
        /// Class Constructor.
        /// Initializes filePath to the provided filePath parameter and stream to null.
        /// </summary>
        /// <param name="filePath">The path of the file which includes name.</param>
        public RecordWriter(string filePath)
        {
            this.filePath = filePath;
            stream = null;
        }

        /// <summary>
        /// The function opens a file by creating a new StreamWriter object with the file pointed by filePath.
        /// </summary>
        /// <returns>True if file was opened successfully else False.</returns>
        public bool openFile()
        {
            if (stream == null)
            {
                try
                {
                    stream = new StreamWriter(filePath);
                }
                catch (IOException e)
                {
                    Console.Out.WriteLine(e.StackTrace);
                    stream = null;
                }
            }
            Console.Out.WriteLine("Error another file already open");
            return stream != null;
        }

        /// <summary>
        /// The function closes the file who's handle is present in stream object.
        /// Also disposes the stream object cleanly.
        /// </summary>
        /// <returns>True if file was closed successfully else False.</returns>
        public bool closeFile()
        {
            if(stream != null)
            {
                stream.Close();
                ((IDisposable)stream).Dispose();
                stream = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// The function appends a string to a file.
        /// </summary>
        /// <param name="contents">String to write to file.</param>
        /// <returns>True if contents were written successfully else False.</returns>
        /// <remarks>
        /// If the stream object does not contain handle to a file a <c>FileNotFoundException</c>
        /// </remarks>
        public bool writeToFile(string contents)
        {
            if(stream == null) 
            {
                throw new FileNotFoundException();
            }
            try
            {
                stream.WriteLine(contents);
            }
            catch(Exception e)
            {
                Console.Out.Write(e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
