using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
using ParsingBLSData.Model;
using System.Windows;

namespace ParsingBLSData.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public string Welcome
        {
            get
            {
                return "Welcome to MVVM Light";
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                if (ParsingBLSData.Properties.Settings.Default.InputFileName != null &&
                    ParsingBLSData.Properties.Settings.Default.InputFileName != "")
                {
                    InputFileName = ParsingBLSData.Properties.Settings.Default.InputFileName;
                }

                if (ParsingBLSData.Properties.Settings.Default.OutputFileName != null &&
                    ParsingBLSData.Properties.Settings.Default.OutputFileName != "")
                {
                    OutputFileName = ParsingBLSData.Properties.Settings.Default.OutputFileName;
                }
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        #region Notify Properties

        #region InputFileName (string)
        /// <summary>
        /// The <see cref="InputFileName" /> property's name.
        /// </summary>
        public const string InputFileNamePropertyName = "InputFileName";

        private string _inputFileName = "";

        /// <summary>
        /// Gets the InputFileName property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public string InputFileName
        {
            get
            {
                return _inputFileName;
            }

            set
            {
                if (_inputFileName == value)
                {
                    return;
                }

                var oldValue = _inputFileName;
                _inputFileName = value;

                ParsingBLSData.Properties.Settings.Default.InputFileName = value;
                ParsingBLSData.Properties.Settings.Default.Save();

                // Update bindings, no broadcast
                RaisePropertyChanged(InputFileNamePropertyName);
            }
        }
        #endregion

        #region OutputFileName (string)
        /// <summary>
        /// The <see cref="OutputFileName" /> property's name.
        /// </summary>
        public const string OutputFileNamePropertyName = "OutputFileName";

        private string _outputFileName = "";

        /// <summary>
        /// Gets the OutputFileName property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public string OutputFileName
        {
            get
            {
                return _outputFileName;
            }

            set
            {
                if (_outputFileName == value)
                {
                    return;
                }

                var oldValue = _outputFileName;
                _outputFileName = value;
                ParsingBLSData.Properties.Settings.Default.OutputFileName = value;
                ParsingBLSData.Properties.Settings.Default.Save();
                // Update bindings, no broadcast
                RaisePropertyChanged(OutputFileNamePropertyName);
            }
        }
        #endregion

        #region IsBulkButtonVisible (Visibility)
        /// <summary>
        /// The <see cref="IsBulkButtonVisible" /> property's name.
        /// </summary>
        public const string IsBulkButtonVisiblePropertyName = "IsBulkButtonVisible";

        private Visibility _isBulkButtonVisisble = Visibility.Collapsed;

        /// <summary>
        /// Gets the IsBulkButtonVisible property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public Visibility IsBulkButtonVisible
        {
            get
            {
                return _isBulkButtonVisisble;
            }

            set
            {
                if (_isBulkButtonVisisble == value)
                {
                    return;
                }

                var oldValue = _isBulkButtonVisisble;
                _isBulkButtonVisisble = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(IsBulkButtonVisiblePropertyName);
            }
        }
        #endregion

        #region IsStateIndustryVisible (Visibility)
        /// <summary>
        /// The <see cref="IsStateIndustryVisible" /> property's name.
        /// </summary>
        public const string IsStateIndustryVisiblePropertyName = "IsStateIndustryVisible";

        private Visibility _isStateIndustryVisisble = Visibility.Collapsed;

        /// <summary>
        /// Gets the IsStateIndustryVisible property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public Visibility IsStateIndustryVisible
        {
            get
            {
                return _isStateIndustryVisisble;
            }

            set
            {
                if (_isStateIndustryVisisble == value)
                {
                    return;
                }

                var oldValue = _isStateIndustryVisisble;
                _isStateIndustryVisisble = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(IsStateIndustryVisiblePropertyName);
            }
        }
        #endregion

        #region IsMetroEmployVisible (Visibility)
        /// <summary>
        /// The <see cref="IsMetroEmployVisible" /> property's name.
        /// </summary>
        public const string IsMetroEmployVisiblePropertyName = "IsMetroEmployVisible";

        private Visibility _isMetroEmployVisible = Visibility.Collapsed;

        /// <summary>
        /// Gets the IsMetroEmployVisible property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public Visibility IsMetroEmployVisible
        {
            get
            {
                return _isMetroEmployVisible;
            }

            set
            {
                if (_isMetroEmployVisible == value)
                {
                    return;
                }

                var oldValue = _isMetroEmployVisible;
                _isMetroEmployVisible = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(IsMetroEmployVisiblePropertyName);
            }
        }
        #endregion

        #region DisplayDataType (string)
        /// <summary>
        /// The <see cref="DisplayDataType" /> property's name.
        /// </summary>
        public const string DisplayDataTypePropertyName = "DisplayDataType";

        private string _displayDataType = "";

        /// <summary>
        /// Gets the DisplayDataType property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public string DisplayDataType
        {
            get
            {
                return _displayDataType;
            }

            set
            {
                if (_displayDataType == value)
                {
                    return;
                }

                var oldValue = _displayDataType;
                _displayDataType = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(DisplayDataTypePropertyName);
            }
        }
        #endregion

        #endregion  

        #region RemakeBLSData (Read/Write Async Command)
        // Using BLSStatus to report the status
        #region BLSStatus (string)
        /// <summary>
        /// The <see cref="BLSStatus" /> property's name.
        /// </summary>
        public const string BLSStatusPropertyName = "BLSStatus";

        private string __blsStatus = "Waiting";

        public string BLSStatus
        {
            get
            {
                return __blsStatus;
            }

            set
            {
                if (__blsStatus == value)
                {
                    return;
                }

                var oldValue = __blsStatus;
                __blsStatus = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(BLSStatusPropertyName);
            }
        }
        #endregion

        BackgroundWorker blsBackWorker;

        public ICommand RemakeBLSData
        {
            get
            {
                return new RelayCommand(() =>
                {
                    
                    blsBackWorker = new BackgroundWorker();
                    blsBackWorker.DoWork +=new DoWorkEventHandler(blsBackWorker_DoWork);
                    blsBackWorker.WorkerReportsProgress = true;
                    blsBackWorker.ProgressChanged += new ProgressChangedEventHandler(blsBackWorker_ProgressChanged);
                    blsBackWorker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(blsBackWorker_RunWorkerCompleted);
                    blsBackWorker.RunWorkerAsync();
                });
            }
        }

        void  blsBackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.IO.StreamWriter outputFile = new System.IO.StreamWriter(OutputFileName, true);
            Dictionary<string, Dictionary<DateTime, BLSValue>> bulkDataHolder = new Dictionary<string, Dictionary<DateTime, BLSValue>>();
            List<DateTime> possibleDates = new List<DateTime>();
            
            int countFromAdjust = 0;
            string dataType = "";
            
            using (Stream stream = File.Open(InputFileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bool nextIsTitle = false;
                    int titleCount = 0;
                    string currentSeries = "";
                    do
                    {
                        string raw = reader.ReadLine();
                        string[] values = raw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		                
                        //Find out what metric we're looking at
                        // This will need to be tweaked on a case by case basis
                        if (nextIsTitle)
                        {
                            //if (titleCount == 1)
                            //{
                            #region for employment Data
                            if(dataType == "ATables"){
                                if (titleCount == 0 )
                                {
                                    string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (titleValues.Length == 2)
                                    {
                                        currentSeries = titleValues[1].Trim();
                                        bulkDataHolder.Add(currentSeries, new Dictionary<DateTime, BLSValue>());
                                    }
                                    nextIsTitle = false;
                                }
                            }
                            #endregion

                            #region For Industry Data
                            if (dataType == "BTables")
                            {
                                if (titleCount == 1)
                                {
                                    string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (titleValues.Length == 2)
                                    {
                                        currentSeries = currentSeries + " - " + titleValues[1].Trim().Replace(',', '/').Trim();
                                        if (!bulkDataHolder.ContainsKey(currentSeries))
                                            bulkDataHolder.Add(currentSeries, new Dictionary<DateTime, BLSValue>());
                                    }
                                    nextIsTitle = false;
                                    titleCount++;
                                }
                                else if (titleCount == 0)
                                {
                                    string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (titleValues.Length == 2)
                                        currentSeries = titleValues[1].Replace(',', '/').Trim();
                                    titleCount++;
                                }
                            }
                            #endregion

                            #region for state industry data
                            if (dataType == "stateIndustry")
                            {
                                if (titleCount == 3 && dataType == "stateIndustry")
                                {
                                    string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (titleValues.Length == 2)
                                    {
                                        currentSeries = currentSeries + " - " + titleValues[1].Trim().Replace(',', '/');
                                        if (!bulkDataHolder.ContainsKey(currentSeries))
                                            bulkDataHolder.Add(currentSeries, new Dictionary<DateTime, BLSValue>());
                                    }
                                    nextIsTitle = false;
                                }
                                else if (titleCount == 0)
                                {
                                    string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (titleValues.Length == 2)
                                        currentSeries = titleValues[1].Replace(',', '/');
                                    titleCount++;
                                }
                                else
                                {
                                    titleCount++;
                                }
                            }
                            #endregion

                            #region for state employment data
                            if(dataType == "stateEmployment"){
                                if (titleCount == 2 )
                                {
                                    string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (titleValues.Length == 2)
                                    {
                                        currentSeries = currentSeries + " - " + titleValues[1].Trim().Replace(',', '/');
                                        if (!bulkDataHolder.ContainsKey(currentSeries))
                                            bulkDataHolder.Add(currentSeries, new Dictionary<DateTime, BLSValue>());
                                    }
                                    nextIsTitle = false;
                                }
                                else if (titleCount == 0)
                                {
                                    string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (titleValues.Length == 2)
                                        currentSeries = titleValues[1].Replace(',', '/').Trim();
                                    titleCount++;
                                }
                                else
                                {
                                    titleCount++;
                                }
                            }
                            #endregion
                        }

                        // Find what kind of data we're looking at
                        if (raw.Contains("Force Statistics from the Current Population Survey"))
                        {
                            // A Tables (household data)
                            dataType = "ATables";
                        }
                        else if (raw.Contains("from the Current Employment Statistics survey (National)"))
                        {
                            // B Tables (industry data)
                            dataType = "BTables";
                        }

                        else if (raw.Contains("Area Employment, Hours, and Earnings"))
                        {
                            dataType = "stateIndustry";
                        }
                        else if (raw.Contains("Area Unemployment Statistics"))
                        {
                            dataType = "stateEmployment";
                        }

                        //Whatever is under "Seasonally Adjusted" 
                        if (raw.Contains("Seasonally Adjusted") || raw == "Seasonally Adjusted")
                        {
                            nextIsTitle = true;
                            titleCount = 0;
                        } 

                        // Now we can look at the data
                        if (values.Length == 4 && values[0] != "Series id" && values[0] != "Series Id")
                        {
                            currentSeries = currentSeries.Trim();
                            BLSValue blsVal = new BLSValue(currentSeries, values[0], values[1], values[2], values[3]);
                            if (!blsVal.IsAnualData)
                            {
                                if (!bulkDataHolder.ContainsKey(currentSeries))
                                    bulkDataHolder.Add(currentSeries, new Dictionary<DateTime, BLSValue>());
                                bulkDataHolder[currentSeries].Add(blsVal.ValueDate, blsVal);
                                if (!possibleDates.Contains(blsVal.ValueDate))
                                    possibleDates.Add(blsVal.ValueDate);
                            }
                        }

                    } while (reader.Peek() != -1);

                    //Now we should have all the data, so let's start writing it out

                    // First we need headers
                    string headerData = "Date";
                    foreach (KeyValuePair<string, Dictionary<DateTime, BLSValue>> kv in bulkDataHolder)
                    {
                        headerData = headerData + "," + kv.Key.Replace(',', ' ');
                    }
                    outputFile.WriteLine(headerData);
                    // Then we need to sort our dates (just in case)
                    var sortedDates = from date in possibleDates
                                        orderby date ascending
                                        select date;
                        
                    // 
                        
                    foreach (DateTime d in sortedDates)
                    {
                        string writeDateLine = "" + d.Month + "/" + d.Day + "/" + d.Year;
                        foreach (KeyValuePair<string, Dictionary<DateTime, BLSValue>> kv in bulkDataHolder)
                        {
                            writeDateLine = writeDateLine + ",";
                            if (kv.Value.ContainsKey(d))
                            {
                                writeDateLine = writeDateLine + kv.Value[d].Value;
                            }
                        }
                        outputFile.WriteLine(writeDateLine);
                    }
                    outputFile.Close();
                }
            }
        }

        void blsBackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DateTime reportDateParse = (DateTime)e.UserState;
            BLSStatus = reportDateParse.ToString();
        }

        void blsBackWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BLSStatus = "BLS translation complete";
        }


        #endregion

        #region SortBLSStateIndustry (Read/Write Async Command)
        // Using BLSStateIndustryStatus to report the status
        #region BLSStateIndustryStatus (string)
        /// <summary>
        /// The <see cref="BLSStateIndustryStatus" /> property's name.
        /// </summary>
        public const string BLSStateIndustryStatusPropertyName = "BLSStateIndustryStatus";

        private string _blsStateIndustryStatus = "Waiting...";

        public string BLSStateIndustryStatus
        {
            get
            {
                return _blsStateIndustryStatus;
            }

            set
            {
                if (_blsStateIndustryStatus == value)
                {
                    return;
                }

                var oldValue = _blsStateIndustryStatus;
                _blsStateIndustryStatus = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(BLSStateIndustryStatusPropertyName);
            }
        }
        
        #endregion

        BackgroundWorker blsStateBackWorker;

        public ICommand SortBLSStateIndustry
        {
            get
            {
                return new RelayCommand(() =>
                {
                    
                    blsStateBackWorker = new BackgroundWorker();
                    blsStateBackWorker.DoWork +=new DoWorkEventHandler(blsStateBackWorker_DoWork);
                    blsStateBackWorker.WorkerReportsProgress = true;
                    blsStateBackWorker.ProgressChanged += new ProgressChangedEventHandler(blsStateBackWorker_ProgressChanged);
                    blsStateBackWorker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(blsStateBackWorker_RunWorkerCompleted);
                    blsStateBackWorker.RunWorkerAsync();
                });
            }
        }

        void  blsStateBackWorker_DoWork(object sender, DoWorkEventArgs e)
        {   
            System.IO.StreamWriter outputFile = new System.IO.StreamWriter(OutputFileName, true);
            Dictionary<string, Dictionary<DateTime, BLSValue>> bulkDataHolder = new Dictionary<string, Dictionary<DateTime, BLSValue>>();
            List<DateTime> possibleDates = new List<DateTime>();
            Dictionary<string, StreamWriter> outputFiles = new Dictionary<string, StreamWriter>();
            Dictionary<string, string> industryOutputs = new Dictionary<string, string>();

            int countFromAdjust = 0;
            
            using (Stream stream = File.Open(InputFileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bool nextIsTitle = false;
                    int titleCount = 0;
                    string currentSeries = "";
                    
                    do
                    {
                        string raw = reader.ReadLine();
                        string[] values = raw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        //Find out what metric we're looking at
                        // This will need to be tweaked on a case by case basis
                        if (nextIsTitle)
                        {
                            #region for state industry data
                            if (titleCount == 3)
                            {
                                string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                if (titleValues.Length == 2)
                                {
                                    string industry = titleValues[1].Trim().Replace(',', '_');
                                    if (!outputFiles.ContainsKey(industry))
                                    {
                                        string newFilePath = OutputFileName.Insert(OutputFileName.Length - 4, industry);
                                        outputFiles.Add(industry, new StreamWriter(newFilePath, true));
                                    }

                                    currentSeries = currentSeries + " - " + industry;
                                    if (!bulkDataHolder.ContainsKey(currentSeries))
                                        bulkDataHolder.Add(currentSeries, new Dictionary<DateTime, BLSValue>());
                                }
                                nextIsTitle = false;
                            }
                            else if (titleCount == 0)
                            {
                                string[] titleValues = raw.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                if (titleValues.Length == 2)
                                    currentSeries = titleValues[1].Replace(',', '/');
                                titleCount++;
                            }
                            else
                            {
                                titleCount++;
                            }
                            #endregion
                        }

                        //Whatever is under "Seasonally Adjusted" 
                        if (raw.StartsWith("Seasonally Adjusted"))
                        {
                            nextIsTitle = true;
                            titleCount = 0;
                        }

                        // Now we can look at the data
                        if (values.Length == 4 && values[0] != "Series id" && values[0] != "Series Id")
                        {
                            BLSValue blsVal = new BLSValue(currentSeries, values[0], values[1], values[2], values[3]);
                            bulkDataHolder[currentSeries].Add(blsVal.ValueDate, blsVal);
                            if (!possibleDates.Contains(blsVal.ValueDate))
                                possibleDates.Add(blsVal.ValueDate);
                        }

                    } while (reader.Peek() != -1);

                    //Now we should have all the data, so let's start writing it out

                    // First we need headers for the big file
                    string headerData = "Date";
                    foreach (KeyValuePair<string, Dictionary<DateTime, BLSValue>> kv in bulkDataHolder)
                    {
                        headerData = headerData + "," + kv.Key.Replace(',', ' ');
                        string[] indParse = kv.Key.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                        if (!industryOutputs.ContainsKey(indParse[1]))
                            industryOutputs.Add(indParse[1], "Year," + indParse[0].Replace(',', ' '));
                        else
                            industryOutputs[indParse[1]] = industryOutputs[indParse[1]] + "," + indParse[0];
                    }
                    outputFile.WriteLine(headerData);

                    foreach (KeyValuePair<string, string> kv in industryOutputs)
                    {
                        if (outputFiles.ContainsKey(kv.Key))
                        {
                            outputFiles[kv.Key].WriteLine(kv.Value);
                        }
                    }
                    
                    // Then we need to sort our dates (just in case)
                    var sortedDates = from date in possibleDates
                                      orderby date ascending
                                      select date;
                    // 

                    foreach (DateTime d in sortedDates)
                    {
                        string writeDateLine = "" + d.Month + "/" + d.Day + "/" + d.Year;
                        string yearStart = "" + d.Month + "/" + d.Day + "/" + d.Year;
                        industryOutputs = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, Dictionary<DateTime, BLSValue>> kv in bulkDataHolder)
                        {
                            writeDateLine = writeDateLine + ",";
                            if (kv.Value.ContainsKey(d))
                                writeDateLine = writeDateLine + kv.Value[d].Value;
                            string[] indParse = kv.Key.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                            string industryLine = ""; 
                            if (kv.Value.ContainsKey(d))
                                industryLine = "," + kv.Value[d].Value;
                            else 
                                industryLine = ",";
                            if (industryOutputs.ContainsKey(indParse[1]))
                            {
                                industryOutputs[indParse[1]] = industryOutputs[indParse[1]] + industryLine;
                            }
                            else
                            {
                                industryOutputs.Add(indParse[1], yearStart + industryLine);
                            }
                        }

                        foreach(KeyValuePair<string, string> kvp in industryOutputs)
                        {
                            if(outputFiles.ContainsKey(kvp.Key))
                                outputFiles[kvp.Key].WriteLine(kvp.Value);
                        }

                        outputFile.WriteLine(writeDateLine);
                    }

                    foreach(KeyValuePair<string, StreamWriter> kvp in outputFiles)
                    {
                        kvp.Value.Close();
                    }

                    outputFile.Close();
                }
            }
        }

        void blsStateBackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DateTime reportDateParse = (DateTime)e.UserState;
            BLSStateIndustryStatus = reportDateParse.ToString();
        }

        void blsStateBackWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BLSStateIndustryStatus = "BLS State Industry Parsing Complete";
        }


        #endregion
        
        #region ParseMetroEmployment (Read/Write Async Command)

        // Using MetroAsyncStatus to report the status

        #region MetroAsyncStatus (string)
        /// <summary>
        /// The <see cref="MetroAsyncStatus" /> property's name.
        /// </summary>
        public const string MetroAsyncStatusPropertyName = "MetroAsyncStatus";

        private string _metroAsyncStatus = "Waiting for Metro Input";

        public string MetroAsyncStatus
        {
            get
            {
                return _metroAsyncStatus;
            }

            set
            {
                if (_metroAsyncStatus == value)
                {
                    return;
                }

                var oldValue = _metroAsyncStatus;
                _metroAsyncStatus = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(MetroAsyncStatusPropertyName);
            }
        }
        #endregion

        BackgroundWorker metroBackWorker;

        public ICommand ParseMetroEmployment
        {
            get
            {
                return new RelayCommand(() =>
                {
                    
                    metroBackWorker = new BackgroundWorker();
                    metroBackWorker.DoWork +=new DoWorkEventHandler(metroBackWorker_DoWork);
                    metroBackWorker.WorkerReportsProgress = true;
                    metroBackWorker.ProgressChanged += new ProgressChangedEventHandler(metroBackWorker_ProgressChanged);
                    metroBackWorker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(metroBackWorker_RunWorkerCompleted);
                    metroBackWorker.RunWorkerAsync();
                });
            }
        }

        void  metroBackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime earliestDatetime = DateTime.Now;
            List<MetroDataPoint> listOfData = new List<MetroDataPoint>();
            List<DateTime> listofDates = new List<DateTime>();
            List<string> listofMetros = new List<string>();

            using (Stream stream = File.Open(InputFileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    do
                    {
                        string raw = reader.ReadLine();
                        string[] values = raw.Split(new string[]{"  "}, StringSplitOptions.RemoveEmptyEntries);
                        metroBackWorker.ReportProgress(10, "Reading...");
                        if (values.Length == 10 && values[0].StartsWith("MT"))
                        {
                            MetroDataPoint thisDataPoint = new MetroDataPoint(values[0].Trim(), values[1].Trim(),
                                                                            values[2].Trim(), values[3].Trim(),
                                                                            values[4].Trim(), values[5].Trim(),
                                                                            values[6].Trim(), values[7].Trim(),
                                                                            values[8].Trim(), values[9].Trim());
                            listOfData.Add(thisDataPoint);
                            
                            if (!listofDates.Contains(thisDataPoint.DateOfData))
                                listofDates.Add(thisDataPoint.DateOfData);
                            if (!listofMetros.Contains(thisDataPoint.Area))
                                listofMetros.Add(thisDataPoint.Area);

                        }
                    } while (reader.Peek() != -1);

                    System.IO.StreamWriter outputFileLF = new System.IO.StreamWriter(OutputFileName.Insert(OutputFileName.Length-4, "_LaborForce"), true);
                    System.IO.StreamWriter outputFileE = new System.IO.StreamWriter(OutputFileName.Insert(OutputFileName.Length-4, "_Employment"), true);
                    System.IO.StreamWriter outputFileUE = new System.IO.StreamWriter(OutputFileName.Insert(OutputFileName.Length-4, "_Unemployment"), true);
                    System.IO.StreamWriter outputFileUER = new System.IO.StreamWriter(OutputFileName.Insert(OutputFileName.Length-4, "_UnempoymentRate"), true);
                    // Write headers
                    string header = "Date";
                    foreach (string metro in listofMetros)
                    {
                        header = header + "," + metro;
                    }

                    outputFileLF.WriteLine(header);
                    outputFileE.WriteLine(header);
                    outputFileUE.WriteLine(header);
                    outputFileUER.WriteLine(header);

                    foreach (DateTime dt in listofDates)
                    {
                        string laborLine = "" + dt.Month.ToString() +"/" + dt.Day.ToString() + "/" + dt.Year.ToString();
                        string employLine = laborLine;
                        string unemployLine = laborLine;
                        string unemployRateLine = laborLine;

                        metroBackWorker.ReportProgress(80, "Date: " + dt.Year.ToString() + "/" + dt.Month.ToString());

                        foreach (string metro in listofMetros)
                        {
                            bool hasValue = false;
                            foreach (MetroDataPoint mdp in listOfData)
                            {
                                if(mdp.DateOfData == dt && mdp.Area == metro)
                                {
                                    laborLine = laborLine + "," + mdp.CivilianLaborForce.ToString("N0").Replace(",", "");
                                    unemployLine = unemployLine + "," + mdp.Unemployment.ToString("N0").Replace(",", "");
                                    unemployRateLine = unemployRateLine + "," + mdp.UnempoymentRate.ToString("N1").Replace(",", "");
                                    employLine = employLine + "," + mdp.Employment.ToString("N0").Replace(",", "");
                                    hasValue = true;
                                    break;
                                }
                            }

                            if (!hasValue)
                            {
                                laborLine = laborLine + ",";
                                unemployLine = unemployLine + ",";
                                unemployRateLine = unemployRateLine + ",";
                                employLine = employLine + ",";
                            }
                        }

                        outputFileLF.WriteLine(laborLine);
                        outputFileE.WriteLine(employLine);
                        outputFileUE.WriteLine(unemployLine);
                        outputFileUER.WriteLine(unemployRateLine);
                    }

                    outputFileLF.Close();
                    outputFileE.Close();
                    outputFileUE.Close();
                    outputFileUER.Close();
                }
            }
        }

        void metroBackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string reportDateParse = e.UserState.ToString();
            MetroAsyncStatus = reportDateParse.ToString();
        }

        void metroBackWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MetroAsyncStatus = "Metro work complete";
        }

        #endregion

        #region DetermineDataType (Read/Write Async Command)
        // Using DataTypeFilterResult to report the status
        #region DataTypeFilterResult (string)
        /// <summary>
        /// The <see cref="DataTypeFilterResult" /> property's name.
        /// </summary>
        public const string DataTypeFilterResultPropertyName = "DataTypeFilterResult";

        private string _dataTypeFilterResult = "Waiting...";

        public string DataTypeFilterResult
        {
            get
            {
                return _dataTypeFilterResult;
            }

            set
            {
                if (_dataTypeFilterResult == value)
                {
                    return;
                }

                if (value == "ATables")
                {
                    IsBulkButtonVisible = Visibility.Visible;
                    IsStateIndustryVisible = Visibility.Collapsed;
                    IsMetroEmployVisible = Visibility.Collapsed;
                    DisplayDataType = "A Table Conversion";
                } else if (value == "BATables"){
                    IsBulkButtonVisible = Visibility.Visible;
                    IsStateIndustryVisible = Visibility.Collapsed;
                    IsMetroEmployVisible = Visibility.Collapsed;
                    DisplayDataType = "B Table Conversion";
                } else if (value == "stateIndustry"){
                    IsBulkButtonVisible = Visibility.Visible;
                    IsStateIndustryVisible = Visibility.Visible;
                    IsMetroEmployVisible = Visibility.Collapsed;
                    DisplayDataType = "State Industry Conversion";
                } else if (value == "stateEmployment"){
                    IsBulkButtonVisible = Visibility.Visible;
                    IsStateIndustryVisible = Visibility.Collapsed;
                    IsMetroEmployVisible = Visibility.Collapsed;
                    DisplayDataType = "State Employment/Unemployment Conversion";
                } else if (value == "metroEmployment"){
                    IsBulkButtonVisible = Visibility.Collapsed;
                    IsStateIndustryVisible = Visibility.Collapsed;
                    IsMetroEmployVisible = Visibility.Visible;
                    DisplayDataType = "Metro Area Employment/Unemployment Conversion";
                }
                
                var oldValue = _dataTypeFilterResult;
                _dataTypeFilterResult = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(DataTypeFilterResultPropertyName);
            }
        }
        #endregion

        BackgroundWorker DataTypeWorker;

        public ICommand DetermineDataType
        {
            get
            {
                return new RelayCommand(() =>
                {
                    
                    DataTypeWorker = new BackgroundWorker();
                    DataTypeWorker.DoWork +=new DoWorkEventHandler(DataTypeWorker_DoWork);
                    DataTypeWorker.WorkerReportsProgress = true;
                    DataTypeWorker.ProgressChanged += new ProgressChangedEventHandler(DataTypeWorker_ProgressChanged);
                    DataTypeWorker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(DataTypeWorker_RunWorkerCompleted);
                    DataTypeWorker.RunWorkerAsync();
                });
            }
        }

        void  DataTypeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            using (Stream stream = File.Open(InputFileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    int line = 0;
                    string dataType = "";
                    do
                    {
                        string raw = reader.ReadLine();
                        string[] values = raw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        // Find what kind of data we're looking at
                        if (raw.Contains("Force Statistics from the Current Population Survey"))
                        {
                            // A Tables (household data)
                            dataType = "ATables";
                        }
                        else if (raw.Contains("from the Current Employment Statistics survey (National)"))
                        {
                            // B Tables (industry data)
                            dataType = "BATables";
                        }

                        else if (raw.Contains("Area Employment, Hours, and Earnings"))
                        {
                            dataType = "stateIndustry";
                        }
                        else if (raw.Contains("Area Unemployment Statistics"))
                        {
                            dataType = "stateEmployment";
                        }
                        else if (raw.Contains("unemployment by metropolitan area"))
                        {
                            dataType = "metroEmployment";
                        }

                        if (line > 30)
                            break;
                        else
                            line++;

		                DataTypeWorker.ReportProgress(0, dataType);

                    } while (reader.Peek() != -1);

           
                }
            }
        }

        void DataTypeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string reportDateParse = (string)e.UserState;
            DataTypeFilterResult = reportDateParse;
        }

        void DataTypeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTypeFilterResult = "Background work complete";
        }


        #endregion

        #region SelectInputFile & SelectOutputFile (Input/Output File Dialog)

        public ICommand SelectInputFile
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Microsoft.Win32.OpenFileDialog inputFile = new Microsoft.Win32.OpenFileDialog();
                    inputFile.InitialDirectory = ParseDirectory(InputFileName);

                    Nullable<bool> result = inputFile.ShowDialog();

                    if (result == true)
                    {
                        InputFileName = inputFile.FileName;
                        DetermineDataType.Execute(null);
                    }
                });
            }
        }

        public ICommand SelectOutputFile
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Microsoft.Win32.SaveFileDialog outputFile = new Microsoft.Win32.SaveFileDialog();
                    outputFile.FileName = "DefaultOutput"; // Default file name
                    outputFile.DefaultExt = ".csv"; // Default file extension
                    outputFile.Filter = "Comma Seperated Values (.csv)|*.csv"; // Filter files by extension
                    outputFile.InitialDirectory = ParseDirectory(InputFileName);

                    Nullable<bool> result = outputFile.ShowDialog();

                    if (result == true)
                    {
                        OutputFileName = outputFile.FileName;
                    }
                });
            }
        }

        private string ParseDirectory(string pointer)
        {
            string returnValue = "";
            string[] returnParts;
            if (pointer.EndsWith(".csv"))
            {
                returnParts = pointer.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < returnParts.Length - 1; i++)
                {
                    returnValue = returnValue + "//";
                }
            }
            else
            {
                returnValue = pointer;
            }

            return returnValue;
        }
        #endregion
    

    }
}