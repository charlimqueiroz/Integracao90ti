using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace Integracao90ti.Main.GUI
{
    public partial class FAssociacao : System.Windows.Forms.Form
    {
        private Document _document;

        public FAssociacao()
        {
            InitializeComponent();
        }

        public FAssociacao(Document document)
        {
            _document = document;
        }
    }
}
