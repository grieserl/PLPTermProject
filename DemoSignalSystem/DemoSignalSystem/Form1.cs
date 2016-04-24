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
        double curCycleEndTime2 = -1;
        double dbl = 0.0;
        int lengthOfTram = 0;
        int instructionCounter = 0;
        int instructionCounter2 = 0;
        int hours, minutes, seconds = 0;
        Random rand = new Random();
        List<double> cycleTimings = new List<double>();
        List<double> cycleTimings2 = new List<double>();
        List<string> cycleInstructions = new List<string>();
        List<string> cycleInstructions2 = new List<string>();
        string[] listOfCycles;
        string[] listOfCycles2;
        string[] splitInstruction;
        string[] splitInstruction2;
        string selectedCycle = "";
        string selectedCycle2 = "";
        string fileName = "";
        string fileName2 = "";
        string currentInstruction = "";
        string currentInstruction2 = "";
        string selectTrafficLight = "";
        string selectTrafficLight2 = "";
        string selectDirection = "";
        string selectDirection2 = "";
        string selectLightColor = "";
        string selectLightColor2 = "";


        //Lights are set up as TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left, string type)

        //Lights for the overview map
        TrafficLight aLight = new TrafficLight(true, false, true, false, false, false, "car");
        TrafficLight bLight = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight cLight = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight dLight = new TrafficLight(true, false, true, false, true, false, "car");

        //Lights for the BD intersection
        TrafficLight a2Light = new TrafficLight(true, false, true, false, false, false, "car");
        TrafficLight b2Light = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight c2Light = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight d2Light = new TrafficLight(true, false, true, false, true, false, "car");

        //Initialize the Timer that will keep track of light change timings
        System.Timers.Timer globalTimer = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
            initializeCycleLists();
            initializeCycleLists2();
            initializeTimer();
        }

        //Loads all the possible types of selectable cycles into the comboBox based on user permissions. Basic users only get the default operations
        public void initializeCycleLists()
        {
            listOfCycles = File.ReadAllLines("ListOfCycles.txt");
            if (isEmergencyUser || isAdmin)
            {
                for (int i = 0; i < listOfCycles.Length; i++)
                {
                    lightCycleComboBox.Items.Add(listOfCycles[i]);
                }
                lightCycleComboBox.SelectedIndex = 0;
            }
            else
            {
                lightCycleComboBox.Items.Add(listOfCycles[0]);
                lightCycleComboBox.SelectedIndex = 0;
            }  
        }

        public void initializeCycleLists2()
        {
            listOfCycles2 = File.ReadAllLines("ListOfCycles2.txt");
            if (isEmergencyUser || isAdmin)
            {
                for (int i = 0; i < listOfCycles2.Length; i++)
                {
                    lightCycleComboBox2.Items.Add(listOfCycles2[i]);
                }
                lightCycleComboBox2.SelectedIndex = 0;
            }
            else
            {
                lightCycleComboBox2.Items.Add(listOfCycles2[0]);
                lightCycleComboBox2.SelectedIndex = 0;
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
            seconds = Convert.ToInt32(Math.Floor(numSeconds%60));   //Section section of timer

            SetControlText(secondsTextBox2, seconds.ToString());
            SetControlText(secondsTextBox, seconds.ToString());

            if (numSeconds == curCycleEndTime && numSeconds == curCycleEndTime2)
            {
                interpretInstruction();
                interpretInstruction2();
            }
            else if (numSeconds == curCycleEndTime)
            {
                interpretInstruction();
            }
            else if (numSeconds == curCycleEndTime2)
            {
                interpretInstruction2();
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
            }
            else
            {
                patternListBox.Items.Clear();
            }

            if (patternListBox.InvokeRequired)
            {
                patternListBox.Invoke(new MethodInvoker(delegate { patternListBox.Items.AddRange(cycleInstructions.ToArray()); }));
            }
            else
            {
                patternListBox.Items.AddRange(cycleInstructions.ToArray());
            }

            //Preps the next instruction to be processed
            curCycleEndTime = numSeconds + cycleTimings[instructionCounter];
            currentInstruction = cycleInstructions[instructionCounter];
            interpretInstruction();
        }

        public void runFile2()
        {
            instructionCounter2 = 0;
            cycleTimings2.Clear();
            cycleInstructions2.Clear();
            fileName2 = selectedCycle2 + ".txt";
            string[] fileContents2 = File.ReadAllLines(fileName2);

            //Populates the instruction lists with their respective timings
            for (int i = 0; i < fileContents2.Length; i += 2)
            {
                if (Double.TryParse(fileContents2[i], out dbl))
                {
                    cycleTimings2.Add(dbl);
                }
                else
                {
                    MessageBox.Show("Fatal error with reading file");
                    globalTimer.Stop();
                    globalTimer.Dispose();
                    Application.Exit();
                }
                cycleInstructions2.Add(fileContents2[i + 1]);
            }
            //Populates the patternListBoxes. They work in real time to show which instructions/cycles are going on.
            if (patternListBox2.InvokeRequired)
            {
                patternListBox2.Invoke(new MethodInvoker(delegate { patternListBox2.Items.Clear(); }));
            }
            else
            {
                patternListBox2.Items.Clear();
            }

            if (patternListBox2.InvokeRequired)
            {
                patternListBox2.Invoke(new MethodInvoker(delegate { patternListBox2.Items.AddRange(cycleInstructions2.ToArray()); }));
            }
            else
            {
                patternListBox2.Items.AddRange(cycleInstructions2.ToArray());
            }

            //Preps the next instruction to be processed
            curCycleEndTime2 = numSeconds + cycleTimings2[instructionCounter2];
            currentInstruction2 = cycleInstructions2[instructionCounter2];
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

        public void interpretInstruction2()
        {
            SystemSounds.Beep.Play();                               //Purely for testing
            splitInstruction2 = currentInstruction2.Split(null);
            for (int i = 0; i < splitInstruction2.Length; i++)
            {
                if (splitInstruction2[i] == "-")
                {
                    selectTrafficLight2 = splitInstruction2[i + 1];
                    selectDirection2 = splitInstruction2[i + 2];
                    selectLightColor2 = splitInstruction2[i + 3];

                    if (selectTrafficLight2 == "A" && selectDirection2 == "forward" && selectLightColor2 == "green")
                    {
                        a2Light.forwardOn();
                    }
                    else if (selectTrafficLight2 == "A" && selectDirection2 == "right" && selectLightColor2 == "green")
                    {
                        a2Light.rightOn();
                    }
                    else if (selectTrafficLight2 == "A" && selectDirection2 == "left" && selectLightColor2 == "green")
                    {
                        a2Light.leftOn();
                    }
                    else if (selectTrafficLight2 == "A" && selectDirection2 == "forward" && selectLightColor2 == "red")
                    {
                        a2Light.forwardOff();
                    }
                    else if (selectTrafficLight2 == "A" && selectDirection2 == "right" && selectLightColor2 == "red")
                    {
                        a2Light.rightOff();
                    }
                    else if (selectTrafficLight2 == "A" && selectDirection2 == "left" && selectLightColor2 == "red")
                    {
                        a2Light.leftOff();
                    }
                    else if (selectTrafficLight2 == "B" && selectDirection2 == "forward" && selectLightColor2 == "green")
                    {
                        b2Light.forwardOn();
                    }
                    else if (selectTrafficLight2 == "B" && selectDirection2 == "right" && selectLightColor2 == "green")
                    {
                        b2Light.rightOn();
                    }
                    else if (selectTrafficLight2 == "B" && selectDirection2 == "left" && selectLightColor2 == "green")
                    {
                        b2Light.leftOn();
                    }
                    else if (selectTrafficLight2 == "B" && selectDirection2 == "forward" && selectLightColor2 == "red")
                    {
                        b2Light.forwardOff();
                    }
                    else if (selectTrafficLight2 == "B" && selectDirection2 == "right" && selectLightColor2 == "red")
                    {
                        b2Light.rightOff();
                    }
                    else if (selectTrafficLight2 == "B" && selectDirection2 == "left" && selectLightColor2 == "red")
                    {
                        b2Light.leftOff();
                    }
                    else if (selectTrafficLight2 == "C" && selectDirection2 == "forward" && selectLightColor2 == "green")
                    {
                        c2Light.forwardOn();
                    }
                    else if (selectTrafficLight2 == "C" && selectDirection2 == "right" && selectLightColor2 == "green")
                    {
                        c2Light.rightOn();
                    }
                    else if (selectTrafficLight2 == "C" && selectDirection2 == "left" && selectLightColor2 == "green")
                    {
                        c2Light.leftOn();
                    }
                    else if (selectTrafficLight2 == "C" && selectDirection2 == "forward" && selectLightColor2 == "red")
                    {
                        c2Light.forwardOff();
                    }
                    else if (selectTrafficLight2 == "C" && selectDirection2 == "right" && selectLightColor2 == "red")
                    {
                        c2Light.rightOff();
                    }
                    else if (selectTrafficLight2 == "C" && selectDirection2 == "left" && selectLightColor2 == "red")
                    {
                        c2Light.leftOff();
                    }
                    else if (selectTrafficLight2 == "D" && selectDirection2 == "forward" && selectLightColor2 == "green")
                    {
                        d2Light.forwardOn();
                        dLightButton2.BackColor = Color.Green;
                    }
                    else if (selectTrafficLight2 == "D" && selectDirection2 == "right" && selectLightColor2 == "green")
                    {
                        d2Light.rightOn();
                    }
                    else if (selectTrafficLight2 == "D" && selectDirection2 == "left" && selectLightColor2 == "green")
                    {
                        d2Light.leftOn();
                    }
                    else if (selectTrafficLight2 == "D" && selectDirection2 == "forward" && selectLightColor2 == "red")
                    {
                        d2Light.forwardOff();
                    }
                    else if (selectTrafficLight2 == "D" && selectDirection2 == "right" && selectLightColor2 == "red")
                    {
                        d2Light.rightOff();
                    }
                    else if (selectTrafficLight2 == "D" && selectDirection2 == "left" && selectLightColor2 == "red")
                    {
                        d2Light.leftOff();
                    }
                    else if (selectTrafficLight2 == "*" && selectDirection2 == "all" && selectLightColor2 == "red")
                    {
                        a2Light.forwardOff();
                        a2Light.rightOff();
                        a2Light.leftOff();
                        b2Light.forwardOff();
                        b2Light.rightOff();
                        b2Light.leftOff();
                        c2Light.forwardOff();
                        c2Light.rightOff();
                        c2Light.leftOff();
                        d2Light.forwardOff();
                        d2Light.rightOff();
                        d2Light.leftOff();
                        dLightButton2.BackColor = Color.Green;
                    }
                }
                if (splitInstruction2[i] == "%")
                {
                    if (splitInstruction2[i + 1] == "return")
                    {
                        if (lightCycleComboBox2.InvokeRequired)
                        {
                            lightCycleComboBox2.Invoke(new MethodInvoker(delegate { selectedCycle2 = lightCycleComboBox2.SelectedItem.ToString(); }));
                        }
                        runFile2();
                    }
                    else
                    {
                        selectedCycle2 = splitInstruction2[i + 1];
                        runFile2();
                    }

                }
            }
            //Preps for the next instruction when its end time occurs
            instructionCounter2++;
            currentInstruction2 = cycleInstructions2[instructionCounter2 % (cycleInstructions2.Count)];
            curCycleEndTime2 = numSeconds + cycleTimings2[instructionCounter2 % (cycleInstructions2.Count)];
        }

        //Drops down so the user can select which light cycle they want so long as they have proper permissions. Basic users only can view the default
        private void lightCycleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (isEmergencyUser || isAdmin)
            {
                if (lightCycleComboBox2.SelectedItem != null)
                {
                    selectedCycle2 = lightCycleComboBox2.SelectedItem.ToString();
                }
                if (isRunning)
                {
                    runFile2();
                }
            }
            else
            {
                selectedCycle2 = "DefaultOperation2";
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
        private void tramButton2_Click(object sender, EventArgs e)
        {
            selectedCycle2 = "TramOperation";
            runFile2();
            lengthOfTram = rand.Next(300, 600);
            curCycleEndTime2 = curCycleEndTime2 + lengthOfTram;
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
        
        private void tramButton_Click(object sender, EventArgs e)
        {
            //Button no longer exists.
        }
    }
}
