using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class persona
    {
        protected string Nombre;
        protected DateTime? FechaDenacimiento;


        public string Nombre_
        {
            get
            {
                return Nombre;
            }
            set
            {
                Nombre = value;
            }
        }
        public DateTime? FechaDenacimiento_
        {
            get
            {
                return FechaDenacimiento;
            }
            set
            {
                FechaDenacimiento = value;
            }
        }
        public int Edad
        {
            get
            {
                int Edad_;
                Edad_ = (DateTime.Now.Year - FechaDenacimiento.Value.Year);
                return Edad_;
            }
        }
        public persona()
        {
            Nombre = "";
            FechaDenacimiento = null;
        }
        public persona(string nombre_, DateTime? fechaDenacimento_)
        {
            this.Nombre = nombre_;
            this.FechaDenacimiento = fechaDenacimento_;

        }

        public override string ToString()
        {
            return Nombre.ToUpper() + " " + Edad;
        }
    }
}
