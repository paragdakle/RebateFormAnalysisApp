using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asg3_pxd160530
{
    /// <remarks>
    /// Author: Parag Pravin Dakle
    /// Course: Human Computer Interaction CS 6326 Spring 2017
    /// Net ID: pxd160530
    /// </remarks>
    /// <summary>
    /// <c>class ListViewComparer</c>
    /// Implements <c>IComparer</c>.
    /// The class implements a custom <c>Compare</c> function to sort the columns in the ListView.
    /// </summary>
    class ListViewComparer : IComparer
    {
        /// <summary>
        /// columnToSort: Index of the current column to sort.
        /// orderOfSort: Current order of sorting.
        /// comparer: A <c>CaseInsensitiveComparer</c> object to perform the basic comparison.
        /// </summary>
        private int columnToSort;

        private SortOrder orderOfSort;

        private CaseInsensitiveComparer comparer;

        /// <summary>
        /// Default constructor of the class. Initialized all the member variables.
        /// </summary>
        public ListViewComparer()
        {
            columnToSort = 0;
            orderOfSort = SortOrder.None;
            comparer = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// Method is inherited from the <c>IComparer</c> class. 
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other
        /// </summary>
        /// <param name="x">First object to compare</param>
        /// <param name="y">Second object to compare</param>
        /// <returns>
        /// A signed integer that indicates the relative values of x and y, as shown in the following table.
        /// Value Meaning Less than zero x is less than y. Zero x equals y. Greater than zero x is greater than y.
        /// </returns>
        public int Compare(object x, object y)
        {
            int result;
            ListViewItem item1 = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;

            result = comparer.Compare(item1.SubItems[columnToSort].Text, item2.SubItems[columnToSort].Text);

            if (orderOfSort == SortOrder.Ascending)
                return result;
            else if (orderOfSort == SortOrder.Descending)
                return (-result);
            else
            {
                //Indicates x is equal y.
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set { columnToSort = value; }
            get { return columnToSort; }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set { orderOfSort = value; }
            get { return orderOfSort; }
        }
    }
}
