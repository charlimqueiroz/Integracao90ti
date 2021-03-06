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

using Autodesk.Revit.UI;
using Integracao90ti.Main.Comandos;
using System;
using System.Windows.Media.Imaging;

namespace Integracao90ti.Main
{
    class Aplicativo : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            a.CreateRibbonTab("Integração 90ti");
            RibbonPanel painel = a.CreateRibbonPanel("Integração 90ti", "Integração 90ti");

            //PushButtonData aplicarParametro = new PushButtonData("APLICAR_PARAMETRO", "Aplicar",
            //    System.Reflection.Assembly.GetExecutingAssembly().Location, typeof(CmdAplicarParametros).FullName);
            //Set the large image shown on button
            //aplicarParametro.LargeImage = new BitmapImage(new Uri(@"D:\Sistemas\Compor\work\Sinapi-Revit\SinapiRevit\Resources\aplicar.png"));
            //aplicarParametro.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/Compor90Revit;component/Resources/aplicar.png"));
            //painel.AddItem(aplicarParametro);

            PushButtonData fAssociacao = new PushButtonData("ASSOCIACAO", "Associar ao serviço \ndo Orçamento",
                System.Reflection.Assembly.GetExecutingAssembly().Location, typeof(FAssociacaoComando).FullName);
            //fAssociacao.LargeImage = new BitmapImage(new Uri(@"E:\Sistemas\NeoCompor\work\PluginRevit\Integracao90ti\Integracao90ti.Main\Main\Resources\icons8-retuitar-30.png"));
            fAssociacao.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/Integracao90ti.Main;component\Resources\icons8-retuitar-30.png"));
            painel.AddItem(fAssociacao);

            PushButtonData fConfiguracao = new PushButtonData("CONFIGURACAO", "Configuração \nbanco de dados",
                System.Reflection.Assembly.GetExecutingAssembly().Location, typeof(FConfiguracaoComando).FullName);
            fConfiguracao.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/Integracao90ti.Main;component\Resources\icons8-chave-inglesa-30.png"));
            //fConfiguracao.LargeImage = new BitmapImage(new Uri(@"E:\Sistemas\NeoCompor\work\PluginRevit\Integracao90ti\Integracao90ti.Main\Main\Resources\icons8-chave-inglesa-30.png"));
            painel.AddItem(fConfiguracao);

            //PushButtonData identificarElemento = new PushButtonData("IDENTIFICA_ELEMENTO", "Identificar \nComponente",
            //System.Reflection.Assembly.GetExecutingAssembly().Location, typeof(IdentificarComponente).FullName);
            //painel.AddItem(identificarElemento);

            //PushButtonData selecionarTodosElementos = new PushButtonData("SELECIONAR_ELEMENTOS", "Listar \nElementos",
            //    System.Reflection.Assembly.GetExecutingAssembly().Location, typeof(ListarTodosElementos).FullName);
            //painel.AddItem(selecionarTodosElementos);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
