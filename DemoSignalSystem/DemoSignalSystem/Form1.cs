using System;
using System.IO;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace DemoSignalSystem
{
    public partial class Form1 : Form
    {
        //variable Declaration
        string userLevel;
        bool isRunning = true;
        double numSeconds = 0.0;
        double multiplier = 1.0;
        double trainCycleEndTime = -1;
        double tramCycleEndTime = -1;
        double dbl = 0.0;
        int lengthOfTrain = 0;
        int trainInstructionCounter = 0;
        int tramInstructionCounter = 0;
        int hours, minutes, seconds = 0;
        Random rand = new Random();
        List<double> trainCycleTimings = new List<double>();
        List<double> tramCycleTimings = new List<double>();
        List<string> trainCycleInstructions = new List<string>();
        List<string> tramCycleInstructions = new List<string>();
        string[] trainListOfCycles;
        string[] tramListOfCycles;
        string[] trainSplitInstruction;
        string[] tramSplitInstruction;
        string trainSelectedCycle = "TrainDefaultOperation";
        string tramSelectedCycle = "TramDefaultOperation";
        string trainFileName = "";
        string tramFileName = "";
        string trainCurrentInstruction = "";
        string tramCurrentInstruction = "";
        string trainSelectTrafficLight = "";
        string tramSelectTrafficLight = "";
        string trainSelectDirection = "";
        string tramSelectDirection = "";
        string trainSelectLightColor = "";
        string tramSelectLightColor = "";


        //Lights are set up as TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left, string type)

        //Lights for the overview map
        TrafficLight aLight = new TrafficLight(true, false, true, false, false, false, "car");
        TrafficLight bLight = new TrafficLight(true, false, false, false, true, false, "car");
        TrafficLight cLight = new TrafficLight(true, false, true, false, false, false, "car");
        TrafficLight dLight = new TrafficLight(true, false, false, false, true, false, "car");

        //Lights for the BD intersection
        TrafficLight a2Light = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight b2Light = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight c2Light = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight d2Light = new TrafficLight(true, false, true, false, true, false, "car");

        //Initialize the Timer that will keep track of light change timings
        System.Timers.Timer globalTimer = new System.Timers.Timer();

        public Form1(string cred)
        {
            InitializeComponent();
            initializeTrainCycleLists();
            initializeTramCycleLists();
            initializeTimer();
            userLevel = cred;
            initializePermissions(userLevel);
        }

        //Loads all the possible types of selectable cycles into the comboBox based on user permissions. Basic users only get the default operations
        public void initializeTrainCycleLists()
        {
            trainLightCycleComboBox.Items.Clear();
            trainListOfCycles = File.ReadAllLines("TrainListOfCycles.txt");
            if (userLevel != "user")
            {
                for (int i = 0; i < trainListOfCycles.Length; i++)
                {
                    trainLightCycleComboBox.Items.Add(trainListOfCycles[i]);
                }
                trainLightCycleComboBox.SelectedIndex = 0;
            }
            else
            {
                trainLightCycleComboBox.Items.Add(trainListOfCycles[0]);
                trainLightCycleComboBox.SelectedIndex = 0;
            }
        }

        public void initializeTramCycleLists()
        {
            tramLightCycleComboBox.Items.Clear();
            tramListOfCycles = File.ReadAllLines("TramListOfCycles.txt");
            if (userLevel != "user")
            {
                for (int i = 0; i < tramListOfCycles.Length; i++)
                {
                    tramLightCycleComboBox.Items.Add(tramListOfCycles[i]);
                }
                tramLightCycleComboBox.SelectedIndex = 0;
            }
            else
            {
                tramLightCycleComboBox.Items.Add(tramListOfCycles[0]);
                tramLightCycleComboBox.SelectedIndex = 0;
            }
        }

        //Initializes timer and sets the event interval equal to 1000ms or 1 second
        public void initializeTimer()
        {
            globalTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            globalTimer.Interval = 1000;
            globalTimer.Enabled = true;
        }

        //Start and stop the timer. Not really necessary, but w/e
        public void startTimer()
        {
            globalTimer.Start();
        }
        public void pauseTimer()
        {
            globalTimer.Stop();
        }

        //Manages the global timer. When the end of an instruction cycle occurs, the next instruction is triggered in here.
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            globalTimer.Interval = 1000 / multiplier;
            numSeconds += 1;
            if (numSeconds >= 3600.0)       //Manages the hour section of the timer
            {
                hours = Convert.ToInt32(Math.Floor(numSeconds / 3600.0));
                SetControlText(hoursTextBox2, hours.ToString());
                SetControlText(hoursTextBox, hours.ToString());
            }
            if (numSeconds >= 60.0)         //Manages the minutes section of the timer
            {
                minutes = Convert.ToInt32(Math.Floor((numSeconds / 60.0) % 60));
                SetControlText(minutesTextBox2, minutes.ToString());
                SetControlText(minutesTextBox, minutes.ToString());
            }
            seconds = Convert.ToInt32(Math.Floor(numSeconds % 60));   //Section section of timer

            SetControlText(secondsTextBox2, seconds.ToString());
            SetControlText(secondsTextBox, seconds.ToString());
            refreshLightImages();

            if (numSeconds == trainCycleEndTime && numSeconds == tramCycleEndTime)
            {
                interpretTrainInstruction();
                interpretTramInstruction();
            }
            else if (numSeconds == trainCycleEndTime)
            {
                interpretTrainInstruction();
            }
            else if (numSeconds == tramCycleEndTime)
            {
                interpretTramInstruction();
            }
        }

        //This method allows the timer to be displayed in the GUI. Need to invoke the proper control or the timer will not work in the GUI.
        public void SetControlText(Control control, string s)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<Control, string>(SetControlText), new object[] { control, s });
                }
                else
                {
                    control.Text = s;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Function that runs the operation text files.
        public void runTrainFile()
        {
            trainInstructionCounter = 0;
            trainCycleTimings.Clear();
            trainCycleInstructions.Clear();
            trainFileName = trainSelectedCycle + ".txt";
            string[] fileContents = File.ReadAllLines(trainFileName);

           
            //Populates the instruction lists with their respective timings
            for (int i = 0; i < fileContents.Length; i ++)
            {
               // textBoxOverpassCycle.Text += fileContents[i];
               // textBoxOverpassCycle.Text += "\r\n";
                if (i % 2 == 0)
                {
                    if (Double.TryParse(fileContents[i], out dbl))
                    {
                        trainCycleTimings.Add(dbl);
                    }
                    else
                    {
                        MessageBox.Show("Fatal error with reading file");
                        globalTimer.Stop();
                        globalTimer.Dispose();
                        Application.Exit();
                    }
                    trainCycleInstructions.Add(fileContents[i + 1]);
                }
            }

            //Preps the next instruction to be processed
            trainCycleEndTime = numSeconds + trainCycleTimings[trainInstructionCounter];
            trainCurrentInstruction = trainCycleInstructions[trainInstructionCounter];
            interpretTrainInstruction();
        }

        public void runTramFile()
        {
            tramInstructionCounter = 0;
            tramCycleTimings.Clear();
            tramCycleInstructions.Clear();
            tramFileName = tramSelectedCycle + ".txt";
            string[] fileContents2 = File.ReadAllLines(tramFileName);



            //Populates the instruction lists with their respective timings
            for (int i = 0; i < fileContents2.Length; i ++)
            {
                if (i % 2 == 0)
                {
                    if (Double.TryParse(fileContents2[i], out dbl))
                    {
                        tramCycleTimings.Add(dbl);
                    }
                    else
                    {
                        MessageBox.Show("Fatal error with reading file");
                        globalTimer.Stop();
                        globalTimer.Dispose();
                        Application.Exit();
                    }
                    tramCycleInstructions.Add(fileContents2[i + 1]);
                }


            }

            //Preps the next instruction to be processed
            tramCycleEndTime = numSeconds + tramCycleTimings[tramInstructionCounter];
            tramCurrentInstruction = tramCycleInstructions[tramInstructionCounter];
            interpretTramInstruction();
        }

        //Function that interprets each line of instructions in the Operation text files. Covers all combination of instructions that we should use
        public void interpretTrainInstruction()
        {
            trainSplitInstruction = trainCurrentInstruction.Split(null);
            for (int i = 0; i < trainSplitInstruction.Length; i++)
            {
                if (trainSplitInstruction[i] == "-")
                {
                    trainSelectTrafficLight = trainSplitInstruction[i + 1];
                    trainSelectDirection = trainSplitInstruction[i + 2];
                    trainSelectLightColor = trainSplitInstruction[i + 3];

                    if (trainSelectTrafficLight == "A" && trainSelectDirection == "forward" && trainSelectLightColor == "green")
                    {
                        aLight.forwardOn();
                        aLightButton.BackColor = Color.Green;

                    }
                    else if (trainSelectTrafficLight == "A" && trainSelectDirection == "right" && trainSelectLightColor == "green")
                    {
                        aLight.rightOn();
                        aRightButton.BackColor = Color.Green;
                    }

                    else if (trainSelectTrafficLight == "A" && trainSelectDirection == "forward" && trainSelectLightColor == "red")
                    {
                        aLight.forwardOff();
                        aLightButton.BackColor = Color.Red;
                    }
                    else if (trainSelectTrafficLight == "A" && trainSelectDirection == "right" && trainSelectLightColor == "red")
                    {
                        aLight.rightOff();
                        aRightButton.BackColor = Color.Red;

                    }
                    else if (trainSelectTrafficLight == "B" && trainSelectDirection == "forward" && trainSelectLightColor == "green")
                    {
                        bLight.forwardOn();
                        bLightButton.BackColor = Color.Green;
                    }
                    else if (trainSelectTrafficLight == "B" && trainSelectDirection == "right" && trainSelectLightColor == "green")
                    {
                        bLight.rightOn();

                    }
                    else if (trainSelectTrafficLight == "B" && trainSelectDirection == "left" && trainSelectLightColor == "green")
                    {
                        bLight.leftOn();
                        bLeftButton.BackColor = Color.Green;
                    }
                    else if (trainSelectTrafficLight == "B" && trainSelectDirection == "forward" && trainSelectLightColor == "red")
                    {
                        bLight.forwardOff();
                        bLightButton.BackColor = Color.Red;

                    }
                    else if (trainSelectTrafficLight == "B" && trainSelectDirection == "right" && trainSelectLightColor == "red")
                    {
                        bLight.rightOff();
                    }
                    else if (trainSelectTrafficLight == "B" && trainSelectDirection == "left" && trainSelectLightColor == "red")
                    {
                        bLight.leftOff();
                        bLeftButton.BackColor = Color.Red;
                    }
                    else if (trainSelectTrafficLight == "C" && trainSelectDirection == "forward" && trainSelectLightColor == "green")
                    {
                        cLight.forwardOn();
                        cLightButton.BackColor = Color.Green;
                    }
                    else if (trainSelectTrafficLight == "C" && trainSelectDirection == "right" && trainSelectLightColor == "green")
                    {
                        cLight.rightOn();
                        cRightButton.BackColor = Color.Green;
                    }
                    else if (trainSelectTrafficLight == "C" && trainSelectDirection == "left" && trainSelectLightColor == "green")
                    {
                        cLight.leftOn();
                    }
                    else if (trainSelectTrafficLight == "C" && trainSelectDirection == "forward" && trainSelectLightColor == "red")
                    {
                        cLight.forwardOff();
                        cLightButton.BackColor = Color.Red;
                    }
                    else if (trainSelectTrafficLight == "C" && trainSelectDirection == "right" && trainSelectLightColor == "red")
                    {
                        cLight.rightOff();
                        cRightButton.BackColor = Color.Red;
                    }
                    else if (trainSelectTrafficLight == "C" && trainSelectDirection == "left" && trainSelectLightColor == "red")
                    {
                        cLight.leftOff();
                    }
                    else if (trainSelectTrafficLight == "D" && trainSelectDirection == "forward" && trainSelectLightColor == "green")
                    {
                        dLight.forwardOn();
                        dLightButton.BackColor = Color.Green;
                    }
                    else if (trainSelectTrafficLight == "D" && trainSelectDirection == "right" && trainSelectLightColor == "green")
                    {
                        dLight.rightOn();

                    }
                    else if (trainSelectTrafficLight == "D" && trainSelectDirection == "left" && trainSelectLightColor == "green")
                    {
                        dLight.leftOn();
                        dLeftButton.BackColor = Color.Green;
                    }
                    else if (trainSelectTrafficLight == "D" && trainSelectDirection == "forward" && trainSelectLightColor == "red")
                    {
                        dLight.forwardOff();
                        dLightButton.BackColor = Color.Red;
                    }
                    else if (trainSelectTrafficLight == "D" && trainSelectDirection == "right" && trainSelectLightColor == "red")
                    {
                        dLight.rightOff();

                    }
                    else if (trainSelectTrafficLight == "D" && trainSelectDirection == "left" && trainSelectLightColor == "red")
                    {
                        dLight.leftOff();
                        dLeftButton.BackColor = Color.Red;
                    }
                    else if (trainSelectTrafficLight == "*" && trainSelectDirection == "all" && trainSelectLightColor == "red")
                    {
                        aLight.forwardOff();
                        aLightButton.BackColor = Color.Red;
                        aLight.rightOff();
                        aRightButton.BackColor = Color.Red;
                        bLight.forwardOff();
                        bLightButton.BackColor = Color.Red;
                        bLight.rightOff();
                        bLight.leftOff();
                        bLeftButton.BackColor = Color.Red;
                        cLight.forwardOff();
                        cLightButton.BackColor = Color.Red;
                        cLight.rightOff();
                        cRightButton.BackColor = Color.Red;
                        cLight.leftOff();
                        dLight.forwardOff();
                        dLightButton.BackColor = Color.Red;
                        dLight.rightOff();
                        dLight.leftOff();
                        dLeftButton.BackColor = Color.Red;

                    }
                }
                if (trainSplitInstruction[i] == "%")
                {
                    if (trainSplitInstruction[i + 1] == "return")
                    {
                        if (trainLightCycleComboBox.InvokeRequired)
                        {
                            trainLightCycleComboBox.Invoke(new MethodInvoker(delegate { trainSelectedCycle = trainLightCycleComboBox.SelectedItem.ToString(); }));
                        }
                        runTrainFile();
                    }
                    else
                    {
                        trainSelectedCycle = trainSplitInstruction[i + 1];
                        runTrainFile();
                    }

                }
            }
            //Preps for the next instruction when its end time occurs
            trainInstructionCounter++;
            trainCurrentInstruction = trainCycleInstructions[trainInstructionCounter % (trainCycleInstructions.Count)];
            trainCycleEndTime = numSeconds + trainCycleTimings[trainInstructionCounter % (trainCycleInstructions.Count)];
        }

        public void interpretTramInstruction()
        {
            tramSplitInstruction = tramCurrentInstruction.Split(null);
            for (int i = 0; i < tramSplitInstruction.Length; i++)
            {
                if (tramSplitInstruction[i] == "-")
                {
                    tramSelectTrafficLight = tramSplitInstruction[i + 1];
                    tramSelectDirection = tramSplitInstruction[i + 2];
                    tramSelectLightColor = tramSplitInstruction[i + 3];

                    if (tramSelectTrafficLight == "A" && tramSelectDirection == "forward" && tramSelectLightColor == "green")
                    {
                        a2Light.forwardOn();
                        aLightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "A" && tramSelectDirection == "right" && tramSelectLightColor == "green")
                    {
                        a2Light.rightOn();
                        aRightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "A" && tramSelectDirection == "left" && tramSelectLightColor == "green")
                    {
                        a2Light.leftOn();
                        aLeftButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "A" && tramSelectDirection == "forward" && tramSelectLightColor == "red")
                    {
                        a2Light.forwardOff();
                        aLightButton2.BackColor = Color.Red;

                    }
                    else if (tramSelectTrafficLight == "A" && tramSelectDirection == "right" && tramSelectLightColor == "red")
                    {
                        a2Light.rightOff();
                        aRightButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "A" && tramSelectDirection == "left" && tramSelectLightColor == "red")
                    {
                        a2Light.leftOff();
                        aLeftButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "B" && tramSelectDirection == "forward" && tramSelectLightColor == "green")
                    {
                        b2Light.forwardOn();
                        bLightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "B" && tramSelectDirection == "right" && tramSelectLightColor == "green")
                    {
                        b2Light.rightOn();
                        bRightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "B" && tramSelectDirection == "left" && tramSelectLightColor == "green")
                    {
                        b2Light.leftOn();
                        bLeftButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "B" && tramSelectDirection == "forward" && tramSelectLightColor == "red")
                    {
                        b2Light.forwardOff();
                        bLightButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "B" && tramSelectDirection == "right" && tramSelectLightColor == "red")
                    {
                        b2Light.rightOff();
                        bRightButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "B" && tramSelectDirection == "left" && tramSelectLightColor == "red")
                    {
                        b2Light.leftOff();
                        bLeftButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "C" && tramSelectDirection == "forward" && tramSelectLightColor == "green")
                    {
                        c2Light.forwardOn();
                        cLightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "C" && tramSelectDirection == "right" && tramSelectLightColor == "green")
                    {
                        c2Light.rightOn();
                        cRightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "C" && tramSelectDirection == "left" && tramSelectLightColor == "green")
                    {
                        c2Light.leftOn();
                        cLeftButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "C" && tramSelectDirection == "forward" && tramSelectLightColor == "red")
                    {
                        c2Light.forwardOff();
                        cLightButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "C" && tramSelectDirection == "right" && tramSelectLightColor == "red")
                    {
                        c2Light.rightOff();
                        cRightButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "C" && tramSelectDirection == "left" && tramSelectLightColor == "red")
                    {
                        c2Light.leftOff();
                        cLeftButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "D" && tramSelectDirection == "forward" && tramSelectLightColor == "green")
                    {
                        d2Light.forwardOn();
                        dLightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "D" && tramSelectDirection == "right" && tramSelectLightColor == "green")
                    {
                        d2Light.rightOn();
                        dRightButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "D" && tramSelectDirection == "left" && tramSelectLightColor == "green")
                    {
                        d2Light.leftOn();
                        dLeftButton2.BackColor = Color.Green;
                    }
                    else if (tramSelectTrafficLight == "D" && tramSelectDirection == "forward" && tramSelectLightColor == "red")
                    {
                        d2Light.forwardOff();
                        dLightButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "D" && tramSelectDirection == "right" && tramSelectLightColor == "red")
                    {
                        d2Light.rightOff();
                        dRightButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "D" && tramSelectDirection == "left" && tramSelectLightColor == "red")
                    {
                        d2Light.leftOff();
                        dLeftButton2.BackColor = Color.Red;
                    }
                    else if (tramSelectTrafficLight == "*" && tramSelectDirection == "all" && tramSelectLightColor == "red")
                    {
                        a2Light.forwardOff();
                        aLightButton2.BackColor = Color.Red;
                        a2Light.rightOff();
                        aRightButton2.BackColor = Color.Red;
                        a2Light.leftOff();
                        aLeftButton2.BackColor = Color.Red;
                        b2Light.forwardOff();
                        bLightButton2.BackColor = Color.Red;
                        b2Light.rightOff();
                        bRightButton2.BackColor = Color.Red;
                        b2Light.leftOff();
                        bLeftButton2.BackColor = Color.Red;
                        c2Light.forwardOff();
                        cLightButton2.BackColor = Color.Red;
                        c2Light.rightOff();
                        cRightButton2.BackColor = Color.Red;
                        c2Light.leftOff();
                        cLeftButton2.BackColor = Color.Red;
                        d2Light.forwardOff();
                        dLightButton2.BackColor = Color.Red;
                        d2Light.rightOff();
                        dRightButton2.BackColor = Color.Red;
                        d2Light.leftOff();
                        dLeftButton2.BackColor = Color.Red;

                    }
                }
                if (tramSplitInstruction[i] == "%")
                {
                    if (tramSplitInstruction[i + 1] == "return")
                    {
                        if (tramLightCycleComboBox.InvokeRequired)
                        {
                            tramLightCycleComboBox.Invoke(new MethodInvoker(delegate { tramSelectedCycle = tramLightCycleComboBox.SelectedItem.ToString(); }));
                        }
                        runTramFile();
                    }
                    else
                    {
                        tramSelectedCycle = tramSplitInstruction[i + 1];
                        runTramFile();
                    }

                }
            }
            //Preps for the next instruction when its end time occurs
            tramInstructionCounter++;
            tramCurrentInstruction = tramCycleInstructions[tramInstructionCounter % (tramCycleInstructions.Count)];
            tramCycleEndTime = numSeconds + tramCycleTimings[tramInstructionCounter % (tramCycleInstructions.Count)];
        }

        //Drops down so the user can select which light cycle they want so long as they have proper permissions. Basic users only can view the default
        private void lightCycleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userLevel != "user")
            {
                if (tramLightCycleComboBox.SelectedItem != null)
                {
                    String line;
                    textBox4WayCycle.Clear();
                    tramSelectedCycle = tramLightCycleComboBox.SelectedItem.ToString();
                    System.IO.StreamReader file = new System.IO.StreamReader(tramSelectedCycle + ".txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        textBox4WayCycle.Text += line + "\r\n";
                    }
                    file.Close();
                    if (isRunning)
                    {
                        runTramFile();
                    }

                }
                else
                {
                    tramSelectedCycle = "TramDefaultOperation";
                }
            }
        }

        private void lightCycleComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userLevel != "user")
            {
                if (trainLightCycleComboBox.SelectedItem != null)
                {
                    String line;
                    textBoxOverpassCycle.Clear();
                    trainSelectedCycle = trainLightCycleComboBox.SelectedItem.ToString();
                    System.IO.StreamReader file = new System.IO.StreamReader(trainSelectedCycle + ".txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        textBoxOverpassCycle.Text += line + "\r\n";
                    }
                    file.Close();
                }
                if (isRunning)
                {
                    runTrainFile();
                }
            }
            else
            {
                trainSelectedCycle = "TrainDefaultOperation";
            }
        }

        //Pauses or resumes the playback.
        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (multiplier <= 0)
            {
                MessageBox.Show("Cannot use 0 or a negative number as a multiplier. Please select a positive value.");
            }
            else if (trainSelectedCycle == "")
            {
                MessageBox.Show("Please select a light cycle type.");
            }
            else
            {
                if (!isRunning)
                {
                    isRunning = true;
                    tramStartStopButton.Text = "Pause";
                    trainStartStopButton.Text = "Pause";
                    startTimer();
                }
                else
                {
                    isRunning = false;
                    tramStartStopButton.Text = "Resume";
                    trainStartStopButton.Text = "Resume";
                    pauseTimer();
                }
            }
        }

        private void startStopButton2_Click(object sender, EventArgs e)
        {
            if (multiplier <= 0)
            {
                MessageBox.Show("Cannot use 0 or a negative number as a multiplier. Please select a positive value.");
            }
            else if (tramSelectedCycle == "")
            {
                MessageBox.Show("Please select a light cycle type.");
            }
            else
            {
                if (!isRunning)
                {
                    isRunning = true;
                    tramStartStopButton.Text = "Pause";
                    trainStartStopButton.Text = "Pause";
                    startTimer();
                }
                else
                {
                    isRunning = false;
                    tramStartStopButton.Text = "Resume";
                    trainStartStopButton.Text = "Resume";
                    pauseTimer();
                }
            }
        }

        //Is actually trainButton. Name change made this name incorrect, but unable to change.
        private void tramButton_Click_1(object sender, EventArgs e)
        {
            tramSelectedCycle = "TramOperation";
            runTramFile();
        }

        private void tramButton_Click(object sender, EventArgs e)
        {

        }

        //Activates the light cycle for the tram. When the cycle completes, the program will return to the cycle it was on before the button was pressed
        private void tramButton2_Click(object sender, EventArgs e)
        {
            trainSelectedCycle = "TrainOperation";
            runTrainFile();

        }

        //Called by timer to update light images in light status tab
        private void refreshLightImages()
        {
            pictureBoxOverpassA.Image = showLightStatusOverpass(aLight);
            pictureBoxOverpassB.Image = showLightStatusOverpass(bLight);
            pictureBoxOverpassC.Image = showLightStatusOverpass(cLight);
            pictureBoxOverpassD.Image = showLightStatusOverpass(dLight);

            pictureBox4WayA.Image = showLightStatus4Way(a2Light);
            pictureBox4WayB.Image = showLightStatus4Way(b2Light);
            pictureBox4WayC.Image = showLightStatus4Way(c2Light);
            pictureBox4WayD.Image = showLightStatus4Way(d2Light);
        }

        //returns the correct image for the status of a traffic light
        private Image showLightStatusOverpass(TrafficLight light)
        {
            if (light.isRight())
            {
                if (light.forStatus() && light.rightStatus())
                {
                    return Image.FromFile("rightForwardRightGreen.jpg");
                }

                else if (!light.forStatus() && light.rightStatus())
                {
                    return Image.FromFile("rightGreenRed.jpg");
                }

                else if (!light.forStatus() && !light.rightStatus())
                {
                    return Image.FromFile("rightRed.jpg");
                }

                else if (light.forStatus() && !light.rightStatus())
                {
                    return Image.FromFile("rightForwardGreen.jpg");
                }
                else return Image.FromFile("rightRed.jpg");
            }

            else if (light.isLeft())
            {
                if (light.forStatus() && light.leftStatus())
                {
                    return Image.FromFile("leftForwardRightGreen.jpg");
                }

                else if (!light.forStatus() && light.leftStatus())
                {
                    return Image.FromFile("leftGreenRed.jpg");
                }

                else if (!light.forStatus() && !light.leftStatus())
                {
                    return Image.FromFile("leftRed.jpg");
                }

                else if (light.forStatus() && !light.leftStatus())
                {
                    return Image.FromFile("leftForwardGreen.jpg");
                }
                else return Image.FromFile("leftRed.jpg");

            }

            else return Image.FromFile("leftRed.jpg");

        }

        private Image showLightStatus4Way(TrafficLight light)
        {
            if (light.forStatus() && light.leftStatus() && light.rightStatus())
            {
                return Image.FromFile("allForwardAllGreen.jpg");
            }

            else if (!light.forStatus() && light.leftStatus() && light.rightStatus())
            {
                return Image.FromFile("allRightLeftGreenRed.jpg");
            }

            else if (!light.forStatus() && !light.leftStatus() && light.rightStatus())
            {
                return Image.FromFile("allRightGreenRed.jpg");
            }

            else if (!light.forStatus() && !light.leftStatus() && !light.rightStatus())
            {
                return Image.FromFile("allRed.jpg");
            }

            else if (light.forStatus() && !light.leftStatus() && !light.rightStatus())
            {
                return Image.FromFile("allForwardGreen.jpg");
            }

            else if (light.forStatus() && light.leftStatus() && !light.rightStatus())
            {
                return Image.FromFile("allForwardLeftGreen.jpg");
            }

            else if (!light.forStatus() && light.leftStatus() && !light.rightStatus())
            {
                return Image.FromFile("allLeftGreenRed.jpg");
            }

            else if (light.forStatus() && !light.leftStatus() && light.rightStatus())
            {
                return Image.FromFile("allForwardRightGreen.jpg");
            }

            else return Image.FromFile("allRed.jpg");

        }

        //Disables controls based on user permission level and sets color scheme
        private void initializePermissions(String userLevel)
        {
            if (userLevel == "user")
            {
                labelUserLevel.Text = "Basic User";
                trainLightCycleComboBox.Enabled = false;
                tramLightCycleComboBox.Enabled = false;
                textBox4WayCycle.Enabled = false;
                textBoxOverpassCycle.Enabled = false;
                btnUpdateOverpassCycle.Enabled = false;
                btnUpdate4WayCycle.Enabled = false;
                btnNew4WayCycle.Enabled = false;
                btnNewOverpassCycle.Enabled = false;
            }
            else if (userLevel == "emergency")
            {
                labelUserLevel.Text = "Emergency Services";
                this.BackColor = Color.Red;
                textBox4WayCycle.Enabled = false;
                textBoxOverpassCycle.Enabled = false;
                btnUpdateOverpassCycle.Enabled = false;
                btnUpdate4WayCycle.Enabled = false;
                btnNew4WayCycle.Enabled = false;
                btnNewOverpassCycle.Enabled = false;
            }
            else if(userLevel == "admin")
            {
                labelUserLevel.Text = "Administrator";
                this.BackColor = Color.Yellow;
            }            
        }

        //Sets playback speed when scrollbar is moved
        private void speedBar_Scroll(object sender, EventArgs e)
        {
            multiplier = speedBar.Value;
            speedBar2.Value = speedBar.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            multiplier = speedBar2.Value;
            speedBar.Value = speedBar2.Value;
        }

        private void btnUpdate4WayCycle_Click(object sender, EventArgs e)
        {
            File.WriteAllText(tramSelectedCycle + ".txt", textBox4WayCycle.Text);
            runTramFile();
        }

        private void btnUpdateOverpassCycle_Click(object sender, EventArgs e)
        {
            File.WriteAllText(trainSelectedCycle + ".txt", textBoxOverpassCycle.Text);
            runTrainFile();

        }

        //Called when new cycle button is clicked. Opens dialog to name new cycle
        //Checks if cycle already exists. if it doesn't save the cycle to a new file and add to list of cycles
        private void btnNew4WayCycle_Click(object sender, EventArgs e)
        {
            newCycleBox popUp = new newCycleBox();
            var result = popUp.ShowDialog();

            if (result == DialogResult.OK)
            {
                string newCycleName = popUp.newCycleName;
                String line;
                bool taken = false;
                System.IO.StreamReader file = new System.IO.StreamReader("TramListOfCycles.txt");

                while ((line = file.ReadLine()) != null)
                {
                    if (newCycleName == line)
                    {
                        MessageBox.Show("Cycle name already taken");
                        taken = true;
                        break;
                    }
                }
                file.Close();
                if (!taken)
                {
                    File.AppendAllText("TramListOfCycles.txt", "\r\n" + newCycleName);
                    File.AppendAllText(newCycleName + ".txt", textBox4WayCycle.Text);
                    initializeTramCycleLists();
                }                
            }
        }

        private void btnNewOverpassCycle_Click(object sender, EventArgs e)
        {
            newCycleBox popUp = new newCycleBox();
            var result = popUp.ShowDialog();

            if (result == DialogResult.OK)
            {
                string newCycleName = popUp.newCycleName;
                String line;
                bool taken = false;
                System.IO.StreamReader file = new System.IO.StreamReader("TrainListOfCycles.txt");

                while ((line = file.ReadLine()) != null)
                {
                    if (newCycleName == line)
                    {
                        MessageBox.Show("Cycle name already taken");
                        taken = true;
                        break;
                    }
                }
                file.Close();
                if (!taken)
                {

                    File.AppendAllText("TrainListOfCycles.txt", "\r\n" + newCycleName);
                    File.AppendAllText(newCycleName + ".txt", textBoxOverpassCycle.Text);
                    initializeTrainCycleLists();
                }
            }
        }

        #region unusedfunctions

        //Excess buttons that idk what they are. These should be renamed/removed as necessary
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabLightPattern_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void F_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void aLightButton_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
