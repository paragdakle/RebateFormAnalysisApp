using Asg3_pxd160530;
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
    /// <c>class RecordManager<typeparam name="S">Class of records dictionary keys.</typeparam><typeparam name="T">Class of records dictionary values.</typeparam></c>
    /// Implements <c>IOManagerInterface</c>.
    /// The class is acts as a layer between storage and user interface layers. 
    /// It contains methods accepting input from the UI layer and performing operations by consuming lower layer classes.
    /// Currently the storage type is files.
    /// </summary>
    class RecordManager<S, T> : IOManagerInterface<string>
    {
        /// <summary>
        /// filePath: String containing the name of the file to read/write records.
        /// writer: RecordWriter object. <see cref="RecordWriter"/>
        /// reader: RecordReader object. <see cref="RecordReader"/>
        /// </summary>
        public string filePath { get; }
        RecordWriter writer;
        RecordReader reader;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="filePath">The path of the file to use for performing operations on the records.</param>
        public RecordManager(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// The function reads a record from saved records on the storage media.
        /// In case the reader object has not been created it creates a <c>RecordReader</c> object, opens the file, reads a record and closes the file.
        /// <seealso cref="RecordReader.readFromFile"/>
        /// </summary>
        /// <returns>The record read as a string object.</returns>
        public string readRecord()
        {
            string record = null;
            if (reader == null)
            {
                reader = new RecordReader(filePath);
                if (reader.openFile()) {
                    try
                    {
                        record = reader.readFromFile();
                    }
                    catch(Exception ex)
                    {
                        Console.Out.Write(ex.StackTrace);
                        return record;
                    }
                    reader.closeFile();
                }
                return record;
            }
            return reader.readFromFile();
        }

        /// <summary>
        /// The function writes a record to the storage media.
        /// In case the writer object has not been created it creates a <c>RecordWriter</c> object, opens the file, writes a record and closes the file.
        /// <seealso cref="RecordWriter.writeToFile(string)"/>
        /// </summary>
        /// <param name="record">The record to write</param>
        /// <returns>True if the record was written successfully else False.</returns>
        public bool writeRecord(string record)
        {
            if(writer == null)
            {
                writer = new RecordWriter(filePath);
                if (writer.openFile())
                {
                    try
                    {
                        if (!writer.writeToFile(record))
                            return false;
                    }
                    catch (Exception ex)
                    {
                        Console.Out.Write(ex.StackTrace);
                        return false;
                    }
                    writer.closeFile();
                }
                return true;
            }
            return writer.writeToFile(record);
        }

        /// <summary>
        /// The function writes all the records in the given dictionary to the storage media.
        /// It creates a <c>RecordReader</c> object, opens the file, writes all records and closes the file.
        /// <seealso cref="RecordManager{S, T}.writeRecord(string)"/>
        /// </summary>
        /// <param name="records">Dictionary containing all the records as values.</param>
        /// <returns>True if the records were written successfully else False.</returns>
        /// <remarks>
        /// Note: Currently is it assumed that the <c>class T</c> of the records will have a <c>ToString</c> method returning the record in a string form. <see cref="Entitiy.Buyer.ToString"/>
        /// </remarks>
        public bool writeRecords(Dictionary<S, T> records)
        {
            writer = new RecordWriter(filePath);
            if (writer.openFile())
            {
                List<T> recordsList = records.Values.ToList();
                foreach (T record in recordsList)
                {
                    if (!writeRecord(record.ToString()))
                    {
                        writer.closeFile();
                        return false;
                    }
                }
                writer.closeFile();
            }
            else
            {
                Console.Out.Write("Error opening file");
                return false;
            }
            return true;
        }

        /// <summary>
        /// The function reads all the saved record on the storage media.
        /// It creates a <c>RecordReader</c> object, opens the file, reads all the records and closes the file.
        /// <seealso cref="RecordManager{S, T}.readRecord"/>
        /// </summary>
        /// <returns>A list of records where each record is a string.</returns>
        public List<string> readAllRecords()
        {
            List<string> records = new List<string>();
            reader = new RecordReader(filePath);
            if (reader.openFile())
            {
                while (true)
                {
                    string record = readRecord();
                    if (record != null)
                    {
                        records.Add(record);
                    }
                    else
                        break;
                }
                reader.closeFile();
            }
            else
            {
                Console.Out.Write("No existing records file found!");
            }
            return records;
        }
    }
}
