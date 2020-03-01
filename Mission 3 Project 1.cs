using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Adam Kabat Version
    // Description: Updated starter code for Finch Robot.
    // Application Type: Console
    // Author: Adam Kabat
    // Dated Created: 2/21/2020
    // Last Modified: 2/22/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its light and sounds!");
            DisplayContinuePrompt();

            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(1000);
            finchRobot.noteOn(10);
            finchRobot.wait(2000);
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine();
            Console.WriteLine("Now it's your turn!");
            Console.WriteLine("What color should the light be? Red, Blue, or Green?");

            string color;

            color = Console.ReadLine().ToLower();

            if (color == "red")
            {
                finchRobot.setLED(255, 0, 0);
                finchRobot.wait(3000);
                finchRobot.setLED(0, 0, 0);
            }
            if (color == "blue")
            {
                finchRobot.setLED(0, 0, 255);
                finchRobot.wait(3000);
                finchRobot.setLED(0, 0, 0);
            }
            if (color == "green")
            {
                finchRobot.setLED(0, 255, 0);
                finchRobot.wait(3000);
                finchRobot.setLED(0, 0, 0);
            }
            else
            {
                finchRobot.setLED(0, 0, 0);
            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("What frequency do you want it to make? 25, 50, or 100?");

            string sound;

            sound = Console.ReadLine();

            if (sound == "25")
            {
                finchRobot.noteOn(25);
                finchRobot.wait(3000);
                finchRobot.noteOff();
            }
            if (sound == "50")
            {
                finchRobot.noteOn(50);
                finchRobot.wait(3000);
                finchRobot.noteOff();
            }
            if (sound == "100")
            {
                finchRobot.noteOn(100);
                finchRobot.wait(3000);
                finchRobot.noteOff();
            }
            else
            {
                DisplayContinuePrompt();
            }
            DisplayMenuPrompt("Talent Show ");
        }

        #endregion

        #region DATA RECORDER

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

    }

        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            Console.WriteLine(
                "Recording #".PadLeft(15) + 
                "Temp".PadLeft(15)
                );

            Console.WriteLine(
                "-----------".PadLeft(15) +
                "===========".PadLeft(15)
                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                temperatures[index].ToString("n2").PadLeft(15)
                );
            }

            DisplayContinuePrompt();
        }

        static void DataRecorderDisplayGetData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();
        }

        static void DataRecorderDisplayTable(double[] temperatures)
        {
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)
                );

            Console.WriteLine(
                "-----------".PadLeft(15) +
                "===========".PadLeft(15)
                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                temperatures[index].ToString("n2").PadLeft(15)
                );
            }
        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            
            DisplayScreenHeader("Get Data");

            Console.WriteLine($"\tNumber of data points: {numberOfDataPoints}");
            Console.WriteLine($"\tData point frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe finch Robot is ready to begin recording the temperature data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);
            }

            DisplayContinuePrompt();
            DisplayScreenHeader("Get Data");

            Console.WriteLine();
            Console.WriteLine("\tTable of Temperatures");
            Console.WriteLine();
            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();

            return temperatures;
        }

        /// <summary>
        /// get the frequency of data points from the user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            string userResponse;

            DisplayScreenHeader("Data Point Frequency");

            Console.WriteLine("\tHow frequently do you want the Finch to record data?");

            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// get the number of data points from the user
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;

            DisplayScreenHeader("Number of Data Points");

            Console.WriteLine("\tHow many data points would you like the Finch to record?");
            userResponse = Console.ReadLine();

            int.TryParse(userResponse, out numberOfDataPoints);
           
            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        #endregion

        #region TALENT SHOW MOVEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show Dance                               *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\t The Finch robot will now show off its moves!");
            DisplayContinuePrompt();

            finchRobot.setMotors(255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 255);
            finchRobot.setMotors(0, 0);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("How long would you like the Finch robot to run? 5, 10, or 15 seconds?");

            string run;

            run = Console.ReadLine();

            if (run == "5")
            {
                finchRobot.setMotors(255, 255);
                finchRobot.wait(5000);
                finchRobot.setMotors(0, 0);
            }
            if (run == "10")
            {
                finchRobot.setMotors(255, 255);
                finchRobot.wait(10000);
                finchRobot.setMotors(0, 0);
            }
            if (run == "15")
            {
                finchRobot.setMotors(255, 255);
                finchRobot.wait(15000);
                finchRobot.setMotors(0, 0);
            }

            DisplayMenuPrompt("Talent Show ");
        }
        #endregion

        #region TALENT SHOW MIX
        ///<summary>
        ///******************************************************
        ///*                Talent Show "Mix It Up"
        ///******************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("The Finch robot will now \"mix it up\" for you!");
            DisplayContinuePrompt();

            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(50);
            finchRobot.wait(2000);
            finchRobot.noteOff();
            finchRobot.setMotors(255, 255);
            finchRobot.wait(2000);
            finchRobot.setMotors(255, 0);
            finchRobot.wait(2000);
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);
            finchRobot.noteOn(100);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(5000);
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show ");

        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
