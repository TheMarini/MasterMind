using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;

namespace prjMasterMind
{
    public partial class frmMasterMind : Form
    {
        public frmMasterMind()
        {
            InitializeComponent();
            this.Height = 677;

            GerarCodigo();
        }

        int acertos = 0, posicao = 0, erros = 0;
        int linha = 1; //em qual linha de botões jogador está clicando
        int clicks = 0; //quantos cliques dado naquele botão
        int[] codigo = new int[5]; //código gerado (1ª casa descartada como forma de organização)
        int[] tentativa = new int[5]; //código do jogador (casa 0 = usuario não clicou ainda)
        string[] cores = new string[8] { "Control", "Brown", "SeaGreen", "SteelBlue", "Turquoise", "Orange", "Orchid", "Pink" }; //todas as cores
        
        #region Métodos
        //Muda de cor, habilita botão "tentar código", atribui a tentativa
        #region Apertar
        private void Apertar(Button botao)
        {
            #region Contador de clicks
            if (botao.BackColor == Color.FromName(cores[0])) //casa 0 = cor padrão (cinza)
            {
                clicks = 0; //reiniciar o contador pra botões ainda não clicados (cinzas)
            }

            clicks++;
            if (clicks > 7)
            {
                clicks = 1; //reiniciar o contador pra botões já clicados (coloridos)
            }
            #endregion

            btnTentar.Focus();
            botao.BackColor = Color.FromName(cores[clicks]);

            #region Habilitar "Tentar Código"
            switch (linha)
            {
                case 1: if (btn11.BackColor != System.Drawing.Color.FromName("Control") && btn12.BackColor != System.Drawing.Color.FromName("Control") && btn13.BackColor != System.Drawing.Color.FromName("Control") && btn14.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 2: if (btn21.BackColor != System.Drawing.Color.FromName("Control") && btn22.BackColor != System.Drawing.Color.FromName("Control") && btn23.BackColor != System.Drawing.Color.FromName("Control") && btn24.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 3: if (btn31.BackColor != System.Drawing.Color.FromName("Control") && btn32.BackColor != System.Drawing.Color.FromName("Control") && btn33.BackColor != System.Drawing.Color.FromName("Control") && btn34.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 4: if (btn41.BackColor != System.Drawing.Color.FromName("Control") && btn42.BackColor != System.Drawing.Color.FromName("Control") && btn43.BackColor != System.Drawing.Color.FromName("Control") && btn44.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 5: if (btn51.BackColor != System.Drawing.Color.FromName("Control") && btn52.BackColor != System.Drawing.Color.FromName("Control") && btn53.BackColor != System.Drawing.Color.FromName("Control") && btn54.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 6: if (btn51.BackColor != System.Drawing.Color.FromName("Control") && btn62.BackColor != System.Drawing.Color.FromName("Control") && btn63.BackColor != System.Drawing.Color.FromName("Control") && btn64.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 7: if (btn71.BackColor != System.Drawing.Color.FromName("Control") && btn72.BackColor != System.Drawing.Color.FromName("Control") && btn73.BackColor != System.Drawing.Color.FromName("Control") && btn74.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 8: if (btn81.BackColor != System.Drawing.Color.FromName("Control") && btn82.BackColor != System.Drawing.Color.FromName("Control") && btn83.BackColor != System.Drawing.Color.FromName("Control") && btn84.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 9: if (btn91.BackColor != System.Drawing.Color.FromName("Control") && btn92.BackColor != System.Drawing.Color.FromName("Control") && btn93.BackColor != System.Drawing.Color.FromName("Control") && btn94.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;

                case 10: if (btn101.BackColor != System.Drawing.Color.FromName("Control") && btn102.BackColor != System.Drawing.Color.FromName("Control") && btn103.BackColor != System.Drawing.Color.FromName("Control") && btn104.BackColor != System.Drawing.Color.FromName("Control"))
                    {
                        HabilitarBotao();
                    }
                    break;
            }
            #endregion

            #region Atribui números de clicks à tentiva do jogador
            if (botao.Name.LastIndexOf('1') == 4) //"btn" + linha + coluna
            {
                tentativa[1] = clicks;
            }
            if (botao.Name.LastIndexOf('2') == 4) //"btn" + linha + coluna
            {
                tentativa[2] = clicks;
            }
            if (botao.Name.LastIndexOf('3') == 4) //"btn" + linha + coluna
            {
                tentativa[3] = clicks;
            }
            if (botao.Name.LastIndexOf('4') == 4) //"btn" + linha + coluna
            {
                tentativa[4] = clicks;
            }
            #endregion
        }

        private void HabilitarBotao()
        {
            btnTentar.BackColor = System.Drawing.Color.SeaGreen;
            btnTentar.Enabled = true;
        }
        #endregion

        //Verifica os erros e acertos
        #region Verificar
        private void Verificar()
        {
            #region contagem de erros e acertos
            if (tentativa[1] == codigo[1] && tentativa[2] == codigo[2] && tentativa[3] == codigo[3] && tentativa[4] == codigo[4])
            {
                lblLegenda.Text = "PARABÉNS, VOCÊ ACERTOU A SENHA!";
                pnlLegenda.BackColor = Color.SeaGreen;
                lblLegenda.ForeColor = Color.WhiteSmoke;

                mostrarResposta();

                btnTentar.Visible = false;
                btnLimpar.Visible = false;
                btnDesistir.Visible = false;
                btnReiniciar.Visible = true;
                acertos = 4;
            }
            else
            {
                for (int i = 1; i < 5; i++)
                {
                    if (tentativa[i] == codigo[i])
                    {
                        acertos++;
                    }
                    else
                    {
                        for (int k = 1; k < 5; k++)
                        {
                            if (tentativa[i] == codigo[k])
                            {
                                posicao++;
                                erros--;
                            }
                        }
                        erros++;
                    }
                }
            }
            #endregion

            #region mostrar relatório
            for (int i = 1; i < 5; i++)
            {
                foreach (Object objeto in pnlTodosRelatorios.Controls)
                {
                    if (objeto is PictureBox)
                    {
                        PictureBox picturebox = (PictureBox)objeto;
                        if (picturebox.Name == ("pcbRelatorio" + linha + i).ToString())
                        {
                            picturebox.Visible = true;
                            if (acertos > 0)
                            {
                                picturebox.Image = Properties.Resources.verde;
                                acertos--;
                            }
                            else
                            {
                                if (posicao > 0)
                                {
                                    picturebox.Image = Properties.Resources.posicao;
                                    posicao--;
                                }
                                else
                                {
                                    picturebox.Image = Properties.Resources.vermelho;
                                    erros--;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            //lblAjuda.Text = "A> " + acertos.ToString() + " P> " + posicao.ToString() + " E> " + erros.ToString();
        }
        #endregion

        //Zera a cor da linha atual
        #region Cor Padrão
        private void CorPadrao(int linha)
        {
            switch (linha)
            {
                case 1: btn11.BackColor = Color.FromName("Control"); btn12.BackColor = Color.FromName("Control"); btn13.BackColor = Color.FromName("Control"); btn14.BackColor = Color.FromName("Control");
                    break;

                case 2: btn21.BackColor = Color.FromName("Control"); btn22.BackColor = Color.FromName("Control"); btn23.BackColor = Color.FromName("Control"); btn24.BackColor = Color.FromName("Control");
                    break;

                case 3: btn31.BackColor = Color.FromName("Control"); btn32.BackColor = Color.FromName("Control"); btn33.BackColor = Color.FromName("Control"); btn34.BackColor = Color.FromName("Control");
                    break;

                case 4: btn41.BackColor = Color.FromName("Control"); btn42.BackColor = Color.FromName("Control"); btn43.BackColor = Color.FromName("Control"); btn44.BackColor = Color.FromName("Control");
                    break;

                case 5: btn51.BackColor = Color.FromName("Control"); btn52.BackColor = Color.FromName("Control"); btn53.BackColor = Color.FromName("Control"); btn54.BackColor = Color.FromName("Control");
                    break;

                case 6: btn61.BackColor = Color.FromName("Control"); btn52.BackColor = Color.FromName("Control"); btn53.BackColor = Color.FromName("Control"); btn54.BackColor = Color.FromName("Control");
                    break;

                case 7: btn71.BackColor = Color.FromName("Control"); btn52.BackColor = Color.FromName("Control"); btn53.BackColor = Color.FromName("Control"); btn54.BackColor = Color.FromName("Control");
                    break;

                case 8: btn81.BackColor = Color.FromName("Control"); btn52.BackColor = Color.FromName("Control"); btn53.BackColor = Color.FromName("Control"); btn54.BackColor = Color.FromName("Control");
                    break;

                case 9: btn91.BackColor = Color.FromName("Control"); btn52.BackColor = Color.FromName("Control"); btn53.BackColor = Color.FromName("Control"); btn54.BackColor = Color.FromName("Control");
                    break;

                case 10: btn101.BackColor = Color.FromName("Control"); btn52.BackColor = Color.FromName("Control"); btn53.BackColor = Color.FromName("Control"); btn54.BackColor = Color.FromName("Control");
                    break;
            }
        }
        #endregion

        //Gera um novo código
        #region Gerar Código
        private void GerarCodigo()
        {
            Random aleatorio = new Random();
            do
            {
                for (int i = 1; i < 5; i++)
                {
                    codigo[i] = aleatorio.Next(1, 8);
                }
            }
            while (codigo[1] == codigo[2] || codigo[1] == codigo[3] || codigo[1] == codigo[4] || codigo[2] == codigo[3] || codigo[2] == codigo[4] || codigo[3] == codigo[4]);

            linha = 1;
            clicks = 0;
            MudarDeLinha();
            this.Height = 677;

            btnCodigoCor1.BackColor = Color.FromName("ControlDark");
            btnCodigoCor2.BackColor = Color.FromName("ControlDark");
            btnCodigoCor3.BackColor = Color.FromName("ControlDark");
            btnCodigoCor4.BackColor = Color.FromName("ControlDark");

            foreach (PictureBox picturebox in pnlTodosRelatorios.Controls)
            {
                picturebox.Visible = false;
            }
            //this.Text = codigo[1].ToString() + codigo[2].ToString() + codigo[3].ToString() + codigo[4].ToString();
        }
        #endregion

        //Mostra os botões da linha atual
        #region Mudar de Linha
        private void MudarDeLinha()
        {
            switch (linha)
            {
                case 1: btn11.Visible = true; btn12.Visible = true; btn13.Visible = true; btn14.Visible = true;

                    //Zera a cor de todos os botões
                    for (int i = 1; i < 11; i++)
                    {
                        CorPadrao(i);
                    }
                    linha = 1;
                    #region some os outros botoões
                    btn21.Visible = false; btn22.Visible = false; btn23.Visible = false; btn24.Visible = false;
                    btn31.Visible = false; btn32.Visible = false; btn33.Visible = false; btn34.Visible = false;
                    btn41.Visible = false; btn42.Visible = false; btn43.Visible = false; btn44.Visible = false;
                    btn51.Visible = false; btn52.Visible = false; btn53.Visible = false; btn54.Visible = false;
                    btn61.Visible = false; btn62.Visible = false; btn63.Visible = false; btn64.Visible = false;
                    btn71.Visible = false; btn72.Visible = false; btn73.Visible = false; btn74.Visible = false;
                    btn81.Visible = false; btn82.Visible = false; btn83.Visible = false; btn84.Visible = false;
                    btn91.Visible = false; btn92.Visible = false; btn93.Visible = false; btn94.Visible = false;
                    btn101.Visible = false; btn102.Visible = false; btn103.Visible = false; btn104.Visible = false;
                    #endregion
                    break;

                case 2: btn21.Visible = true; btn22.Visible = true; btn23.Visible = true; btn24.Visible = true;
                    break;

                case 3: btn31.Visible = true; btn32.Visible = true; btn33.Visible = true; btn34.Visible = true;
                    break;

                case 4: btn41.Visible = true; btn42.Visible = true; btn43.Visible = true; btn44.Visible = true;
                    break;

                case 5: btn51.Visible = true; btn52.Visible = true; btn53.Visible = true; btn54.Visible = true;
                    break;

                case 6: btn61.Visible = true; btn62.Visible = true; btn63.Visible = true; btn64.Visible = true;
                    break;

                case 7: btn71.Visible = true; btn72.Visible = true; btn73.Visible = true; btn74.Visible = true;
                    break;

                case 8: btn81.Visible = true; btn82.Visible = true; btn83.Visible = true; btn84.Visible = true;
                    break;

                case 9: btn91.Visible = true; btn92.Visible = true; btn93.Visible = true; btn94.Visible = true;
                    break;

                case 10: btn101.Visible = true; btn102.Visible = true; btn103.Visible = true; btn104.Visible = true;
                    break;
            }
        }
        #endregion

        //Mostra a resposta
        #region Mostrar Resposta
        private void mostrarResposta()
        {
            btnCodigoCor1.BackColor = Color.FromName(cores[codigo[1]]);
            btnCodigoCor2.BackColor = Color.FromName(cores[codigo[2]]);
            btnCodigoCor3.BackColor = Color.FromName(cores[codigo[3]]);
            btnCodigoCor4.BackColor = Color.FromName(cores[codigo[4]]);
        }
        #endregion
        #endregion

        #region Botões Coloridos
        #region Linha 1
        private void btn11_Click(object sender, EventArgs e)
        {
            Apertar(btn11);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            Apertar(btn12);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            Apertar(btn13);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            Apertar(btn14);
        }
        #endregion
        #region Linha 2
        private void btn21_Click(object sender, EventArgs e)
        {
            Apertar(btn21);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            Apertar(btn22);
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            Apertar(btn23);
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            Apertar(btn24);
        }
        #endregion
        #region Linha 3
        private void btn31_Click(object sender, EventArgs e)
        {
            Apertar(btn31);
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            Apertar(btn32);
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            Apertar(btn33);
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            Apertar(btn34);
        }
        #endregion
        #region Linha 4

        private void btn41_Click(object sender, EventArgs e)
        {
            Apertar(btn41);
        }

        private void btn42_Click(object sender, EventArgs e)
        {
            Apertar(btn42);
        }

        private void btn43_Click(object sender, EventArgs e)
        {
            Apertar(btn43);
        }

        private void btn44_Click(object sender, EventArgs e)
        {
            Apertar(btn44);
        }
        #endregion
        #region Linha 5
        private void btn51_Click(object sender, EventArgs e)
        {
            Apertar(btn51);
        }

        private void btn52_Click(object sender, EventArgs e)
        {
            Apertar(btn52);
        }

        private void btn53_Click(object sender, EventArgs e)
        {
            Apertar(btn53);
        }

        private void btn54_Click(object sender, EventArgs e)
        {
            Apertar(btn54);
        }
        #endregion
        #region Linha 6
        private void btn61_Click(object sender, EventArgs e)
        {
            Apertar(btn61);
        }

        private void btn62_Click(object sender, EventArgs e)
        {
            Apertar(btn62);
        }

        private void btn63_Click(object sender, EventArgs e)
        {
            Apertar(btn63);
        }

        private void btn64_Click(object sender, EventArgs e)
        {
            Apertar(btn64);
        }
        #endregion
        #region Linha 7
        private void btn71_Click(object sender, EventArgs e)
        {
            Apertar(btn71);
        }

        private void btn72_Click(object sender, EventArgs e)
        {
            Apertar(btn72);
        }

        private void btn73_Click(object sender, EventArgs e)
        {
            Apertar(btn73);
        }

        private void btn74_Click(object sender, EventArgs e)
        {
            Apertar(btn74);
        }
        #endregion
        #region Linha 8
        private void btn81_Click(object sender, EventArgs e)
        {
            Apertar(btn81);
        }

        private void btn82_Click(object sender, EventArgs e)
        {
            Apertar(btn82);
        }

        private void btn83_Click(object sender, EventArgs e)
        {
            Apertar(btn83);
        }

        private void btn84_Click(object sender, EventArgs e)
        {
            Apertar(btn84);
        }
        #endregion
        #region Linha 9
        private void btn91_Click(object sender, EventArgs e)
        {
            Apertar(btn91);
        }

        private void btn92_Click(object sender, EventArgs e)
        {
            Apertar(btn92);
        }

        private void btn93_Click(object sender, EventArgs e)
        {
            Apertar(btn93);
        }

        private void btn94_Click(object sender, EventArgs e)
        {
            Apertar(btn94);
        }

        #endregion
        #region Linha 10
        private void btn101_Click(object sender, EventArgs e)
        {
            Apertar(btn101);
        }

        private void btn102_Click(object sender, EventArgs e)
        {
            Apertar(btn102);
        }

        private void btn103_Click(object sender, EventArgs e)
        {
            Apertar(btn103);
        }

        private void btn104_Click(object sender, EventArgs e)
        {
            Apertar(btn104);
        }
        #endregion
        #endregion

        #region Botão Tentar
        private void btnTentar_Click(object sender, EventArgs e)
        {
            //numero de tentativas (linhas)
            if (linha < 11)
            {
                //cores não repetidas
                if (tentativa[1] != tentativa[2] && tentativa[1] != tentativa[3] && tentativa[1] != tentativa[4] && tentativa[2] != tentativa[3] && tentativa[2] != tentativa[4] && tentativa[3] != tentativa[4])
                {
                    Verificar(); //verifica os erros e acertos
                    lblErro.Visible = false;
                }
                else
                {
                    lblErro.Visible = true;
                    return;
                }
            }
            else
            {
                //acabou o numero de tentativas
                btnTentar.Visible = false;
                btnLimpar.Visible = false;

                btnDesistir.Focus();
                lblLegenda.ForeColor = Color.Red;
                lblLegenda.Text = "Acabou suas tentativas, deseja desistir?";
            }

            acertos = 0; posicao = 0; erros = 0;
            clicks = 0; //zera o números de clicks
            linha++;

            MudarDeLinha(); //muda de linha

            this.Height = 743;
            btnTentar.Enabled = false;
            btnTentar.BackColor = Color.FromName("Control");
        }
        #endregion

        #region Easter Egg
        int clicar = 1;
        private void pnlHeader_Click(object sender, EventArgs e)
        {
            pnlHeader.BackColor = Color.FromName(cores[codigo[clicar]]);

            #region Contador
            if (clicar < 4)
            {
                clicar++;
            }
            else
            {
                clicar = 1;
            }
            #endregion
        }
        #endregion

        #region Reiniciar
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            lblLegenda.Text = "Acerte a sequência sem repetir nenhuma cor";
            pnlLegenda.BackColor = Color.FromName("ButtonFace");
            lblLegenda.ForeColor = Color.Gray;

            btnLimpar.Visible = true;
            btnDesistir.Visible = true;
            btnTentar.Visible = true;

            pnlHeader.BackColor = Color.FromName("ActiveCaption");

            GerarCodigo();
        }
        #endregion

        #region Desistir
        private void btnDesistir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente desistir?", "ARREGAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lblLegenda.Text = "                       VOCÊ DESISTIU!";
                pnlLegenda.BackColor = Color.WhiteSmoke;
                lblLegenda.ForeColor = Color.Silver;

                mostrarResposta();

                btnTentar.Visible = false;
                btnLimpar.Visible = false;
                btnDesistir.Visible = false;
                btnReiniciar.Visible = true;
            }
        }
        #endregion

        #region Limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clicks = 0;
            btnTentar.Enabled = false;
            btnTentar.BackColor = Color.FromName("Control");

            CorPadrao(linha);
        }
        #endregion

        #region Sair
        private void frmMasterMind_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
        #endregion
    }
}
