﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace PuntoDeVenta
{
    public partial class usuariosok : Form
    {
        public usuariosok()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Validacion para que un usuario no seleccione un icono ya en uso
        private void Cargar_estado_iconos()
        {
            try
            {
                foreach (DataGridViewRow row in datalistado.SelectedRows)
                {
                    string Icono = Convert.ToString(row.Cells["Nombre_de_Icono"].Value);

                    if (Icono == "1")
                    {
                        pictureBox3.Visible = false;
                    }
                    else if (Icono == "2")
                    {
                        pictureBox4.Visible = false;
                    }
                    else if (Icono == "3")
                    {
                        pictureBox5.Visible = false;
                    }
                    else if (Icono == "4")
                    {
                        pictureBox6.Visible = false;
                    }
                    else if (Icono == "5")
                    {
                        pictureBox7.Visible = false;
                    }
                    else if (Icono == "6")
                    {
                        pictureBox8.Visible = false;
                    }
                    else if (Icono == "7")
                    {
                        pictureBox9.Visible = false;
                    }
                    else if (Icono == "8")
                    {
                        pictureBox10.Visible = false;
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public bool validar_Mail(string sMail)
        {
            return Regex.IsMatch(sMail, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar_Mail(txtcorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no válida, el correo deberia tener el formato: example@dominio.com" + " favor volver a introducir su correo electronico.", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcorreo.Focus();
                txtcorreo.SelectAll();
            }
            else
            {

            if (txtnombre.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("insertar_usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                    cmd.Parameters.AddWithValue("@Login", txtlogin.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    cmd.Parameters.AddWithValue("@Correo", txtcorreo.Text);
                    cmd.Parameters.AddWithValue("@Rol", txtrol.Text);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ICONO.Image.Save(ms, ICONO.Image.RawFormat);


                    cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                    cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono.Text);
                    cmd.Parameters.AddWithValue("@ESTADO", "ACTIVO");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    mostrar();
                    panel4.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            }

        }
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

                datalistado.Columns[1].Visible = false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox3.Image;
            lblnumeroIcono.Text = "1";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;

        }

        private void LblAnuncioIcono_Click(object sender, EventArgs e)
        {
            Cargar_estado_iconos();
            panelICONO.Visible = true;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox4.Image;
            lblnumeroIcono.Text = "2";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox5.Image;
            lblnumeroIcono.Text = "3";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox6.Image;
            lblnumeroIcono.Text = "4";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox7.Image;
            lblnumeroIcono.Text = "5";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox8.Image;
            lblnumeroIcono.Text = "6";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox9.Image;
            lblnumeroIcono.Text = "7";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox10.Image;
            lblnumeroIcono.Text = "8";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void usuariosok_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panelICONO.Visible = false;
            mostrar();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            LblAnuncioIcono.Visible = true;

            //Campos vacios
            txtnombre.Text = "";
            txtlogin.Text = "";
            txtPassword.Text = "";
            txtrol.Text = "";
            txtcorreo.Text = "";
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblUsuario.Text = datalistado.SelectedCells[1].Value.ToString();
            txtnombre.Text = datalistado.SelectedCells[2].Value.ToString();
            txtlogin.Text = datalistado.SelectedCells[3].Value.ToString();
            txtPassword.Text = datalistado.SelectedCells[4].Value.ToString();

            ICONO.BackgroundImage = null;
            byte[] b = (Byte[])datalistado.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            ICONO.Image = Image.FromStream(ms);

            LblAnuncioIcono.Visible = false;
            lblnumeroIcono.Text = datalistado.SelectedCells[6].Value.ToString();
            txtcorreo.Text = datalistado.SelectedCells[7].Value.ToString();
            txtrol.Text = datalistado.SelectedCells[8].Value.ToString();
            panel4.Visible = true;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }

        private void ICONO_Click(object sender, EventArgs e)
        {
            Cargar_estado_iconos();
            panelICONO.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

            if (txtnombre.Text != "")
            {
                if (txtrol.Text !="")
                {
                    if(LblAnuncioIcono.Visible == false)
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd = new SqlCommand("editar_usuario", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idUsuario", lblUsuario.Text);
                            cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                            cmd.Parameters.AddWithValue("@Login", txtlogin.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                            cmd.Parameters.AddWithValue("@Correo", txtcorreo.Text);
                            cmd.Parameters.AddWithValue("@Rol", txtrol.Text);
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            ICONO.Image.Save(ms, ICONO.Image.RawFormat);


                            cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                            cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono.Text);

                            cmd.ExecuteNonQuery();
                            con.Close();
                            mostrar();
                            panel4.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                }
            }else
            {
                MessageBox.Show("CAMPOS VACIOS, FAVOR RELLENAR LOS CAMPOS CORRECTAMENTE" , "Validación de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e variable del dataGridView
            if (e.ColumnIndex == this.datalistado.Columns["ELI"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este usuario?", "Eliminando Registros",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["idUsuario"].Value);
                            string usuario = Convert.ToString(row.Cells["Login"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_usuario", con);
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@idUsuario", onekey);
                                    cmd.Parameters.AddWithValue("@login", usuario);
                                    cmd.ExecuteNonQuery();
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                }
                                catch (Exception err)
                                {
                                    MessageBox.Show(err.Message);
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }
                        mostrar();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes PEDRO DEVELOPER";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ICONO.BackgroundImage = null;
                ICONO.Image = new Bitmap(dlg.FileName);
                ICONO.SizeMode = PictureBoxSizeMode.Zoom;
                lblnumeroIcono.Text = Path.GetFileName(dlg.FileName);
                LblAnuncioIcono.Visible = false;
                panelICONO.Visible = false;
            }

        }
        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("buscar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscar.Text);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

                datalistado.Columns[1].Visible = false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar_usuario();
        }
        //Metodo para saber si escribes char o int
        public void validarNumeros(System.Windows.Forms.TextBox CajaTexto, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarNumeros(txtBuscar, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
    
}
