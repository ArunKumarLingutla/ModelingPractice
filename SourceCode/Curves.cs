using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingPractice
{
    public class Curves
    {
        public static void PrintCurvesData()
        {
            int numOfCurves=0;
            var curves = ProjectSetUp.workPart.Curves;
            foreach (Curve curve in curves)
            {
                NXLogger.Instance.Log($"Curve Type: {curve.GetType()}");

                //NXObject.AttributeInformation[] attributes=curve.GetUserAttributes();
                //foreach (var attribute in attributes) 
                //{
                //    NXLogger.Instance.Log($"Attribute- {attribute.Title} = {attribute.StringValue}");
                //}
                numOfCurves++;
            }
        }
    }
}
