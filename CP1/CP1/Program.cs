namespace CP1
{
    enum Genero
    {
        Femenino,
        Masculino
    }
    enum Modalidad
    {
        Profesional,
        Planilla
    }
  internal class Program
  {
    public static void Main(string[] args)
    {


            var Empleado1 = new Empleado(
                Name: "Fernando",
                Salario: 1000,
                Modalidad: Modalidad.Planilla,
                ISSS: 0.03,
                AFP: 0.07,
                Renta: 0.10,
                Genero: Genero.Masculino,
                AnioNacimiento: 1989          
                );

            var Empleado2 = new Empleado(
                Name: "Erika",
                Salario: 2700,
                Modalidad: Modalidad.Profesional,
                ISSS: 0.03,
                AFP: 0.07,
                Renta: 0.10,
                Genero: Genero.Femenino,
                AnioNacimiento: 1963
                );


            

            Empleado1.showData();
            Empleado2.showData();
            System.Console.ReadLine();
    }
  }
    class Empleado
    {
        string Name { get; set; }
        double Salario { get; set; }
        Modalidad Modalidad { get; set; }
        double ISSS { get; set; }
        double AFP { get; set; }
        double Renta { get; set; }
        Genero Genero { get; set; }
        int AnioNacimiento { get; set; }


        public Empleado(string Name, double Salario, Modalidad Modalidad, double ISSS, double AFP, double Renta, Genero Genero, int AnioNacimiento)
        {
            this.Name = Name;
            this.Salario = Salario;
            this.Modalidad = Modalidad;
            this.ISSS = ISSS;
            this.AFP = AFP;
            this.Renta = Renta;
            this.Genero = Genero;
            this.AnioNacimiento = AnioNacimiento;
        }

        public double CalcularDeducciones()
        {   

            switch (Modalidad)
            {
                case Modalidad.Profesional: return Salario -= Salario * Renta;
                case Modalidad.Planilla: return Salario -= Salario * (Renta + ISSS + AFP);

                default: break;
            }
            return 0.0;
        }

        public bool CalcularRetiro()
        {
            //System.Console.WriteLine(System.DateTime.Now.Year - AnioNacimiento);
            if (this.Genero == Genero.Femenino && ((System.DateTime.Now.Year - AnioNacimiento) >= 55)) return true;
            if (this.Genero == Genero.Masculino && ((System.DateTime.Now.Year - AnioNacimiento) >= 60)) return true;
            return false;
        }

        public void showData()
        {
            System.Console.WriteLine(
                $"Nombre:{this.Name}\nSalario base:${this.Salario}\nModalidad:{this.Modalidad}\nISS:{this.ISSS}\nAFP:{this.AFP}\nRenta:{this.Renta}\nGenero:{this.Genero}\nEdad:{System.DateTime.Now.Year - AnioNacimiento}\nSalario final:${this.CalcularDeducciones()}"
                
                );
            System.Console.WriteLine(this.CalcularRetiro() ? "Si es apta para retiro" : "No es apto para retiro");
            System.Console.WriteLine("=================");
        }
    }
}