using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_pxd160530.Entitiy
{
    class AnalysisResultItem
    {

        public string observationLabel { get; set; }

        public double observationValue { get; set; }

        public string observationStringValue { get; set; }

        readonly string separator = ": ";

        public AnalysisResultItem()
        {
            observationLabel = "";
            observationValue = 0;
            observationStringValue = "";
        }

        public AnalysisResultItem(string label, double value, string stringValue)
        {
            observationLabel = label;
            observationValue = value;
            observationStringValue = stringValue;
        }

        public override string ToString()
        {
            return observationLabel + separator + observationStringValue;
        }
    }
}
