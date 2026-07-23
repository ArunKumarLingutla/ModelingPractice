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
                ////---- Enter your code here -----
                var sketch= SketchPractice.ActivateSketch(new double[] {1,0,0},new double[] {0,0,0},out Sketch sketch1);
                SketchPractice.CreateSSketchIntersectionCurve((Face)InputParametersObj.SelectedObjs);

                foreach (var c in sketch1.GetAllGeometry()) 
                {
                    NXLogger.Instance.Log($"Sketch type of - {c.Name} is:{c.GetType()}");
                    UI.GetUI().NXMessageBox.Show("Sketch object type", NXMessageBox.DialogType.Information, $"Sketch type of - {c.Name} is:{c.GetType()}");
                }
                    
                

                SketchPractice.DeActiveSketch();

            }
            catch (Exception ex)
            {
                NXLogger.Instance.LogException(ex);
                NXLogger.Instance.Dispose();
                throw;
            }
            finally
            {
                ProjectSetUp.Refresh();
                
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
