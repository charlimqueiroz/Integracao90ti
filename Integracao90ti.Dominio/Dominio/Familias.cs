
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Integracao90ti.Comum.Enum.Enum;

namespace Integracao90ti.Dominio
{
    public class Familias
    {

        public struct CategoriaSuportada
        {
            public CategoriaSuportada(Type tipo, Type instancia, BuiltInCategory categoria, Unidade unidade/*, string nome*/)
            {
                Tipo = tipo;
                Instancia = instancia;
                Categoria = categoria;
                Unidade = unidade;
                //Nome = nome;
            }

            public Type Tipo { get; private set; }
            public Type Instancia { get; private set; }
            public BuiltInCategory Categoria { get; private set; }
            public Unidade Unidade { get; private set; }
            //public string Nome { get; private set; }
        }

        public static CategoriaSuportada[] CategoriasSuportadas()
        {
            return new CategoriaSuportada[] {
                new CategoriaSuportada(typeof(StairsType), typeof(Stairs), BuiltInCategory.OST_Stairs, Unidade.Quantidade), // escadas
                new CategoriaSuportada(typeof(FloorType), typeof(Floor), BuiltInCategory.OST_Floors, Unidade.Area),
                new CategoriaSuportada(typeof(Floor), typeof(Floor), BuiltInCategory.OST_Floors, Unidade.Area),
                new CategoriaSuportada(typeof(WallType), typeof(Wall), BuiltInCategory.OST_Walls, Unidade.Area),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Columns, Unidade.Volume),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Doors, Unidade.Area),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Windows, Unidade.Area),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_PlumbingFixtures, Unidade.Quantidade),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_GenericModel, Unidade.Quantidade),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Columns, Unidade.Quantidade),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Furniture, Unidade.Quantidade),
                new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_SpecialityEquipment, Unidade.Quantidade)
            };
        }

        //public static List<CategoriaSuportada> CategoriasSuportadas = new List<CategoriaSuportada>();
    }
}
