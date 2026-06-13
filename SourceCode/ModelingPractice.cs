using NXOpen;
using System;

namespace ModelingPractice
{
    public class ModelingPractice
    {
        //class members
        private static NXOpen.Session theSession = null;
        private static NXOpen.UF.UFSession theUFSession = null;
        private static NXOpen.UI theUI = null;
        private static InputParameters InputParametersObj=null;
        public static void Main(string[] args)
        {
            try
            {
                theSession = Session.GetSession();
                theUFSession = NXOpen.UF.UFSession.GetUFSession();
                theUI = NXOpen.UI.GetUI();
                NXOpen.Part workPart = theSession.Parts.Work;
                NXOpen.Part displayPart = theSession.Parts.Display;
                ProjectSetUp.InitializeTool();

                if (!theSession.IsBatch && InputParametersObj == null)
                {
                    InputParametersObj=new InputParameters();
                    UI_ObjectSelectionToDisplayDetails theUI_ObjectSelectionToDisplayDetails = null;
                    try
                    {
                        theUI_ObjectSelectionToDisplayDetails = new UI_ObjectSelectionToDisplayDetails(InputParametersObj);
                        // The following method shows the dialog immediately
                        theUI_ObjectSelectionToDisplayDetails.Show();
                    }
                    catch (Exception ex)
                    {
                        //---- Enter your exception handling code here -----
                        theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
                    }
                    finally
                    {
                        if (theUI_ObjectSelectionToDisplayDetails != null)
                            theUI_ObjectSelectionToDisplayDetails.Dispose();
                        theUI_ObjectSelectionToDisplayDetails = null;
                    }
                }
                var selectedObj = InputParametersObj.SelectedObjs;
                switch (selectedObj)
                {
                    case NXOpen.Face face:
                        break;
                    case NXOpen.Edge edge:
                        break;
                    case NXOpen.Body body:
                        break;
                    default:
                        Console.WriteLine($"Unhandled type: {selectedObj.GetType().Name}");
                        break;
                }
                BodiesPractice.GetBodyDetails();
            }
            catch (Exception ex)
            {
                NXLogger.Instance.LogException(ex);
                NXLogger.Instance.Dispose();
                throw;
            }
        }


        public static int GetUnloadOption(string arg)
        {
            //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);
            return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
            // return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
        }

        //------------------------------------------------------------------------------
        // Following method cleanup any housekeeping chores that may be needed.
        // This method is automatically called by NX.
        //------------------------------------------------------------------------------
        public static void UnloadLibrary(string arg)
        {
            try
            {
                //---- Enter your code here -----
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Main", NXMessageBox.DialogType.Error, ex.ToString());
            }
        }
    }
}

/*
 1. creating a point (utilities)
 2. 
 
 */
