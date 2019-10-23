using AccesoADatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1.Vistas
{
    /// <summary>
    /// Lógica de interacción para ABMEmpleados.xaml
    /// </summary>
    public partial class ABMEmpleados : Window
    {
        Empleado empleadoX;
        public ABMEmpleados()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            empleadoX = new Empleado();
            empleadoX.Nombre = txbNombre.Text;
            empleadoX.Apellido = txbApellido.Text;
            empleadoX.Dni = txbDni.Text;
            empleadoX.Cargo = txbCargo.Text;
            empleadoX.FdeAlta = dtpFdeAlta.SelectedDate.Value;
            empleadoX.Fnacimiento = dtpFdeNac.SelectedDate.Value;
            empleadoX.Sueldo = Double.Parse(txbSueldo.Text);

            EmpleadoABM.insertEmpleado(empleadoX);
            this.Close();
        }

        public Empleado getEmpleado()
        {
            return empleadoX;
        }

    }
}
