/////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved
// Written by Forge Partner Development
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
/////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using Integracao90ti.Main.Comandos;
using static Integracao90ti.Comum.Enum.Enum;
using Integracao90ti.Dominio;
using Integracao90ti.Main.GUI;

namespace Integracao90ti.Main.Comandos
{
    [Transaction(TransactionMode.Manual)]
    public class CmdAplicarParametros : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            Autodesk.Revit.ApplicationServices.Application app = commandData.Application.Application;
            CategorySet catSet = app.Create.NewCategorySet();

            foreach (Familias.CategoriaSuportada categoria in Familias.CategoriasSuportadas())
                catSet.Insert(doc.Settings.Categories.get_Item(categoria.Categoria));

            SharedParameterFunctions.OpenOrCreateParameter(doc, "Compor90", "Compor90Revit", catSet);

            MessageBox.Show("Parâmetro criado com sucesso.");

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class CmdAtribuirParametros : IExternalCommand
    {
        Document _document;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            _document = commandData.Application.ActiveUIDocument.Document;

            FAssociacao fAssociacao = new FAssociacao(_document);
            fAssociacao.StartPosition = FormStartPosition.CenterScreen;
            fAssociacao.ShowDialog();
            //form.ElementoSelecionado += Form_ElementoSelecionado;



            //foreach (Familias.CategoriaSuportada categoria in Familias.CategoriasSuportadas())
            //{
            //    System.Windows.Forms.TreeNode treeNodeCategoria = null;

            //    FilteredElementCollector tipos = new FilteredElementCollector(_document);
            //    tipos.OfCategory(categoria.Categoria);
            //    tipos.OfClass(categoria.Tipo);

            //    foreach (var tipo in tipos)
            //    {
            //        List<Element> elementos = new List<Element>();
            //        List<System.Windows.Forms.TreeNode> listaNosInstancias = new List<System.Windows.Forms.TreeNode>();

            //        FilteredElementCollector instancias = new FilteredElementCollector(_document);
            //        instancias.OfClass(categoria.Instancia);
            //        instancias.OfCategory(categoria.Categoria);

            //        if (tipo is FamilySymbol)
            //            elementos = instancias.WherePasses(new FamilyInstanceFilter(_document, tipo.Id)).Select(i => i).ToList();
            //        else
            //        if (tipo is WallType)
            //            elementos = instancias.Where(i => (i as Wall).WallType.Id == tipo.Id).ToList();
            //        else
            //        if (tipo is FloorType)
            //            elementos = instancias.Where(i => (i as Floor).FloorType.Id == tipo.Id).ToList();
            //        else
            //        if (tipo is StairsType)
            //            elementos = instancias.WherePasses(new ElementCategoryFilter(BuiltInCategory.OST_Stairs, false)).ToList();

            //        foreach (Element elemento in elementos)
            //        {
            //            if (elemento.GetParameters("Compor90").Count != 1)
            //                continue;

            //            if (treeNodeCategoria == null)
            //            {
            //                string key = string.Empty;


            //                if (tipo is FamilySymbol)
            //                    key = (tipo as FamilySymbol).FamilyName;
            //                else
            //                if (tipo is WallType)
            //                    key = (tipo as WallType).FamilyName;
            //                else
            //                if (tipo is FloorType)
            //                    key = (tipo as FloorType).FamilyName;
            //                else
            //                if (tipo is StairsType)
            //                    key = (tipo as StairsType).FamilyName;

            //                treeNodeCategoria = new System.Windows.Forms.TreeNode(key);
            //                treeNodeCategoria.Text = key;
            //                treeNodeCategoria.Tag = tipo.Id.IntegerValue.ToString();
            //            }

            //            bool encontrou = false;
            //            // verifico se a instancia existe no nó de categoria
            //            for (int i = 0; i < treeNodeCategoria.Nodes.Count; i++)
            //            {
            //                if (treeNodeCategoria.Nodes[i].Text == elemento.Name)
            //                {
            //                    encontrou = true;
            //                    break;
            //                }
            //            }

            //            System.Windows.Forms.TreeNode treeNodeInstancia = new System.Windows.Forms.TreeNode(elemento.Name);
            //            treeNodeInstancia.Tag = elemento.Id.IntegerValue.ToString();

            //            if (!encontrou)
            //            {
            //                treeNodeCategoria.Nodes.Add(treeNodeInstancia);
            //            }

            //            listaNosInstancias.Add(treeNodeInstancia);
            //        }

            //        try
            //        {
            //            if (treeNodeCategoria != null)
            //            {
            //                for (int i = 0; i < treeNodeCategoria.Nodes.Count; i++)
            //                {
            //                    foreach (var item in listaNosInstancias)
            //                    {
            //                        if (treeNodeCategoria.Nodes[i].Text == item.Text)
            //                        {
            //                            System.Windows.Forms.TreeNode treeNodeInstancia = new System.Windows.Forms.TreeNode(item.Text);
            //                            treeNodeInstancia.Tag = item.Tag.ToString();
            //                            treeNodeCategoria.Nodes[i].Nodes.Add(treeNodeInstancia);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            string erro = e.Message;
            //        }
            //    }

            //    if (treeNodeCategoria != null)
            //    {
            //        //form.Tree.Add(treeNodeCategoria);
            //    }
            //}

            //Transaction trans = new Transaction(_document);
            //trans.Start("Aplicando SINAPI");
            ////form.ShowDialog();
            //trans.Commit();
            return Result.Succeeded;
        }

