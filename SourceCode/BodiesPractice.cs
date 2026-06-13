using NXOpen;
using static NXOpen.GeometricAnalysis.GeometricProperties;

namespace ModelingPractice
{
    public class BodiesPractice
    {
        public static void GetBodyDetails()
        {
            ListingWindow lw = Session.GetSession().ListingWindow;
            lw.Open();

            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            
            NXOpen.Body[] bodies = workPart.Bodies.ToArray();
            lw.WriteLine($"Number of Bodies in the part: {bodies.Length}");
            foreach (var body in bodies)
            {
                lw.WriteLine($"Body Name: {body.Name}");
                lw.WriteLine($"Body Type: {body.GetType()}");  

                //NXUtilities.ChangeColor(body, 186);
                var faces= body.GetFaces();
                lw.WriteLine($"Number of faces: {faces.Length}");

                foreach (var face in faces)
                {
                    lw.WriteLine($"     Face Type: {face.SolidFaceType}");
                    foreach (var edge in face.GetEdges())
                    {
                        lw.WriteLine($"          - Edge Type: {edge.SolidEdgeType}");
                    }
                }
            }
        }
    }
}
