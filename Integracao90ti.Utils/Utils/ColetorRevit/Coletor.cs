using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace Integracao90ti.Utils
{
    public static class Coletor
    {

        public static List<T> BuscarFamilia<T>(Document doc, BuiltInCategory builtInCategory)
        {
            FilteredElementCollector coletor = new FilteredElementCollector(doc);
            //var elementos = coletor.WherePasses(new ElementCategoryFilter(builtInCategory, false)).OfCategory(builtInCategory).ToList();
            ICollection<Element> elementos;
            if (builtInCategory == 0)
                elementos = coletor.OfClass(typeof(T)).WhereElementIsNotElementType().ToElements();
            else
                elementos = coletor.OfClass(typeof(T)).OfCategory(builtInCategory).ToElements();

            List<T> List_Columns = new List<T>();
            foreach (object w in elementos)
            {
                List_Columns.Add((T)w);
            }
            return List_Columns;
        }
    }
}