        private void Form_ElementoSelecionado(int elementId, string sinapi)
        {
            ElementId id = new ElementId(elementId);
            Parameter param = _document.GetElement(id).GetParameters("Compor90")[0];
            param.Set(sinapi);
        }

    }

    [Transaction(TransactionMode.Manual)]
    public class FConfiguracaoComando : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            FConfiguracao fConfiguracao = new FConfiguracao();
            fConfiguracao.StartPosition = FormStartPosition.CenterScreen;
            fConfiguracao.ShowDialog();

            return Result.Succeeded;
        }
    }




    [Transaction(TransactionMode.Manual)]
    public class CmdExtrairDados : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                // ToDo:
                // gerar CSV da variável ITEMS
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV | *.csv";
                saveDialog.Title = "Exportar quantitativo CSV";
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\Autodesk\\REVIT\\Addins\\2019";
                saveDialog.FileName = "QuantitativoCompor.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK && saveDialog.FileName != "")
                {

                    Document doc = commandData.Application.ActiveUIDocument.Document;
                    List<ElementId> naoEspecificados = new List<ElementId>();

                    Dictionary<string, double> items = new Dictionary<string, double>();
                    foreach (Familias.CategoriaSuportada categoria in Familias.CategoriasSuportadas())
                        naoEspecificados.AddRange(BuscarItems(items, doc, categoria.Instancia, categoria.Categoria, categoria.Unidade));

                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                    {
                        foreach (KeyValuePair<string, double> item in items)
                        {
                            string descricao = BuscarDescricao(item.Key);
                            sw.WriteLine(item.Key + ";" + descricao + ";" + item.Value);
                        }
                    }

                    MessageBox.Show("Arquivo exportado com sucesso.");
                    return Result.Succeeded;
                }
                else
                {
                    MessageBox.Show("Arquivo não foi exportado.");
                    return Result.Succeeded;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível exportar o arquivo. " + e.Message);
                return Result.Failed;
            }


        }

        private string BuscarDescricao(string key)
        {
            var arquivoSinapi = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\Autodesk\\REVIT\\Addins\\2019\\comp_sinapi.txt";

            string[] lines = System.IO.File.ReadAllLines(arquivoSinapi, Encoding.GetEncoding("iso-8859-1"));

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            string texto = lines.Where(i => i.Contains(key)).Select(i => i.Substring(i.IndexOf("-") + 1).Trim()).FirstOrDefault();

            return texto;
        }

        private List<ElementId> BuscarItems(Dictionary<string, double> items, Document doc, Type typeInstancias, BuiltInCategory categoria, Unidade unidade)
        {

            List<ElementId> naoEspecificados = new List<ElementId>();

            FilteredElementCollector instancias = new FilteredElementCollector(doc);
            instancias.OfCategory(categoria);
            instancias.OfClass(typeInstancias);

            foreach (Element instancia in instancias)
            {
                if (instancia.GetParameters("Compor90").Count != 1) continue;
                string sinapi = instancia.GetParameters("Compor90")[0].AsString();
                if (string.IsNullOrWhiteSpace(sinapi))
                {
                    naoEspecificados.Add(instancia.Id);
                    continue;
                }
                if (!items.ContainsKey(sinapi)) items.Add(sinapi, 0);

                double quantidade = 0;
                switch (unidade)
                {
                    case Unidade.Quantidade:
                        quantidade++;
                        break;
                    case Unidade.Area:
                        //var items = ((IEnumerable)instancia.Parameters);
                        //(new System.Linq.SystemCore_EnumerableDebugView(instancia.Parameters)).Items
                        //quantidade += instancia.Parameters.
                        quantidade += instancia.GetParameters("Área")[0].AsDouble();
                        break;
                    case Unidade.Linear:
                        quantidade += instancia.GetParameters("Height")[0].AsDouble();
                        break;
                    case Unidade.Volume:
                        quantidade += instancia.GetParameters("Volume")[0].AsDouble();
                        break;
                    case Unidade.Altura:
                        quantidade += instancia.GetParameters("Width")[0].AsDouble();
                        break;
                    case Unidade.Dimensao:
                        quantidade += instancia.GetParameters("Width")[0].AsDouble() * instancia.GetParameters("Height")[0].AsDouble();
                        break;
                }

                items[sinapi] += quantidade;
            }
            return naoEspecificados;
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class IdentificarComponente : IExternalCommand
    {

        //  Member variables 
        Autodesk.Revit.ApplicationServices.Application m_rvtApp;
        Document m_rvtDoc;

        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements)
        {
            //  Get the access to the top most objects. 
            UIApplication rvtUIApp = commandData.Application;
            UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
            m_rvtApp = rvtUIApp.Application;
            m_rvtDoc = rvtUIDoc.Document;

            // (1) pick an object on a screen.
            Reference refPick = rvtUIDoc.Selection.PickObject(
                ObjectType.Element, "Pick an element");

            // we have picked something. 
            Element elem = m_rvtDoc.GetElement(refPick);



            //Transaction trans = new Transaction(_document);
            //trans.Start("Aplicando SINAPI");
            //ElementosREVIT form = new ElementosREVIT();
            ///form.ShowDialog();
            //trans.Commit();

            // (2) let's see what kind of element we got. 
            ShowBasicElementInfo(elem);


            return Result.Succeeded;
        }

        public void ShowBasicElementInfo(Element elem)
        {
            // let's see what kind of element we got. 
            // 
            string s = "You Picked:" + "\n";

            s += " Class name = " + elem.GetType().Name + "\n";
            s += " Category = " + elem.Category.Name + "\n";
            s += " Element id = " + elem.Id.ToString() + "\n" + "\n";

            // and, check its type info. 
            // 
            //Dim elemType As ElementType = elem.ObjectType '' this is obsolete. 
            ElementId elemTypeId = elem.GetTypeId();
            ElementType elemType = (ElementType)m_rvtDoc.GetElement(elemTypeId);

            s += "Its ElementType:" + "\n";
            s += " Class name = " + elemType.GetType().Name + "\n";
            s += " Category = " + elemType.Category.Name + "\n";
            s += " Element type id = " + elemType.Id.ToString() + "\n";
            s += " BuiltInCategory = " + (elemType.Category.Id) + "\n";

            // finally show it. 

            TaskDialog.Show("Basic Element Info", s);
        }


    }
    [Transaction(TransactionMode.Manual)]
    public class ListarTodosElementos : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
                      ref string message,
                      ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            ListAllElements(doc);

            return Result.Succeeded;
        }

        void ListAllElements(Document _doc)
        {


            // Create an output file:

            string filename = Path.Combine(
              Path.GetTempPath(), "RevitElements.txt");

            StreamWriter sw = new StreamWriter(filename);

            // The Revit API does not expect an application
            // ever to need to iterate over all elements.
            // To do so, we need to use a trick: ask for all
            // elements fulfilling a specific criteria and
            // unite them with all elements NOT fulfilling
            // the same criteria; an arbitrary criterion 
            // could be chosen:

            FilteredElementCollector collector
              = new FilteredElementCollector(_doc)
                .WhereElementIsElementType();

            FilteredElementCollector collector2
              = new FilteredElementCollector(_doc)
                .WhereElementIsNotElementType();

            collector.UnionWith(collector2);

            // Loop over the elements and list their data:

            string s, line;

            foreach (Element e in collector)
            {

                // The element category is not implemented for all classes,
                // and may return null; for family elements, one can sometimes
                // use the FamilyCategory property instead.

                s = string.Empty;

                if (null != e.Category)
                {
                    s = e.Category.Name;
                }
                if (0 == s.Length && e is Family && null != ((Family)e).FamilyCategory)
                {
                    //s = ((Family)e).FamilyCategory.Name;
                }
                if (0 == s.Length)
                {
                    s = "?";
                }

                if (s != "?")
                {
                    line = "Id=" + e.Id.IntegerValue.ToString(); // element id
                    line += "; Class=" + e.GetType().Name; // element class, i.e. System.Type
                    line += "; Category=" + s;

                    // The element Name property has a different meaning for different classes,
                    // but is mostly implemented 'logically'. More precise info on elements
                    // can be obtained in class-specific ways.

                    line += "; Name=" + e.Name;

                    //line += "; UniqueId=" + e.UniqueId;
                    //line += "; Guid=" + GetGuid( e.UniqueId );

                    sw.WriteLine(line);
                }
            }
            sw.Close();

            TaskDialog.Show("List all elements",
              string.Format("Element list has been written to '{0}'.", filename));
        }

    }


}
