using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingPractice
{
    public class FacePractice
    {
        public static void GetFaceDetails(Face face)
        {
            ListingWindow lw = Session.GetSession().ListingWindow;
            lw.Open();

            lw.WriteLine($"face type: {face.SolidFaceType}");
        }
    }
}
