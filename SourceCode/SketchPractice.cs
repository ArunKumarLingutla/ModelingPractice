using NXOpen;
using NXOpen.Features;

namespace ModelingPractice
{
    public class SketchPractice
    {
        public static Feature ActivateSketch(double[] normal, double[] origin,out Sketch sketch)
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

            sketch = (NXOpen.Sketch)nXObject1;
            NXOpen.Features.Feature feature1 = sketch.Feature;

            sketch.Activate(NXOpen.Sketch.ViewReorient.True);

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

        public static void CreateSSketchLine(double[] startPoint, double[] endPoint)
        {
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
            // ----------------------------------------------
            //   Menu: Insert->Sketch...
            // ----------------------------------------------

            NXOpen.Sketch nullNXOpen_Sketch = null;
            NXOpen.SketchInPlaceBuilder sketchInPlaceBuilder1;
            sketchInPlaceBuilder1 = workPart.Sketches.CreateSketchInPlaceBuilder2(nullNXOpen_Sketch);

            NXOpen.Point3d origin1 = new NXOpen.Point3d(0.0, 0.0, 0.0);
            NXOpen.Vector3d normal1 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Plane plane1;
            plane1 = workPart.Planes.CreatePlane(origin1, normal1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            sketchInPlaceBuilder1.PlaneReference = plane1;

            //NXOpen.Unit unit1 = (NXOpen.Unit)workPart.UnitCollection.FindObject("MilliMeter");
            //NXOpen.Expression expression1;
            //expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            //NXOpen.Expression expression2;
            //expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            NXOpen.SketchAlongPathBuilder sketchAlongPathBuilder1;
            sketchAlongPathBuilder1 = workPart.Sketches.CreateSketchAlongPathBuilder(nullNXOpen_Sketch);

            sketchAlongPathBuilder1.PlaneLocation.Expression.RightHandSide = "0";


            NXOpen.Point3d coordinates1 = new NXOpen.Point3d(0.0, -50.0, 0.0);
            NXOpen.Point point1;
            point1 = workPart.Points.CreatePoint(coordinates1);

            NXOpen.DatumAxis datumAxis1 = (NXOpen.DatumAxis)workPart.Datums.FindObject("FIXED_DATUM_AXIS(2)");
            NXOpen.Direction direction1;
            direction1 = workPart.Directions.CreateDirection(datumAxis1, NXOpen.Sense.Forward, NXOpen.SmartObject.UpdateOption.WithinModeling);

            NXOpen.DatumPlane datumPlane1 = (NXOpen.DatumPlane)workPart.Datums.FindObject("DATUM_PLANE(7)");
            NXOpen.Xform xform1;
            xform1 = workPart.Xforms.CreateXformByPlaneXDirPoint(datumPlane1, direction1, point1, NXOpen.SmartObject.UpdateOption.WithinModeling, 0.625, false, false);

            NXOpen.CartesianCoordinateSystem cartesianCoordinateSystem1;
            cartesianCoordinateSystem1 = workPart.CoordinateSystems.CreateCoordinateSystem(xform1, NXOpen.SmartObject.UpdateOption.WithinModeling);

            sketchInPlaceBuilder1.Csystem = cartesianCoordinateSystem1;

            NXOpen.Point3d origin2 = new NXOpen.Point3d(0.0, 0.0, 0.0);
            NXOpen.Vector3d normal2 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Plane plane2;
            plane2 = workPart.Planes.CreatePlane(origin2, normal2, NXOpen.SmartObject.UpdateOption.WithinModeling);

            plane2.SetMethod(NXOpen.PlaneTypes.MethodType.Coincident);

            NXOpen.NXObject[] geom1 = new NXOpen.NXObject[1];
            geom1[0] = datumPlane1;
            plane2.SetGeometry(geom1);

            plane2.SetFlip(false);

            plane2.SetExpression(null);

            plane2.SetAlternate(NXOpen.PlaneTypes.AlternateType.One);

            plane2.Evaluate();

            NXOpen.Point3d origin3 = new NXOpen.Point3d(0.0, 0.0, 0.0);
            NXOpen.Vector3d normal3 = new NXOpen.Vector3d(0.0, 0.0, 1.0);
            NXOpen.Plane plane3;
            plane3 = workPart.Planes.CreatePlane(origin3, normal3, NXOpen.SmartObject.UpdateOption.WithinModeling);

            //NXOpen.Expression expression3;
            //expression3 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            //NXOpen.Expression expression4;
            //expression4 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);

            plane3.SynchronizeToPlane(plane2);

            plane3.SetMethod(NXOpen.PlaneTypes.MethodType.Coincident);

            NXOpen.NXObject[] geom2 = new NXOpen.NXObject[1];
            geom2[0] = datumPlane1;
            plane3.SetGeometry(geom2);

            plane3.SetAlternate(NXOpen.PlaneTypes.AlternateType.One);

            plane3.Evaluate();

            theSession.Preferences.Sketch.CreateInferredConstraints = true;

            theSession.Preferences.Sketch.ContinuousAutoDimensioning = true;

            theSession.Preferences.Sketch.DimensionLabel = NXOpen.Preferences.SketchPreferences.DimensionLabelType.Expression;

            theSession.Preferences.Sketch.TextSizeFixed = true;

            theSession.Preferences.Sketch.FixedTextSize = 3.0;

            theSession.Preferences.Sketch.DisplayParenthesesOnReferenceDimensions = true;

            theSession.Preferences.Sketch.DisplayReferenceGeometry = false;

            theSession.Preferences.Sketch.ConstraintSymbolSize = 3.0;

            theSession.Preferences.Sketch.DisplayObjectColor = false;

            theSession.Preferences.Sketch.DisplayObjectName = true;

            NXOpen.NXObject nXObject1;
            nXObject1 = sketchInPlaceBuilder1.Commit();

            NXOpen.Sketch sketch1 = (NXOpen.Sketch)nXObject1;
            NXOpen.Features.Feature feature1;
            feature1 = sketch1.Feature;

            sketch1.Activate(NXOpen.Sketch.ViewReorient.True);


            sketchInPlaceBuilder1.Destroy();

            sketchAlongPathBuilder1.Destroy();


            plane1.DestroyPlane();

            plane3.DestroyPlane();

            // ----------------------------------------------
            //   Menu: Insert->Sketch Curve->Line...
            // ----------------------------------------------
           
            NXOpen.Point3d startPoint1 = new NXOpen.Point3d(0.0, -50.0, 0.0);
            NXOpen.Point3d endPoint1 = new NXOpen.Point3d(42.803475685538388, -50.0, -18.168997474751425);
            NXOpen.Line line1;
            line1 = workPart.Curves.CreateLine(startPoint1, endPoint1);

            theSession.ActiveSketch.AddGeometry(line1, NXOpen.Sketch.InferConstraintsOption.InferNoConstraints);

            NXOpen.Sketch.ConstraintGeometry geom1_1 = new NXOpen.Sketch.ConstraintGeometry();
            geom1_1.Geometry = line1;
            geom1_1.PointType = NXOpen.Sketch.ConstraintPointType.StartVertex;
            geom1_1.SplineDefiningPointIndex = 0;
            NXOpen.Sketch.ConstraintGeometry geom2_1 = new NXOpen.Sketch.ConstraintGeometry();
            NXOpen.Features.DatumCsys datumCsys1 = (NXOpen.Features.DatumCsys)workPart.Features.FindObject("SKETCH(8:1B)");
            NXOpen.Point point2 = (NXOpen.Point)datumCsys1.FindObject("POINT 1");
            geom2_1.Geometry = point2;
            geom2_1.PointType = NXOpen.Sketch.ConstraintPointType.None;
            geom2_1.SplineDefiningPointIndex = 0;
            NXOpen.SketchGeometricConstraint sketchGeometricConstraint1;
            sketchGeometricConstraint1 = theSession.ActiveSketch.CreateCoincidentConstraint(geom1_1, geom2_1);

            NXOpen.Sketch.DimensionGeometry dimObject1_1 = new NXOpen.Sketch.DimensionGeometry();
            dimObject1_1.Geometry = line1;
            dimObject1_1.AssocType = NXOpen.Sketch.AssocType.StartPoint;
            dimObject1_1.AssocValue = 0;
            dimObject1_1.HelpPoint.X = 0.0;
            dimObject1_1.HelpPoint.Y = 0.0;
            dimObject1_1.HelpPoint.Z = 0.0;
            NXOpen.NXObject nullNXOpen_NXObject = null;
            dimObject1_1.View = nullNXOpen_NXObject;
            NXOpen.Sketch.DimensionGeometry dimObject2_1 = new NXOpen.Sketch.DimensionGeometry();
            dimObject2_1.Geometry = line1;
            dimObject2_1.AssocType = NXOpen.Sketch.AssocType.EndPoint;
            dimObject2_1.AssocValue = 0;
            dimObject2_1.HelpPoint.X = 0.0;
            dimObject2_1.HelpPoint.Y = 0.0;
            dimObject2_1.HelpPoint.Z = 0.0;
            dimObject2_1.View = nullNXOpen_NXObject;
            NXOpen.Point3d dimOrigin1 = new NXOpen.Point3d(20.227992399564819, -50.0, -11.849669716623552);
            NXOpen.Expression nullNXOpen_Expression = null;
            NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint1;
            sketchDimensionalConstraint1 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.ParallelDim, dimObject1_1, dimObject2_1, dimOrigin1, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);

            NXOpen.SketchHelpedDimensionalConstraint sketchHelpedDimensionalConstraint1 = (NXOpen.SketchHelpedDimensionalConstraint)sketchDimensionalConstraint1;
            NXOpen.Annotations.Dimension dimension1;
            dimension1 = sketchHelpedDimensionalConstraint1.AssociatedDimension;

            NXOpen.Expression expression5;
            expression5 = sketchHelpedDimensionalConstraint1.AssociatedExpression;

            NXOpen.Sketch.DimensionGeometry dimObject1_2 = new NXOpen.Sketch.DimensionGeometry();
            dimObject1_2.Geometry = line1;
            dimObject1_2.AssocType = NXOpen.Sketch.AssocType.EndPoint;
            dimObject1_2.AssocValue = 0;
            dimObject1_2.HelpPoint.X = 42.803475685538388;
            dimObject1_2.HelpPoint.Y = -50.0;
            dimObject1_2.HelpPoint.Z = -18.168997474751425;
            dimObject1_2.View = nullNXOpen_NXObject;
            NXOpen.Sketch.DimensionGeometry dimObject2_2 = new NXOpen.Sketch.DimensionGeometry();
            NXOpen.DatumAxis datumAxis2 = (NXOpen.DatumAxis)workPart.Datums.FindObject("SKETCH(8:1B) X axis");
            dimObject2_2.Geometry = datumAxis2;
            dimObject2_2.AssocType = NXOpen.Sketch.AssocType.EndPoint;
            dimObject2_2.AssocValue = 0;
            dimObject2_2.HelpPoint.X = 28.574999999999999;
            dimObject2_2.HelpPoint.Y = -50.0;
            dimObject2_2.HelpPoint.Z = 0.0;
            dimObject2_2.View = nullNXOpen_NXObject;
            NXOpen.Point3d dimOrigin2 = new NXOpen.Point3d(2.9436665596087854, -50.0, -0.59889573028906473);
            NXOpen.SketchDimensionalConstraint sketchDimensionalConstraint2;
            sketchDimensionalConstraint2 = theSession.ActiveSketch.CreateDimension(NXOpen.Sketch.ConstraintType.AngularDim, dimObject1_2, dimObject2_2, dimOrigin2, nullNXOpen_Expression, NXOpen.Sketch.DimensionOption.CreateAsAutomatic);

            NXOpen.Annotations.Dimension dimension2;
            dimension2 = sketchDimensionalConstraint2.AssociatedDimension;

            NXOpen.Expression expression6;
            expression6 = sketchDimensionalConstraint2.AssociatedExpression;

            theSession.Preferences.Sketch.AutoDimensionsToArcCenter = false;

            theSession.ActiveSketch.Update();

            theSession.Preferences.Sketch.AutoDimensionsToArcCenter = true;

            // ----------------------------------------------
            //   Dialog Begin Line
            // ----------------------------------------------
            // ----------------------------------------------
            //   Menu: File->Finish Sketch
            // ----------------------------------------------
            NXOpen.Sketch sketch2;
            sketch2 = theSession.ActiveSketch;

            NXOpen.Session.UndoMarkId markId7;
            markId7 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Deactivate Sketch");

            theSession.ActiveSketch.Deactivate(NXOpen.Sketch.ViewReorient.True, NXOpen.Sketch.UpdateLevel.Model);

            // ----------------------------------------------
            //   Menu: Tools->Journal->Stop Recording
            // ----------------------------------------------

        }

        /// <summary>
        /// Create sketch curve by intersection method, between a face and sketch plane, the curve is not associative to the face, so it will not update when the face changes. If you want to create associative
        /// </summary>
        /// <param name="face"> the face you want to intersect with the sketch plane</param>
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

            sketchIntersectionCurveBuilder1.Associative = true;

            var feature1 = sketchIntersectionCurveBuilder1.Commit();
            //var objs= sketchIntersectionCurveBuilder1.GetCommittedObjects();
            //NXOpen.UI.GetUI().NXMessageBox.Show("Intersection Curve objects", NXMessageBox.DialogType.Information, objs==null?"Null":objs.GetType().ToString());
            sketchIntersectionCurveBuilder1.Destroy();

            scCollector1.Destroy();

        }
    }
}
