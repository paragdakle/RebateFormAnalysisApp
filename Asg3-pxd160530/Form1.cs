using Asg3_pxd160530.Entitiy;
using Asg3_pxd160530.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asg3_pxd160530
{
    /// <remarks>
    /// Author: Parag Pravin Dakle
    /// Course: Human Computer Interaction CS 6326 Spring 2017
    /// Net ID: pxd160530
    /// </remarks>
    /// <summary>
    /// <c>partial class MainForm</c>
    /// This class consists of methods and event handlers interacting with the UI and consuming other lower layer classes.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Section consists of various variable declarations.
        /// </summary>
        Dictionary<string, Buyer> buyerDictionary;
        Dictionary<int, AnalysisResultItem> analysisResultDictionary;
        string buyerFileName = "";
        int hasAddedRecord = 0;

        /// <summary>
        /// Default constructor of the main class.
        /// Create the a dictionary to store buyers and a dictionary to store analysis results.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            buyerDictionary = new Dictionary<string, Buyer>();
            analysisResultDictionary = new Dictionary<int, AnalysisResultItem>();
        }

        /// <summary>
        /// Method initializes the form by resetting all the controls. 
        /// Disables/Enables all buttons.
        /// Gives the focus to the first control.
        /// </summary>
        private void initializeForm()
        {
            ctlFilePath.Text = "";
            ctlOpenFileBrowser.Enabled = true;
            ctlSaveFileAnalysis.Enabled = false;
            ctlFilePath.Focus();
            if(hasAddedRecord == 0)
            {
                lblStep1.Font = new Font(lblStep1.Font, FontStyle.Bold);
                hasAddedRecord++;
            }
        }

        /// <summary>
        /// Open file browse button click event handler method.
        /// Starts the OpenFileDialog and get the file path of the file selected.
        /// Displayes this path in a TextBox.
        /// </summary>
        /// <param name="sender">The object whose click event is being handled</param>
        /// <param name="e">EventArgs object.</param>
        private void ctlOpenFileBrowse_Click(object sender, EventArgs e)
        {
            if (hasAddedRecord == 4)
            {
                lblNotes.Font = new Font(lblNotes.Font, FontStyle.Regular);
                hasAddedRecord = 5;
            }
            DialogResult result = ctlOpenFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(ctlOpenFileDialog.FileName))
                {
                    ctlFilePath.Text = ctlOpenFileDialog.FileName;
                    if (hasAddedRecord == 1)
                    {
                        lblStep1.Font = new Font(lblStep1.Font, FontStyle.Regular);
                        lblStep2.Font = new Font(lblStep2.Font, FontStyle.Bold);
                        hasAddedRecord++;
                    }
                }
            }
        }

        /// <summary>
        /// Method displays the given message in the status bar. 
        /// It also resets the text color to Black indicating a normal message is being displayed.
        /// </summary>
        /// <param name="message">Message to display</param>
        private void showMessage(String message)
        {
            lblActivityStatusBar.Text = message;
            lblActivityStatusBar.ForeColor = Color.Black;
        }

        /// <summary>
        /// Method displays the given error in the status bar. 
        /// It also sets the text color to Red indicating an error message is being displayed.
        /// </summary>
        /// <param name="error">Message to display</param>
        private void showError(String error)
        {
            lblActivityStatusBar.Text = error;
            lblActivityStatusBar.ForeColor = Color.Red;
        }


        /// <summary>
        /// Method saves the records present in the analysis results dictionary on the storage media.
        /// <see cref="RecordManager{S, T}"/>
        /// <seealso cref="RecordManager{S, T}.writeRecords(Dictionary{S, T})"/>
        /// </summary>
        private void saveRecords(string fileName)
        {
            RecordManager<int, AnalysisResultItem> manager = new RecordManager<int, AnalysisResultItem>(fileName);
            manager.writeRecords(analysisResultDictionary);
            showMessage("File saved successfully!");
        }

        /// <summary>
        /// Method loads buyer records from the storage media, if present, in the buyer dictionary.
        /// <see cref="RecordManager{S, T}"/>
        /// <seealso cref="RecordManager{S, T}.readAllRecords"/>
        /// </summary>
        private bool loadRecords(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                return false;
            showMessage("Opening File..");
            RecordManager<string, Buyer> manager = new RecordManager<string, Buyer>(filePath);
            showMessage("Loading Records...");
            List<string> records = manager.readAllRecords();
            buyerDictionary.Clear();
            foreach (string record in records)
            {
                Buyer entity = new Buyer();
                if(!entity.populateBuyer(record))
                {
                    showError("Loaded file is either corrupt or of invalid format!");
                    buyerDictionary.Clear();
                    return false;
                }
                buyerDictionary.Add(entity.getFullName(), entity);
            }
            showMessage(buyerDictionary.Count + " record(s) loaded successfully!");
            return true;
        }

        /// <summary>
        /// Method analyzes the buyer records in the buyer dictionary and stores the analysis results in a buyer dictionary.
        /// </summary>
        private void loadAnalysisResults()
        {
            if(buyerDictionary != null && buyerDictionary.Count > 0)
            {
                analysisResultDictionary.Clear();
                double minEntryTime = -1, maxEntryTime = -1, avgEntryTime = -1;
                double minInterRecordTime = -1, maxInterRecordTime = -1, avgInterRecordTime = 0;
                double totalTime = 0;
                double errorCount = 0;
                Buyer lastBuyer = null;
                List<Buyer> buyerList = buyerDictionary.Values.ToList();
                foreach(Buyer buyer in buyerList)
                {
                    double entryTime = convertToSeconds(buyer.creationEndTime) - convertToSeconds(buyer.creationStartTime);
                    double interRecordTime = -1;
                    if(lastBuyer != null)
                    {
                        interRecordTime = convertToSeconds(buyer.creationStartTime) - convertToSeconds(lastBuyer.creationEndTime);
                    }
                    if(minEntryTime == -1 || minEntryTime > entryTime)
                    {
                        minEntryTime = entryTime;
                    }
                    if(maxEntryTime == -1 || maxEntryTime < entryTime)
                    {
                        maxEntryTime = entryTime;
                    }
                    if(interRecordTime != -1 && (minInterRecordTime == -1 || minInterRecordTime > interRecordTime))
                    {
                        minInterRecordTime = interRecordTime;
                    }
                    if(interRecordTime != -1 && (maxInterRecordTime == -1 || maxInterRecordTime < interRecordTime))
                    {
                        maxInterRecordTime = interRecordTime;
                    }
                    if(interRecordTime != -1)
                    {
                        avgInterRecordTime += interRecordTime;
                    }
                    totalTime += entryTime;
                    errorCount += buyer.creationErrorCount;
                    lastBuyer = buyer;
                }
                avgEntryTime = totalTime / buyerDictionary.Count;
                avgInterRecordTime = avgInterRecordTime / buyerDictionary.Count - 1;
                int counter = 0;
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.NUMBER_OF_RECORDS_LABEL, buyerDictionary.Count, buyerDictionary.Count.ToString()));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.MIN_ENTRY_TIME, minEntryTime, convertToString(minEntryTime)));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.MAX_ENTRY_TIME, maxEntryTime, convertToString(maxEntryTime)));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.AVG_ENTRY_TIME, avgEntryTime, convertToString(avgEntryTime)));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.MIN_INTER_RECORD_TIME, minInterRecordTime, convertToString(minInterRecordTime)));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.MAX_INTER_RECORD_TIME, maxInterRecordTime, convertToString(maxInterRecordTime)));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.AVG_INTER_RECORD_TIME, avgInterRecordTime, convertToString(avgInterRecordTime)));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.TOTAL_TIME, totalTime, convertToString(totalTime)));
                analysisResultDictionary.Add(counter++, new AnalysisResultItem(Constants.ERROR_COUNT, errorCount, errorCount.ToString()));
            }
        }

        /// <summary>
        /// Method populates the list view with analysis records present in the dictionary.
        /// </summary>
        private void populateListView()
        {
            ctlAnalysisResultsListView.Items.Clear();
            List<AnalysisResultItem> analysisResultList = analysisResultDictionary.Values.ToList();
            foreach (AnalysisResultItem analysisResult in analysisResultList)
            {
                string[] row = { analysisResult.observationLabel, analysisResult.observationStringValue };
                var listViewItem = new ListViewItem(row);
                try
                {
                    ctlAnalysisResultsListView.Items.Add(listViewItem);
                }
                catch (Exception e)
                {
                    Console.Out.Write(e.StackTrace);
                }
            }
            if (ctlAnalysisResultsListView.Items.Count > 0)
            {
                //Ensure that the newly added record at the end is always visible.
                ctlAnalysisResultsListView.EnsureVisible(ctlAnalysisResultsListView.Items.Count - 1);
            }
            ctlSaveFileAnalysis.Enabled = true;
        }

        /// <summary>
        /// Method converts string time to double seconds.
        /// </summary>
        /// <param name="time">The time as string.</param>
        /// <returns>Seconds as a double object.</returns>
        private double convertToSeconds(string time)
        {
            return TimeSpan.Parse(time).TotalSeconds;
        }

        /// <summary>
        /// Method converts double seconds to string time.
        /// </summary>
        /// <param name="seconds">The time as seconds.</param>
        /// <returns>Time as a string object.</returns>
        private string convertToString(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Save file button click event handler method.
        /// Starts the SaveFileDialog and get the path and file name to save analysis records.
        /// Saves all the analysis results to a file.
        /// </summary>
        /// <param name="sender">The object whose click event is being handled</param>
        /// <param name="e">EventArgs object.</param>
        private void ctlSaveAnalysis_Click(object sender, EventArgs e)
        {
            if (hasAddedRecord == 4)
            {
                lblNotes.Font = new Font(lblNotes.Font, FontStyle.Regular);
                hasAddedRecord = 5;
            }
            DialogResult result = ctlSaveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(ctlSaveFileDialog.FileName))
                {
                    saveRecords(ctlSaveFileDialog.FileName);
                    if (hasAddedRecord == 3)
                    {
                        lblStep3.Font = new Font(lblStep3.Font, FontStyle.Regular);
                        lblNotes.Font = new Font(lblNotes.Font, FontStyle.Bold);
                        hasAddedRecord++;
                    }
                }
            }
        }

        /// <summary>
        /// Form load event handler method.
        /// Initializes the form controls <see cref="MainForm.initializeForm"/>;
        /// </summary>
        /// <param name="sender">The object whose on load event is being handled</param>
        /// <param name="e">EventArgs object.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            initializeForm();
        }

        /// <summary>
        /// Open file button click event handler method.
        /// Loads the records in a dictionary <see cref="MainForm.loadRecords"/>;
        /// Compute and load the analysis results in a dictionary <see cref="MainForm.loadAnalysisResults"/>;
        /// Populates the list view with loaded analysis result data <see cref="MainForm.populateListView"/>.
        /// </summary>
        /// <param name="sender">The object whose click event is being handled</param>
        /// <param name="e">EventArgs object.</param>
        private void ctlOpenFile_Click(object sender, EventArgs e)
        {
            if (hasAddedRecord == 4)
            {
                lblNotes.Font = new Font(lblNotes.Font, FontStyle.Regular);
                hasAddedRecord = 5;
            }
            if (!String.IsNullOrWhiteSpace(buyerFileName))
            {
                if (System.IO.File.Exists(buyerFileName))
                {
                    if (loadRecords(buyerFileName))
                    {
                        showMessage("Analyzing Records...");
                        loadAnalysisResults();
                        showMessage("Analyses complete successfully!. Populating analysis...");
                        populateListView();
                        showMessage("Populated analysis successfully!");
                        if (hasAddedRecord == 2)
                        {
                            lblStep2.Font = new Font(lblStep2.Font, FontStyle.Regular);
                            lblStep3.Font = new Font(lblStep3.Font, FontStyle.Bold);
                            hasAddedRecord++;
                        }
                    }
                }
                else
                {
                    showError("File not found!");
                }
            }
            else
            {
                showError("Kindly select a file to open or provide a file path!");
            }
        }

        /// <summary>
        /// TextChange event handler method.
        /// Updates the buyer records file path.
        /// </summary>
        /// <param name="sender">The object whose TextChange event is being handled</param>
        /// <param name="e">EventArgs object.</param>
        private void ctlFilePath_TextChanged(object sender, EventArgs e)
        {
            buyerFileName = ctlFilePath.Text;
            if(hasAddedRecord == 4)
            {
                lblNotes.Font = new Font(lblNotes.Font, FontStyle.Regular);
                hasAddedRecord = 5;
            }
        }
    }
}
