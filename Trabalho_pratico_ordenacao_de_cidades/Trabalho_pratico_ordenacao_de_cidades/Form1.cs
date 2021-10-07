using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_pratico_ordenacao_de_cidades
{
    public partial class Form1 : Form
    {
        //vetor declarado como variável global da classe
        string[] cidades = new string[File.ReadLines("DUPLA (2).txt").Count()];

        public Form1()
        {
            InitializeComponent();
        }
        
        private void listCidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            StreamReader arquivo = new StreamReader("DUPLA (2).txt");// Passe o caminho e o nome do arquivo
            string linha;
            int c = 0;
            int n = File.ReadLines("DUPLA (2).txt").Count();// Quantidade de elementos do arquivo
            do
            {
                linha = arquivo.ReadLine();// Leia a primeira linha do texto
                listCidades.Items.Add(linha); // listCidades é um ListBox
                cidades[c] = linha; // cidades é um vetor, declarado como variável global da classe
                c++;
            } while (c < n); // n é a quantidade de elementos do arquivo
            arquivo.Close();
            MessageBox.Show("Dados Carregados");

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            StreamWriter arquivo = new StreamWriter("ordenado.txt");
            foreach (string c in cidades)
                arquivo.WriteLine(c);// Grava no arquivo
            MessageBox.Show("Dados Salvos!");
            arquivo.Close();
        }

        void mostra()
        {
            listCidades.Items.Clear();
            foreach (String n in cidades)
                listCidades.Items.Add(n);
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            Array.Sort(cidades); //Classifica os elementos em um intervalo de elementos em um Array unidimensional
            mostra();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int p = Array.IndexOf(cidades,txtEntrada.Text); // Pesquisar a primeira ocorrência do valor no vetor
            if (p == -1)
                MessageBox.Show("Cidade não encontrada :(");
            else
                MessageBox.Show("Cidade encontrada na posição: " + p);
        }

        private void btnBuscaBinaria_Click(object sender, EventArgs e)
        {
            int p = Array.BinarySearch(cidades,txtEntrada.Text);// Pesquisar a ocorrência do valor no vetor ordenado
            if (p < 0)
                MessageBox.Show("Cidade não encontrada :(");
            else
                MessageBox.Show("Cidade encontrada na posição: " + p);
        }
    }
}
