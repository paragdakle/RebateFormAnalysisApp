using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_pxd160530.Entitiy
{
    /// <remarks>
    /// Author: Parag Pravin Dakle
    /// Course: Human Computer Interaction CS 6326 Spring 2017
    /// Net ID: pxd160530
    /// </remarks>
    /// <summary>
    /// <c>class AnalysisResultItem</c>
    /// The model class for analysis result entity.
    /// </summary>
    class AnalysisResultItem
    {
        /// <summary>
        /// Section consists of various analysis result attributes.
        /// </summary>
        public string observationLabel { get; set; }

        public double observationValue { get; set; }

        public string observationStringValue { get; set; }

        readonly string separator = ": ";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnalysisResultItem()
        {
            observationLabel = "";
            observationValue = 0;
            observationStringValue = "";
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="label">The label identifier of the analysis result object.</param>
        /// <param name="value">The value of the analysis result object.</param>
        /// <param name="stringValue">The string conversion of the value attribute.</param>
        public AnalysisResultItem(string label, double value, string stringValue)
        {
            observationLabel = label;
            observationValue = value;
            observationStringValue = stringValue;
        }

        /// <summary>
        /// Method overrides the base class ToString() method. The generates a complete analysis result record as a string.
        /// </summary>
        /// <returns>The analysis result as a string object.</returns>
        public override string ToString()
        {
            return observationLabel + separator + observationStringValue;
        }
    }
}
