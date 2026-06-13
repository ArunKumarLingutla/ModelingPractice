using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NXOpen.LoadOptions;

namespace ModelingPractice
{
    public class FeaturePractice
    {
        public static void PrintFeatureDetailsInLW()
        {
            ListingWindow lw = Session.GetSession().ListingWindow;
            lw.Open();

            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;

            foreach (NXOpen.Features.Feature feature in workPart.Features)
            {
                //Gives 'Fixed Datum Axis(1)' these kind of name most near to the type of that feature
                string name = feature.GetFeatureName();
                //Gives user defined name inside double quotes "CarBody" if assigned or will give empty name
                var userDefinedName = feature.Name;
                //Journal identifier is the unique identifier for that feature which is used in journal file to identify that feature and replay the same feature
                var journalIdentifier = feature.JournalIdentifier;
                //Gives the type of that feature like class name 'NXOpen.Features.FixedDatumAxis' or 'NXOpen.Features.FaceBlend' etc
                string type = feature.GetType().ToString();
                //Gives the type of that feature like 'ABSOLUTE_DATUM_PLANE' or 'SKETCH' 'EXTRUDE' etc
                var realFeatureType =feature.FeatureType;
                //entities are Unique objects created by feature and own exclusively
                var entities = feature.GetEntities();
                //parents are the features which are used to create that feature and have ownership relation with that feature
                var parents = feature.GetParents();
                bool isSupressed = feature.Suppressed;
                var allChildren= feature.GetAllChildren();
                //NXOpen.Body[] bodies = feature.GetBodies();
                lw.WriteLine("------------------------------------------------------------------------------");
                lw.WriteLine($"Feature Name [feature.GetFeatureName()]      :{name}");
                lw.WriteLine($"Feature Name [feature.Name]                  :{userDefinedName}");
                lw.WriteLine($"Feature Journal Identifier [feature.JournalIdentifier]    :{journalIdentifier}");
                lw.WriteLine($"Feature Type [feature.GetType().ToString()]  :{type}");
                lw.WriteLine($"Feature Type [feature.FeatureType]           :{realFeatureType}");
                lw.WriteLine($"Number of Entities [feature.GetEntities()]   :{entities.Length}");
                foreach (var entity in entities)
                {
                    lw.WriteLine($"     * entity name                            :{entity.Name}");
                    lw.WriteLine($"     * entity type                            :{entity.GetType()}");
                }
                lw.WriteLine($"Number of Parents [feature.GetParents()]     :{parents.Length}");
                foreach (var parent in parents)
                {
                    lw.WriteLine($"     * Parent                                :{parent.GetFeatureName()} - {parent.Name}");
                    lw.WriteLine($"     * Parent type                           :{parent.GetType()}");
                }
                lw.WriteLine($"Number of Children [feature.GetAllChildren()]:{allChildren.Length}");
                foreach (var child in allChildren)
                {
                    lw.WriteLine($"     * Child                                 :{child.GetFeatureName()} - {child.Name}");
                    lw.WriteLine($"     * Child type                            :{child.GetType()}");
                }
                //foreach (var body in bodies) 
                //{
                //    body.Highlight();
                //    lw.WriteLine("Heilighted");
                //}
                lw.WriteLine("------------------------------------------------------------------------------");
            }
        }
    }
}
