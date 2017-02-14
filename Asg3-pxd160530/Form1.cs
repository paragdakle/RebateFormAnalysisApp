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
    public partial class Form1 : Form
    {
        Dictionary<string, Buyer> buyerDictionary;
        Dictionary<int, AnalysisResultItem> analysisResultDictionary;
        string buyerFileName = "";

        public Form1()
        {
            InitializeComponent();
            buyerDictionary = new Dictionary<string, Buyer>();
            analysisResultDictionary = new Dictionary<int, AnalysisResultItem>();
        }

        private void initializeForm()
        {
            ctlFilePath.Text = "";
            ctlOpenFileBrowser.Enabled = true;
            ctlSaveFileAnalysis.Enabled = false;
        }

        private void ctlOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = ctlOpenFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(ctlOpenFileDialog.FileName))
                {
                    ctlFilePath.Text = ctlOpenFileDialog.FileName;
                    
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
        /// Method saves the records present in the buyer dictionary on the storage media.
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
        private void loadRecords(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                return;
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
                    return;
                }
                buyerDictionary.Add(entity.getFullName(), entity);
            }
            showMessage(buyerDictionary.Count + " record(s) loaded successfully!");
        }

        /// <summary>
        /// Method loads the analysis results in a dictionary.
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

        private void populateListView()
        {
            ctlAnalysisResultsListView.Items.Clear();
            List<Buyer> buyerList = buyerDictionary.Values.ToList();
            foreach (Buyer buyer in buyerList)
            {
                string[] row = { buyer.getFullName(), buyer.phoneNumber };
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

        private double convertToSeconds(string time)
        {
            return TimeSpan.Parse(time).TotalSeconds;
        }

        private string convertToString(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
        }

        private void ctlSaveAnalysis_Click(object sender, EventArgs e)
        {
            DialogResult result = ctlSaveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(ctlSaveFileDialog.FileName))
                {
                    saveRecords(ctlSaveFileDialog.FileName);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializeForm();
        }

        private void ctlOpenFile_Click_1(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(buyerFileName))
            {
                if (System.IO.File.Exists(buyerFileName))
                {
                    loadRecords(buyerFileName);
                    showMessage("Analyzing Records...");
                    loadAnalysisResults();
                    showMessage("Analyses complete successfully!. Populating analysis...");
                    populateListView();
                    showMessage("Populated analysis successfully!");
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

        private void ctlFilePath_TextChanged(object sender, EventArgs e)
        {
            buyerFileName = ctlFilePath.Text;
        }
    }
}
