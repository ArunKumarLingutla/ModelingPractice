using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingPractice
{
    public class SelectionManagerPractice
    {
        public static void SelectionManagerTest()
        {
            var sel=NXOpen.UI.GetUI().SelectionManager;
            View myView = null;
            sel.SelectTaggedObject("Select tagged Object", "Tagged Object", Selection.SelectionScope.WorkPart, true, false, out TaggedObject obj, out _);
            NXLogger.Instance.Log($"Selected Object: {obj}, {obj.GetType()}");
            Vector3d vector3d = new Vector3d(1.0, 2.0, 3.0);
            Vector3d vector3d2 = new Vector3d(4.0, 5.0, 6.0);

            
        }
    }
}
