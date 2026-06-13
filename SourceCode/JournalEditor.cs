//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ModelingPractice
//{
//    // NX 12.0.1.7
//    // Journal created by arunk on Sun Jun  7 12:22:31 2026 India Standard Time
//    //
//    using System;
//    using NXOpen;

//    public class NXJournal
//    {
//        public static void Main(string[] args)
//        {
//            NXOpen.Session theSession = NXOpen.Session.GetSession();
//            NXOpen.Part workPart = theSession.Parts.Work;
//            NXOpen.Part displayPart = theSession.Parts.Display;
//            // ----------------------------------------------
//            //   Menu: Insert->Sketch Curve->Project Curve...
//            // ----------------------------------------------
           

//            NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
//            NXOpen.SketchProjectBuilder sketchProjectBuilder1;
//            sketchProjectBuilder1 = workPart.Sketches.CreateProjectBuilder(nullNXOpen_Features_Feature);

//            sketchProjectBuilder1.Tolerance = 0.025399999999999999;

//            sketchProjectBuilder1.Section.PrepareMappingData();

//            sketchProjectBuilder1.Section.DistanceTolerance = 0.025399999999999999;

//            sketchProjectBuilder1.Section.ChainingTolerance = 0.024129999999999999;

//            sketchProjectBuilder1.Section.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.CurvesAndPoints);

//            NXOpen.Session.UndoMarkId markId2;
//            markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "section mark");

//            NXOpen.Session.UndoMarkId markId3;
//            markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, null);

//            NXOpen.Features.Feature[] features1 = new NXOpen.Features.Feature[1];
//            NXOpen.Features.SketchFeature sketchFeature1 = (NXOpen.Features.SketchFeature)workPart.Features.FindObject("SKETCH(3)");
//            features1[0] = sketchFeature1;
//            NXOpen.CurveFeatureRule curveFeatureRule1;
//            curveFeatureRule1 = workPart.ScRuleFactory.CreateRuleCurveFeature(features1);

//            sketchProjectBuilder1.Section.AllowSelfIntersection(true);

//            NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
//            rules1[0] = curveFeatureRule1;
//            NXOpen.NXObject nullNXOpen_NXObject = null;
//            NXOpen.Point3d helpPoint1 = new NXOpen.Point3d(-22.668578853989747, 0.0, 7.0424936165942631);
//            sketchProjectBuilder1.Section.AddToSection(rules1, nullNXOpen_NXObject, nullNXOpen_NXObject, nullNXOpen_NXObject, helpPoint1, NXOpen.Section.Mode.Create, false);


//            sketchProjectBuilder1.Section.CleanMappingData();

//            sketchProjectBuilder1.Section.CleanMappingData();

//            sketchProjectBuilder1.ProjectAsDumbFixedCurves = false;

//            NXOpen.NXObject nXObject1;
//            nXObject1 = sketchProjectBuilder1.Commit();


//            sketchProjectBuilder1.Destroy();

//            // ----------------------------------------------
//            //   Menu: Tools->Journal->Stop Recording
//            // ----------------------------------------------

//        }
//        public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
//    }

//}
