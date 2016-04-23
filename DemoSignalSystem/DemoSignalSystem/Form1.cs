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
        bool isBasicUser = false;           //May be unnecessary as long as the other 2 options are covered
        bool isEmergencyUser = false;
        bool isAdmin = true;
        bool isRunning = true;
        double numSeconds = 0.0;
        double multiplier = 1.0;
        double curCycleEndTime = -1;
        double dbl = 0.0;
        int lengthOfTram = 0;
        int instructionCounter = 0;
        int hours, minutes, seconds = 0;
        Random rand = new Random();
        List<double> cycleTimings = new List<double>();
        List<string> cycleInstructions = new List<string>();
        string[] listOfCycles;
        string[] splitInstruction;
        string selectedCycle = "";
        string fileName = "";
        string currentInstruction = "";
        string selectTrafficLight = "";
        string selectDirection = "";
        string selectLightColor = "";


        //Lights are set up as TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left, string type)
        TrafficLight aLight = new TrafficLight(true, false, true, false, false, false, "car");
        TrafficLight bLight = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight cLight = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight dLight = new TrafficLight(true, false, true, false, true, false, "car");

        //Initialize the Timer that will keep track of light change timings
        System.Timers.Timer globalTimer = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
            initializeTimer();
            initializeCycleLists();
        }

        //Loads all the possible types of selectable cycles into the comboBox based on user permissions. Basic users only get the default operations
        public void initializeCycleLists()
        {
            try
            {
                listOfCycles = File.ReadAllLines("ListOfCycles.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (isEmergencyUser || isAdmin)
            {
                for (int i = 0; i < listOfCycles.Length; i++)
                {
                    lightCycleComboBox.Items.Add(listOfCycles[i]);
                    lightCycleComboBox2.Items.Add(listOfCycles[i]);
                }
                lightCycleComboBox.SelectedIndex = 0;
                lightCycleComboBox2.SelectedIndex = 0;
            }
            else
            {
                lightCycleComboBox.Items.Add(listOfCycles[0]);
                lightCycleComboBox2.Items.Add(listOfCycles[0]);
                lightCycleComboBox.SelectedIndex = 0;
                lightCycleComboBox2.SelectedIndex = 0;
            }  
        }

        //I think you can guess what this does
        public void initializeTimer()
        {
            globalTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            //Set time interval event trigger to 1000ms or 1 second
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
            seconds = Convert.ToInt32(Math.Floor(numSeconds%60));   //Section section of timer

            SetControlText(secondsTextBox2, seconds.ToString());
            SetControlText(secondsTextBox, seconds.ToString());

            if (numSeconds == curCycleEndTime)
            {
                interpretInstruction();
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
        public void runFile()
        {
            instructionCounter = 0;
            cycleTimings.Clear();
            cycleInstructions.Clear();
            fileName = selectedCycle + ".txt";
            string[] fileContents = File.ReadAllLines(fileName);

            //Populates the instruction lists with their respective timings
            for (int i = 0; i < fileContents.Length; i += 2)
            {
                if (Double.TryParse(fileContents[i], out dbl))
                {
                    cycleTimings.Add(dbl);
                }
                else
                {
                    MessageBox.Show("Fatal error with reading file");
                    globalTimer.Stop();
                    globalTimer.Dispose();
                    Application.Exit();
                }
                cycleInstructions.Add(fileContents[i + 1]);
            }
            //Populates the patternListBoxes. They work in real time to show which instructions/cycles are going on.
            if (patternListBox.InvokeRequired)
            {
                patternListBox.Invoke(new MethodInvoker(delegate { patternListBox.Items.Clear(); }));
                patternListBox2.Invoke(new MethodInvoker(delegate { patternListBox2.Items.Clear(); }));
            }
            else
            {
                patternListBox.Items.Clear();
                patternListBox2.Items.Clear();
            }

            if (patternListBox.InvokeRequired)
            {
                patternListBox.Invoke(new MethodInvoker(delegate { patternListBox.Items.AddRange(cycleInstructions.ToArray()); }));
                patternListBox2.Invoke(new MethodInvoker(delegate { patternListBox2.Items.AddRange(cycleInstructions.ToArray()); }));
            }
            else
            {
                patternListBox.Items.AddRange(cycleInstructions.ToArray());
                patternListBox2.Items.AddRange(cycleInstructions.ToArray());
            }

            //Preps the next instruction to be processed
            curCycleEndTime = numSeconds + cycleTimings[instructionCounter];
            currentInstruction = cycleInstructions[instructionCounter];
            interpretInstruction();
        }
        
        //Function that interprets each line of instructions in the Operation text files. Covers all combination of instructions that we should use
        public void interpretInstruction()
        {
            SystemSounds.Beep.Play();                               //Purely for testing
            splitInstruction = currentInstruction.Split(null);
            for (int i = 0; i < splitInstruction.Length; i++)
            {
                if (splitInstruction[i] == "-")
                {
                    selectTrafficLight = splitInstruction[i + 1];
                    selectDirection = splitInstruction[i + 2];
                    selectLightColor = splitInstruction[i + 3];

                    if (selectTrafficLight == "A" && selectDirection == "forward" && selectLightColor == "green")
                    {
                        aLight.forwardOn();

                    }
                    else if (selectTrafficLight == "A" && selectDirection == "right" && selectLightColor == "green")
                    {
                        aLight.rightOn();
                    }

                    else if (selectTrafficLight == "A" && selectDirection == "forward" && selectLightColor == "red")
                    {
                        aLight.forwardOff();
                    }
                    else if (selectTrafficLight == "A" && selectDirection == "right" && selectLightColor == "red")
                    {
                        aLight.rightOff();

                    }
                    else if (selectTrafficLight == "B" && selectDirection == "forward" && selectLightColor == "green")
                    {
                        bLight.forwardOn();
                    }
                    else if (selectTrafficLight == "B" && selectDirection == "right" && selectLightColor == "green")
                    {
                        bLight.rightOn();
                    }
                    else if (selectTrafficLight == "B" && selectDirection == "left" && selectLightColor == "green")
                    {
                        bLight.leftOn();
                    }
                    else if (selectTrafficLight == "B" && selectDirection == "forward" && selectLightColor == "red")
                    {
                        bLight.forwardOff();

                    }
                    else if (selectTrafficLight == "B" && selectDirection == "right" && selectLightColor == "red")
                    {
                        bLight.rightOff();
                    }
                    else if (selectTrafficLight == "B" && selectDirection == "left" && selectLightColor == "red")
                    {
                        bLight.leftOff();
                    }
                    else if (selectTrafficLight == "C" && selectDirection == "forward" && selectLightColor == "green")
                    {
                        cLight.forwardOn();
                    }
                    else if (selectTrafficLight == "C" && selectDirection == "right" && selectLightColor == "green")
                    {
                        cLight.rightOn();
                    }
                    else if (selectTrafficLight == "C" && selectDirection == "left" && selectLightColor == "green")
                    {
                        cLight.leftOn();
                    }
                    else if (selectTrafficLight == "C" && selectDirection == "forward" && selectLightColor == "red")
                    {
                        cLight.forwardOff();
                    }
                    else if (selectTrafficLight == "C" && selectDirection == "right" && selectLightColor == "red")
                    {
                        cLight.rightOff();
                    }
                    else if (selectTrafficLight == "C" && selectDirection == "left" && selectLightColor == "red")
                    {
                        cLight.leftOff();
                    }
                    else if (selectTrafficLight == "D" && selectDirection == "forward" && selectLightColor == "green")
                    {
                        dLight.forwardOn();
                        dLightButton2.BackColor = Color.Green;
                    }
                    else if (selectTrafficLight == "D" && selectDirection == "right" && selectLightColor == "green")
                    {
                        dLight.rightOn();
                    }
                    else if (selectTrafficLight == "D" && selectDirection == "left" && selectLightColor == "green")
                    {
                        dLight.leftOn();
                    }
                    else if (selectTrafficLight == "D" && selectDirection == "forward" && selectLightColor == "red")
                    {
                        dLight.forwardOff();
                    }
                    else if (selectTrafficLight == "D" && selectDirection == "right" && selectLightColor == "red")
                    {
                        dLight.rightOff();
                    }
                    else if (selectTrafficLight == "D" && selectDirection == "left" && selectLightColor == "red")
                    {
                        dLight.leftOff();
                    }
                    else if (selectTrafficLight == "*" && selectDirection == "all" && selectLightColor == "red")
                    {
                        aLight.forwardOff();
                        aLight.rightOff();
                        bLight.forwardOff();
                        bLight.rightOff();
                        bLight.leftOff();
                        cLight.forwardOff();
                        cLight.rightOff();
                        cLight.leftOff();
                        dLight.forwardOff();
                        dLight.rightOff();
                        dLight.leftOff();
                        dLightButton2.BackColor = Color.Green;
                    }
                }
                if (splitInstruction[i] == "%")
                {
                    if (splitInstruction[i+1] == "return")
                    {
                        if (lightCycleComboBox.InvokeRequired)
                        {
                            lightCycleComboBox.Invoke(new MethodInvoker(delegate { selectedCycle = lightCycleComboBox.SelectedItem.ToString(); }));
                        }
                        runFile();
                    }
                    else
                    {
                        selectedCycle = splitInstruction[i + 1];
                        runFile();
                    }
                    
                }
            }
            //Preps for the next instruction when its end time occurs
            instructionCounter++;
            currentInstruction = cycleInstructions[instructionCounter % (cycleInstructions.Count)];
            curCycleEndTime = numSeconds + cycleTimings[instructionCounter % (cycleInstructions.Count)];
        }

        //Drops down so the user can select which light cycle they want so long as they have proper permissions. Basic users only can view the default
        private void lightCycleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightCycleComboBox2.SelectedItem = lightCycleComboBox.SelectedItem;
            if (isEmergencyUser || isAdmin)
            {
                if (lightCycleComboBox.SelectedItem != null)
                {
                    selectedCycle = lightCycleComboBox.SelectedItem.ToString();
                }
                if (isRunning)
                {
                    runFile();
                }
            }
            else
            {
                selectedCycle = "DefaultOperation";
            }
        }

        private void lightCycleComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightCycleComboBox.SelectedItem = lightCycleComboBox2.SelectedItem;
            if (isEmergencyUser || isAdmin)
            {
                if (lightCycleComboBox2.SelectedItem != null)
                {
                    selectedCycle = lightCycleComboBox2.SelectedItem.ToString();
                }
                if (isRunning)
                {
                    runFile();
                }
            }
            else
            {
                selectedCycle = "DefaultOperation";
            }
        }

        //Controls the playback speed. Cannot go below 1 or above 100.
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            multiplier = Convert.ToDouble(numericUpDown.Value);
            numericUpDown2.Value = numericUpDown.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            multiplier = Convert.ToDouble(numericUpDown.Value);
            numericUpDown.Value = numericUpDown2.Value;
        }

        //Pauses or resumes the playback.
        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (multiplier <= 0)
            {
                MessageBox.Show("Cannot use 0 or a negative number as a multiplier. Please select a positive value.");
            }
            else if (selectedCycle == "")
            {
                MessageBox.Show("Please select a light cycle type.");
            }
            else
            {
                if (!isRunning)
                {
                    isRunning = true;
                    startStopButton.Text = "Pause";
                    startStopButton2.Text = "Pause";
                    startTimer();
                    runFile();
                }
                else
                {
                    isRunning = false;
                    startStopButton.Text = "Resume";
                    startStopButton2.Text = "Resume";
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
            else if (selectedCycle == "")
            {
                MessageBox.Show("Please select a light cycle type.");
            }
            else
            {
                if (!isRunning)
                {
                    isRunning = true;
                    startStopButton.Text = "Pause";
                    startStopButton2.Text = "Pause";
                    startTimer();
                    runFile();
                }
                else
                {
                    isRunning = false;
                    startStopButton.Text = "Resume";
                    startStopButton2.Text = "Resume";
                    pauseTimer();
                }
            }
        }

        //Activates the light cycle for the tram. When the cycle completes, the program will return to the cycle it was on before the button was pressed
        private void tramButton_Click(object sender, EventArgs e)
        {
            selectedCycle = "TramOperation";
            runFile();
            lengthOfTram = rand.Next(300, 600);
            curCycleEndTime = curCycleEndTime + lengthOfTram;
        }

        private void tramButton2_Click(object sender, EventArgs e)
        {
            selectedCycle = "TramOperation";
            runFile();
            lengthOfTram = rand.Next(0, 300);
            curCycleEndTime = curCycleEndTime + lengthOfTram;
        }

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
            aLightButton2.BackColor = Color.Red;

        }

        private void F_Click(object sender, EventArgs e)
        {
            aLightButton2.BackColor = Color.Green;
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

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
