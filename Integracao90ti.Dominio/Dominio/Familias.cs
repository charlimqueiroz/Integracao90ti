using Autodesk.Revit.DB;
using Integracao90ti.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using static Integracao90ti.Comum.Enum.Enum;

namespace Integracao90ti.Dominio
{
    public class Familias
    {
        public BuiltInCategory Categoria { get; set; }
        public Unidade Unidade { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
        public string NomeTipo { get; set; }

        public Familias()
        {
                
        }

        public IList<Familias> BuscarFamilias(Document document)
        {
            List<Familias> familias = new List<Familias>();

            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_Columns, Unidade.Area, "Colunas")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_StructuralColumns, Unidade.Area, "Coluna Estrutural")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_Stairs, Unidade.Quantidade, "Escadas")).ToList(); 
            familias = familias.Concat(MontarFamilia<Ceiling>(document, new BuiltInCategory(), Unidade.Area, "Forro")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_StructuralFoundation, Unidade.Area, "Fundação Estrutural")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_RailingHandRail, Unidade.Quantidade, "Guarda Corpo")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_Windows, Unidade.Quantidade, "Janela")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_Furniture, Unidade.Quantidade, "Mobiliario")).ToList();
            familias = familias.Concat(MontarFamilia<Wall>(document, new BuiltInCategory(), Unidade.Area, "Parede")).ToList();
            familias = familias.Concat(MontarFamilia<Floor>(document, new BuiltInCategory(), Unidade.Area, "Pisos")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_Doors, Unidade.Quantidade, "Portas")).ToList();
            familias = familias.Concat(MontarFamilia<FamilyInstance>(document, BuiltInCategory.OST_Ramps, Unidade.Area, "Rampas")).ToList();
            familias = familias.Concat(MontarFamilia<RoofBase>(document, new BuiltInCategory(), Unidade.Area, "Telhado")).ToList();

            return familias;
        }

        private static List<Familias> MontarFamilia<T>(Document document, BuiltInCategory categoria, Unidade unidade, string nome)
        {
            List<Familias> familias = new List<Familias>();

            var familiaRevit = Coletor.BuscarFamilia<T>(document, categoria);

            double quantidade = 0;
            string nomeTipo = string.Empty;
            foreach (var item in familiaRevit)
            {
                nomeTipo = BuscarPorPropriedade(item, "Name");

                switch (unidade)
                {
                    case Unidade.Quantidade:
                        quantidade = 1;
                        break;
                    case Unidade.Area:
                        quantidade = (item as Element).GetParameters("Área")[0].AsDouble();
                        break;
                    case Unidade.Linear:
                        quantidade = (item as Element).GetParameters("Height")[0].AsDouble();
                        break;
                    case Unidade.Volume:
                        quantidade = (item as Element).GetParameters("Volume")[0].AsDouble();
                        break;
                    case Unidade.Altura:
                        quantidade = (item as Element).GetParameters("Width")[0].AsDouble();
                        break;
                    case Unidade.Dimensao:
                        quantidade = (item as Element).GetParameters("Width")[0].AsDouble() * (item as Element).GetParameters("Height")[0].AsDouble();
                        break;
                }

                var novaFamilia = new Familias { Categoria = categoria, Nome = nome, Quantidade = quantidade, Unidade = Unidade.Area, NomeTipo = nomeTipo };

                var familia = familias.Where(i => i.NomeTipo == nomeTipo).SingleOrDefault();

                if (familia != null)
                {
                    familias.Remove(familia);
                    novaFamilia.Quantidade += familia.Quantidade;
                    familias.Add(novaFamilia);
                }
                else
                {
                    familias.Add(novaFamilia);
                }
            }

            if (familias.Count == 0)
                familias.Add(new Familias { Categoria = categoria, Nome = nome, Quantidade = quantidade, Unidade = Unidade.Area, NomeTipo = nomeTipo });

            return familias.ToList();

        }

        private static string BuscarPorPropriedade<T>(T item, string nomePropriedade)
        {
            var props = item.GetType().GetProperties();
            var prop = props.Where(i => i.Name == nomePropriedade).FirstOrDefault();

            return prop.GetValue(item, null).ToString();
        }


            //public struct CategoriaSuportada
            //{
            //    public CategoriaSuportada(Type tipo, Type instancia, BuiltInCategory categoria, Unidade unidade/*, string nome*/)
            //    {
            //        Tipo = tipo;
            //        Instancia = instancia;
            //        Categoria = categoria;
            //        Unidade = unidade;
            //        //Nome = nome;
            //    }

            //    public Type Tipo { get; private set; }
            //    public Type Instancia { get; private set; }
            //    public BuiltInCategory Categoria { get; private set; }
            //    public Unidade Unidade { get; private set; }
            //    //public string Nome { get; private set; }
            //}

            //public static CategoriaSuportada[] CategoriasSuportadas()
            //{
            //    return new CategoriaSuportada[] {
            //        new CategoriaSuportada(typeof(StairsType), typeof(Stairs), BuiltInCategory.OST_Stairs, Unidade.Quantidade), // escadas
            //        new CategoriaSuportada(typeof(FloorType), typeof(Floor), BuiltInCategory.OST_Floors, Unidade.Area),
            //        new CategoriaSuportada(typeof(Floor), typeof(Floor), BuiltInCategory.OST_Floors, Unidade.Area),
            //        new CategoriaSuportada(typeof(WallType), typeof(Wall), BuiltInCategory.OST_Walls, Unidade.Area),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Columns, Unidade.Volume),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Doors, Unidade.Area),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Windows, Unidade.Area),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_PlumbingFixtures, Unidade.Quantidade),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_GenericModel, Unidade.Quantidade),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Columns, Unidade.Quantidade),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_Furniture, Unidade.Quantidade),
            //        new CategoriaSuportada(typeof(FamilySymbol), typeof(FamilyInstance), BuiltInCategory.OST_SpecialityEquipment, Unidade.Quantidade)
            //    };
            //}

            //public static List<CategoriaSuportada> CategoriasSuportadas = new List<CategoriaSuportada>();
        }
    }
