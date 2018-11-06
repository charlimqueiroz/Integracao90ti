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
            dataTableItens.Columns.Add("Quantidade", typeof(double));
            dataTableItens.Columns.Add("IdItemPlanilha", typeof(long));
            dataTableItens.Columns.Add("IdComposicao", typeof(long));

            dgvAssociarComposicao.DataSource = dataTableItens;
        }

        private void MontarTreeView()
        {
            Familias familia = new Familias();
            IList<Familias> familias = familia.BuscarFamilias(_document);

            IncluirItemTreeViewFamilia(familias);

            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Columns), "Colunas");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_StructuralColumns), "Coluna Estrutural");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Stairs), "Escadas");
            //IncluirItemTreeView(Coletor.BuscarFamilia<Ceiling>(_document, new BuiltInCategory()), "Forro");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_StructuralFoundation), "Fundação Estrutural");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_RailingHandRail), "Guarda Corpo");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Windows), "Janela");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Furniture), "Mobiliário");
            //IncluirItemTreeView(Coletor.BuscarFamilia<Wall>(_document, new BuiltInCategory()), "Parede");
            //IncluirItemTreeView(Coletor.BuscarFamilia<Floor>(_document, new BuiltInCategory()), "Pisos");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Doors), "Porta");
            //IncluirItemTreeView(Coletor.BuscarFamilia<FamilyInstance>(_document, BuiltInCategory.OST_Ramps), "Rampas");
            //IncluirItemTreeView(Coletor.BuscarFamilia<RoofBase>(_document, new BuiltInCategory()), "Telhado");
        }

        private void IncluirItemTreeView<T>(List<T> listaFamilias, string nomeFamilia)
        {
            TreeNode treeNode = new TreeNode(nomeFamilia);
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

        private void IncluirItemTreeViewFamilia(IList<Familias> listaFamilias)
        {
            var familiasPai = listaFamilias.Select(i => i.Nome).Distinct().ToList();

            foreach (var item in familiasPai)
            {
                TreeNode treeNode = new TreeNode(item);
                treeNode.Name = item;
                tvFamilias.Nodes.Add(treeNode);
            }

            foreach (TreeNode node in tvFamilias.Nodes)
            {
                var nomeNo = node.Name;
                foreach (var item in listaFamilias)
                {
                    if (nomeNo == item.Nome && !string.IsNullOrEmpty(item.NomeTipo))
                    {
                        TreeNode treeNode = new TreeNode(item.NomeTipo);
                        treeNode.Name = item.NomeTipo;
                        treeNode.Tag = listaFamilias.Where(i => i.NomeTipo == item.NomeTipo).Sum(i => i.Quantidade);
                        node.Nodes.Add(treeNode);
                    }
                }
            }
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

        private static string BuscarNomeTipo(Familias item)
        {
            var props = item.GetType().GetProperties();
            var prop = props.Where(i => i.Name == "Name").FirstOrDefault();

            return prop.GetValue(item, null).ToString();
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


                if (fHelpComposicao.GetIdItemPlanilha() != 0)
                {
                    ItemPlanilha itemPlanilha = FabricaDeRepositorios<IItemPlanilhaRepositorio>.Instancia.BuscarPorId(fHelpComposicao.GetIdItemPlanilha());

                    IncluirItemGrade(true, e.RowIndex, string.Empty, itemPlanilha.Composicao.Codigo, itemPlanilha.Composicao.Descricao, itemPlanilha.Codigo, itemPlanilha.Id, itemPlanilha.Composicao.Id, 0);
                }
                else
                    if (fHelpComposicao.GetIdComposicao() != 0)
                {
                    Composicao composicao = FabricaDeRepositorios<IComposicaoRepositorio>.Instancia.BuscarPorId(fHelpComposicao.GetIdComposicao());
                }
            }
        }

        private void IncluirItemGrade(bool atualizar, int index, string tipo, string codigoComposicao, string descricaoComposicao, string codigoItemPlanilha, long idItemPlanilha, long idComposicao, double quantidade)
        {
            if (atualizar)
            {
                dgvAssociarComposicao.BeginEdit(false);
                var dataRow = dataTableItens.Rows[index];

                //dataTableItens.Columns.Add("Tipo", typeof(string));
                //dataTableItens.Columns.Add("CodigoCPU", typeof(string));
                //dataTableItens.Columns.Add("DescricaoCPU", typeof(string));
                //dataTableItens.Columns.Add("CodigoItem", typeof(string));
                //dataTableItens.Columns.Add("IdItemPlanilha", typeof(long));
                //dataTableItens.Columns.Add("IdComposicao", typeof(long));

                dataRow["CodigoCPU"] = codigoComposicao;
                dataRow["DescricaoCPU"] = descricaoComposicao;
                dataRow["CodigoItem"] = codigoItemPlanilha;
                dataRow["IdItemPlanilha"] = idItemPlanilha;
                dataRow["IdComposicao"] = idComposicao;

                dgvAssociarComposicao.Update();
            }
            else
            {
                DataRow dataRow = dataTableItens.Rows.Add(new object[]
                {
                    tipo, codigoComposicao, descricaoComposicao, codigoItemPlanilha, quantidade.ToString("N2")
                });
            }
        }

        private void cbBaseDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboProjeto();
        }

        private void cbProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboPlanilha();
        }


        private void MarcarNosAnteriores(TreeNode noPai, bool valor)
        {
            if (noPai.Parent != null)
            {
                if (!valor)
                {
                    if (!this.VerificaNosSelecionados(noPai.Parent.Nodes))
                    {
                        noPai.Checked = valor;
                        this.MarcarNosAnteriores(noPai.Parent, valor);
                    }
                }
                else
                {
                    noPai.Checked = valor;
                    this.MarcarNosAnteriores(noPai.Parent, valor);
                }
            }
            else
            {
                noPai.Checked = valor;
            }
        }

        private void MarcarNosPosteriores(TreeNodeCollection listaNos, bool valor)
        {
            foreach (TreeNode n in listaNos)
            {
                n.Checked = valor;

                if (n.Nodes.Count > 0)
                    this.MarcarNosPosteriores(n.Nodes, valor);
            }
        }

        private bool VerificaNosSelecionados(TreeNodeCollection listaNos)
        {
            foreach (TreeNode n in listaNos)
            {
                if (n.Checked)
                    return true;
                else if (n.Nodes.Count > 0)
                    this.VerificaNosSelecionados(n.Nodes);
            }
            return false;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.MarcarNosAnteriores(e.Node, e.Node.Checked);

            this.MarcarNosPosteriores(e.Node.Nodes, e.Node.Checked);
        }

        private void tvFamilias_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.MarcarNosAnteriores(e.Node, e.Node.Checked);

            this.MarcarNosPosteriores(e.Node.Nodes, e.Node.Checked);

            if (e.Node.Checked)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode nodo in e.Node.Nodes)
                    {
                        if (nodo.Checked)
                            IncluirItemGrade(false, 0, nodo.Text, string.Empty, string.Empty, string.Empty, 0, 0, Convert.ToDouble(nodo.Tag));
                    }
                }
                else
                {
                    if (e.Node.Parent != null)
                        IncluirItemGrade(false, 0, e.Node.Text, string.Empty, string.Empty, string.Empty, 0, 0, Convert.ToDouble(e.Node.Tag));
                }
            }
            else
            {
                if (e.Node.Nodes.Count > 0)
                {
                    ExcluirItemGrade(e);
                }
                else
                {
                    if (e.Node.Parent != null)
                        ExcluirItemGradeDetalhe(e.Node);
                }


            }
        }

        private void ExcluirItemGrade(TreeNodeMouseClickEventArgs e)
        {
            foreach (TreeNode nodo in e.Node.Nodes)
            {
                if (!nodo.Checked)
                {
                    ExcluirItemGradeDetalhe(nodo);
                    dgvAssociarComposicao.Refresh();
                }
            }
        }

        private void ExcluirItemGradeDetalhe(TreeNode nodo)
        {
            for (int i = dgvAssociarComposicao.RowCount - 1; i >= 0; i--)
            {
                if (dgvAssociarComposicao.Rows[i].Cells[1].Value != null)
                {
                    if (dgvAssociarComposicao.Rows[i].Cells[1].Value.ToString() == nodo.Name)
                    {
                        dgvAssociarComposicao.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = dgvAssociarComposicao.RowCount - 1; i >= 0; i--)
            {
                decimal quantidade = Convert.ToDecimal(dgvAssociarComposicao.Rows[i].Cells[5].Value);

                if (dgvAssociarComposicao.Rows[i].Cells[6].Value != null && quantidade != 0)
                {
                    ItemPlanilha itemPlanilha = FabricaDeRepositorios<IItemPlanilhaRepositorio>.Instancia.BuscarPorId(Convert.ToInt64(dgvAssociarComposicao.Rows[i].Cells[6].Value));

                    itemPlanilha.Quantidade = quantidade;

                    FabricaDeRepositorios<IItemPlanilhaRepositorio>.Instancia.SaveOrUpdate(itemPlanilha);

                }
            }
        }
    }
}
