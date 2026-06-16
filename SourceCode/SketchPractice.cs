using NXOpen;
using NXOpen.Features;

namespace ModelingPractice
{
    public class SketchPractice
    {
        public static Feature ActivateSketch(double[] normal, double[] origin)
        {
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;

            NXOpen.Sketch nullNXOpen_Sketch = null;
            NXOpen.SketchInPlaceBuilder sketchInPlaceBuilder1;
            sketchInPlaceBuilder1 = workPart.Sketches.CreateSketchInPlaceBuilder2(nullNXOpen_Sketch);

            NXOpen.Point3d origin1 = new NXOpen.Point3d(origin[0], origin[1], origin[2]);
            NXOpen.Vector3d normal1 = new NXOpen.Vector3d(normal[0], normal[1], normal[2]);
            NXOpen.Plane plane1 = workPart.Planes.CreatePlane(origin1, normal1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            sketchInPlaceBuilder1.PlaneReference = plane1;

            NXOpen.NXObject nXObject1;
            nXObject1 = sketchInPlaceBuilder1.Commit();

            NXOpen.Sketch sketch1 = (NXOpen.Sketch)nXObject1;
            NXOpen.Features.Feature feature1 = sketch1.Feature;

            sketch1.Activate(NXOpen.Sketch.ViewReorient.True);

            sketchInPlaceBuilder1.Destroy();

            //plane1.DestroyPlane();

            return feature1;
        }

        /// <summary>
        /// After activating sketch environment and creating sketch, it should be deactivated
        /// </summary>
        public static void DeActiveSketch()
        {
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            NXOpen.Sketch activeSketch = theSession.ActiveSketch;

            theSession.ActiveSketch.Deactivate(NXOpen.Sketch.ViewReorient.True, NXOpen.Sketch.UpdateLevel.Model);
        }
        //public static void CreateSketchIntersectionCurve(Face face)
        //{
        //    try
        //    {
        //        Session theSession = Session.GetSession();
        //        Part workPart = theSession.Parts.Work;
        //        //var datumPlane= theSession.ActiveSketch.AttachPlane;
        //        SketchIntersectionCurveBuilder builder = workPart.Sketches.CreateIntersectionCurveBuilder(null);

        //        ScCollector collector = builder.FaceCollector;

        //        Face[] faces = { face };

        //        FaceDumbRule faceRule =
        //            workPart.ScRuleFactory.CreateRuleFaceDumb(faces);

        //        collector.ReplaceRules(new SelectionIntentRule[] { faceRule },false);

        //        builder.Associative = false;

        //        Feature feature= builder.CommitFeature();

        //        builder.Destroy();
        //    }
        //    catch (NXException ex)
        //    {
        //        UI.GetUI().NXMessageBox.Show("From intersection method", NXMessageBox.DialogType.Error, ex.Message);
        //    }
        //}
        public static void CreateSSketchIntersectionCurve(Face face)
        {
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            // ----------------------------------------------
            //   Menu: Insert->Sketch Curve->Intersection Curve...
            // ----------------------------------------------

            NXOpen.SketchIntersectionCurve nullNXOpen_SketchIntersectionCurve = null;
            NXOpen.SketchIntersectionCurveBuilder sketchIntersectionCurveBuilder1 = workPart.Sketches.CreateIntersectionCurveBuilder(nullNXOpen_SketchIntersectionCurve);

            NXOpen.ScCollector scCollector1 = sketchIntersectionCurveBuilder1.FaceCollector;

            //NXOpen.GeometricUtilities.CurveFitOptions curveFitOptions1 = sketchIntersectionCurveBuilder1.CurveFitMethod;

            //curveFitOptions1.MaximumDegree = 7;

            //curveFitOptions1.MaximumSegments = 1;


            //NXOpen.Features.ExtractFace extractFace1 = (NXOpen.Features.ExtractFace)workPart.Features.FindObject("EXTRACT_FACE(3)");
            //NXOpen.Face face1 = (NXOpen.Face)extractFace1.FindObject("FACE 1 {(24.9999999999978,0,50) EXTRACT_FACE(3)}");
            NXOpen.FaceDumbRule faceDumbRule = workPart.ScRuleFactory.CreateRuleFaceDumb(new Face[]{face});

            NXOpen.SelectionIntentRule[] rules1 = { faceDumbRule };
            scCollector1.ReplaceRules(rules1, false);

            sketchIntersectionCurveBuilder1.CollectorUpdated();

            sketchIntersectionCurveBuilder1.Associative = false;

            NXOpen.Features.Feature feature1 = sketchIntersectionCurveBuilder1.CommitFeature();

            sketchIntersectionCurveBuilder1.Destroy();

            scCollector1.Destroy();

        }
    }
}
