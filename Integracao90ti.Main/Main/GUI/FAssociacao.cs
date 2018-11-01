using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Integracao90ti.Dominio;
using Integracao90ti.Dominio.Fabrica;
using Integracao90ti.Dominio.IRepositorio;
using Integracao90ti.Main.Comandos;

namespace Integracao90ti.Main.GUI
{
    public partial class FAssociacao : System.Windows.Forms.Form
    {
        private Document _document;
        private DataTable dataTableItens = new DataTable();

        public FAssociacao()
        {
            InitializeComponent();
        }

        public FAssociacao(Document document)
        {
            InitializeComponent();
            _document = document;

            MontarTreeView();
            CriarDataTableEGrid();
            CarregarComboBaseDados();
            CarregarComboProjeto();
        }

        private void CarregarComboBaseDados()
        {
            var basesDados = FabricaDeRepositorios<IBaseDadosRepositorio>.Instancia.BuscarTodos();

            cbBaseDados.BeginUpdate();
            cbBaseDados.DataSource = basesDados;
            cbBaseDados.ValueMember = "Codigo";
            cbBaseDados.DisplayMember = "Nome";
            cbBaseDados.SelectedIndex = -1;
            cbBaseDados.EndUpdate();
        }

        private void CarregarComboProjeto()
        {

            if (cbBaseDados.SelectedIndex == -1)
                return;

            var projetos = FabricaDeRepositorios<IProjetoRepositorio>.Instancia.BuscarPorIdBaseDados(((BaseDados)cbBaseDados.SelectedItem).Id);

            cbProjeto.BeginUpdate();
            cbProjeto.DataSource = projetos;
            cbProjeto.ValueMember = "Codigo";
            cbProjeto.DisplayMember = "Nome";
            cbProjeto.SelectedIndex = -1;
            cbProjeto.EndUpdate();
        }

        private void CarregarComboPlanilha()
        {
            if (cbProjeto.SelectedIndex == -1)
                return;

            var projetos = FabricaDeRepositorios<IPlanilhaRepositorio>.Instancia.BuscarPorIdProjeto(((Projeto)cbProjeto.SelectedItem).Id);

            cbPlanilha.BeginUpdate();
            cbPlanilha.DataSource = projetos;
            cbPlanilha.ValueMember = "Codigo";
            cbPlanilha.DisplayMember = "Nome";
            cbPlanilha.SelectedIndex = -1;
            cbPlanilha.EndUpdate();
        }

        private void CriarDataTableEGrid()
        {
            dataTableItens.Columns.Add("Tipo", typeof(string));
            dataTableItens.Columns.Add("CodigoCPU", typeof(string));
            dataTableItens.Columns.Add("DescricaoCPU", typeof(string));
            dataTableItens.Columns.Add("CodigoItem", typeof(string));

            dgvAssociarComposicao.DataSource = dataTableItens;
        }

        private void MontarTreeView()
        {
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Columns), "Colunas");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_StructuralColumns), "Coluna Estrutural");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Stairs), "Escadas");
            IncluirItemTreeView(Coletor.BuscarFamilia<Ceiling>(_document, new BuiltInCategory()), "Forro");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_StructuralFoundation), "Fundação Estrutural");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_RailingHandRail), "Guarda Corpo");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Windows), "Janela");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Furniture), "Mobiliário");
            IncluirItemTreeView(Coletor.BuscarFamilia<Wall>(_document, new BuiltInCategory()), "Parede");
            IncluirItemTreeView(Coletor.BuscarFamilia<Floor>(_document, new BuiltInCategory()), "Pisos");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Doors), "Porta");
            IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Ramps), "Rampas");
            IncluirItemTreeView(Coletor.BuscarFamilia<RoofBase>(_document, new BuiltInCategory()), "Telhado");
        }

        private void IncluirItemTreeView<T>(List<T> listaFamilias, string nomeFamilia)
        {
            TreeNode treeNode = new TreeNode(nomeFamilia); ;
            foreach (var item in listaFamilias)
            {
                string nomeTipo = string.Empty;

                if (!noExiste<T>(treeNode, item, out nomeTipo))
                {
                    var noTreeView = new System.Windows.Forms.TreeNode(nomeTipo);
                    noTreeView.Name = nomeTipo;
                    treeNode.Nodes.Add(noTreeView);
                }
            }
            tvFamilias.Nodes.Add(treeNode);
        }

        private static bool noExiste<T>(TreeNode treeNode, T item, out string nomeTipo)
        {
            var props = item.GetType().GetProperties();
            var prop = props.Where(i => i.Name == "Name").FirstOrDefault();

            nomeTipo = prop.GetValue(item, null).ToString();
            var noExiste = treeNode.Nodes.Find(nomeTipo, true);

            if (noExiste == null || noExiste.Count() == 0)
                return false;
            else
                return true;
        }

        private void CheckNode(TreeNode node)
        {            
            foreach (TreeNode nodo in node.Nodes)
            {
                nodo.Checked = node.Checked;

                CheckNode(nodo);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                long idPlanilha = 0;
                long idProjeto = 0;

                if (((Projeto)cbProjeto.SelectedItem) == null)
                {
                    MessageBox.Show("Selecione um projeto para continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbProjeto.Focus();
                }
                else
                    idProjeto = ((Projeto)cbProjeto.SelectedItem).Id;


                if (cbPlanilha.SelectedItem != null)
                    idPlanilha = ((Planilha)cbPlanilha.SelectedItem).Id;

                FHelpComposicao fHelpComposicao = new FHelpComposicao(idProjeto, idPlanilha);
                fHelpComposicao.StartPosition = FormStartPosition.CenterScreen;
                fHelpComposicao.ShowDialog();
            }
        }

        private void tvFamilias_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckNode(e.Node);


            foreach (TreeNode nodo in e.Node.Nodes)
            {
                if (nodo.Checked)
                    IncluirItemGrade(nodo.Text);
            }
        }

        private void IncluirItemGrade(string text)
        {
            DataRow dataRow = dataTableItens.Rows.Add(new object[]
            {
                text, "", "", ""
            });
        }

        private void cbBaseDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboProjeto();
        }

        private void cbProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboPlanilha();
        }
    }
}
