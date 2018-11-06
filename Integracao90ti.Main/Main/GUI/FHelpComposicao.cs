using Integracao90ti.Dominio;
using Integracao90ti.Dominio.Fabrica;
using Integracao90ti.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integracao90ti.Main.GUI
{
    public partial class FHelpComposicao : Form
    {
        private DataTable dataTableComposicao = new DataTable();
        private DataTable dataTableItensPlanilha = new DataTable();
        private long idComposicaoRetorno = 0;
        private long idItemPlanilhaRetorno = 0;
        private long idPlanilha = 0;

        public FHelpComposicao(long idProjeto, long idPlanilha)
        {
            InitializeComponent();

            this.idPlanilha = idPlanilha;

            CriarDataTableEGridComposicao();
            CriarDataTableEGridItensPlanilha();
            IncluirItemGradeComposicao(idProjeto, idPlanilha);
        }


        private void IncluirItemGradeComposicao(long idProjeto, long idPlanilha)
        {
            List<Composicao> composicoes = new List<Composicao>();

            if (idPlanilha == 0)
                composicoes = FabricaDeRepositorios<IComposicaoRepositorio>.Instancia.BuscarPorIdProjeto(idProjeto).ToList();
            else
                composicoes = FabricaDeRepositorios<IComposicaoRepositorio>.Instancia.BuscarPorIdPlanilha(idPlanilha).ToList(); 

            foreach (var composicao in composicoes)
            {
                DataRow dataRow = dataTableComposicao.Rows.Add(new object[]
                {
                    composicao.Codigo, composicao.Nome, composicao.Unidade, composicao.PrecoServico, composicao.Id
                });
            }
        }

        private void IncluirItemGradeItemPlanilha(long idComposicao)
        {
            dataTableItensPlanilha.Clear();
            List<ItemPlanilha> itensPlanilha = new List<ItemPlanilha>();

            if (this.idPlanilha == 0)
                itensPlanilha = FabricaDeRepositorios<IItemPlanilhaRepositorio>.Instancia.BuscarPorIdComposicao(idComposicao).ToList();
            else
                itensPlanilha = FabricaDeRepositorios<IItemPlanilhaRepositorio>.Instancia.BuscarPorIdPlanilhaEComposicao(idComposicao, idPlanilha).ToList();

            foreach (var item in itensPlanilha)
            {
                DataRow dataRow = dataTableItensPlanilha.Rows.Add(new object[]
                {
                    item.Planilha.Nome, item.Codigo, item.Nome, item.Id
                });
            }
        }

        private void CriarDataTableEGridComposicao()
        {
            dataTableComposicao.Columns.Add("Codigo", typeof(string));
            dataTableComposicao.Columns.Add("Descricao", typeof(string));
            dataTableComposicao.Columns.Add("Unidade", typeof(string));
            dataTableComposicao.Columns.Add("Preco", typeof(string));
            dataTableComposicao.Columns.Add("Id", typeof(long));

            dgvComposicao.DataSource = dataTableComposicao;
        }

        private void CriarDataTableEGridItensPlanilha()
        {
            dataTableItensPlanilha.Columns.Add("Planilha", typeof(string));
            dataTableItensPlanilha.Columns.Add("Codigo", typeof(string));
            dataTableItensPlanilha.Columns.Add("Descricao", typeof(string));
            dataTableItensPlanilha.Columns.Add("IdItemPlanilha", typeof(long));

            dgvItemPlanilha.DataSource = dataTableItensPlanilha;
        }

        private void dgvComposicao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            long idComposicao = (long)dataTableComposicao.Rows[e.RowIndex]["Id"];
;
            IncluirItemGradeItemPlanilha(idComposicao);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (dgvComposicao.CurrentRow != null)
            {
                DataRowCollection rows = dataTableComposicao.Rows;

                var dtRow = rows[dgvComposicao.CurrentRow.Index];
                idComposicaoRetorno = (long)dtRow["Id"];

                if (dgvItemPlanilha.Rows.Count > 0)
                {                    
                    foreach (DataGridViewRow row in dgvItemPlanilha.Rows)
                    {
                        if (dgvItemPlanilha.Rows[row.Index].Cells[0].Value != null)
                        {
                            idItemPlanilhaRetorno = (long)dgvItemPlanilha.Rows[row.Index].Cells["IdItemPlanilha"].Value;
                            break;
                        }
                    }
                }
            }
        }

        internal long GetIdItemPlanilha()
        {
            return idItemPlanilhaRetorno;
        }

        internal long GetIdComposicao()
        {
            return idComposicaoRetorno;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(dgvComposicao.CurrentRow.Index + 1, false);
        }

        private void Buscar(int linha, bool reiniciou)
        {
            for (int i = linha; i <= dgvComposicao.RowCount - 1; i++)
            {
                for (int j = 0; j <= dgvComposicao.ColumnCount - 1; j++)
                {
                    if (dgvComposicao.Rows[i].Cells[j].Value != null && dgvComposicao.Rows[i].Cells[j].Value != DBNull.Value)
                    {
                        if (dgvComposicao.Rows[i].Cells[j].Value.ToString().ToUpper().Contains(txtBuscar.Text.ToUpper()))
                        {
                            dgvComposicao.CurrentCell = dgvComposicao.Rows[i].Cells[j];
                            return;
                        }
                    }
                }
            }

            if (!reiniciou)
                Buscar(0, true);
        }
    }
}
