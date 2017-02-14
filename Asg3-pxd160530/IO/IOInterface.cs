using System;
using System.Collections.Generic;
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
    /// <c>interface IOManagerInterface<typeparam name="T">Class of record given to/received from the lower level storage layer.</typeparam></c>
    /// The interface mandates all the methods that any record manager must implement.
    /// </summary>
    interface IOManagerInterface<T>
    {
        /// <summary>
        /// Writes a record of <c>class T</c> to the storage media by using lower level storage classes.
        /// </summary>
        /// <param name="record">The record to write</param>
        /// <returns>True if write operation was successful else False.</returns>
        bool writeRecord(T record);

        /// <summary>
        /// Reads a record of <c>class T</c> from the storage media by using lower level storage classes.
        /// </summary>
        /// <returns>The record that was read.</returns>
        T readRecord();
    }
}
