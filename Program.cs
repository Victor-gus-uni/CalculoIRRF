using System;

namespace CalculoIRRF
{
    public class CalculoSalario
    {
        public decimal SalarioBruto { get; set; }
        public decimal INSS { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal SalarioDep { get; set; }
        public decimal IRRF { get; set; }
        public decimal SalarioLiquido { get; set; }
        public int Dependentes { get; set; }


        public void CalcularINSS()
        {
            if (SalarioBruto <= 1518)
            {
                INSS = (SalarioBruto * 0.075m);
            }
            else if (SalarioBruto <= 2793.88m)
            {
                INSS = (SalarioBruto * 0.09m) - 22.77m;
            }
            else if (SalarioBruto <= 4190.84m)
            {
                INSS = (SalarioBruto * 0.12m) - 106.59m;
            }
            else if (SalarioBruto <= 8157.41m)
            {
                INSS = (SalarioBruto * 0.14m) - 190.40m;
            }
            else
            {
                INSS = 951.62m;
            }
            SalarioBase = SalarioBruto - INSS;
        }

        public void CalcularIRRF()
        {
            SalarioDep = SalarioBase - (189.59m * Dependentes);
            if (SalarioDep <= 2428.80m)
            {
                IRRF = 0;
            }
            else if (SalarioDep <= 2826.65m)
            {
                IRRF = (SalarioDep * 0.075m) - 182.16m;
            }
            else if (SalarioDep <= 3751.05m)
            {
                IRRF = (SalarioDep * 0.15m) - 394.16m;
            }
            else if (SalarioDep <= 4664.68m)
            {
                IRRF = (SalarioDep * 0.225m) - 675.49m;
            }
            else
            {
                IRRF = (SalarioDep * 0.275m) - 908.73m;
            }

            SalarioLiquido = SalarioDep - IRRF;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var profissional = new CalculoSalario();
            profissional.SalarioBruto = 3000;
            profissional.Dependentes = 0;

            Console.WriteLine($"Salario bruto: R$ {profissional.SalarioBruto:F2}");
            Console.WriteLine($"Número dependentes: R$ {profissional.Dependentes}");

            profissional.CalcularINSS();
            Console.WriteLine($"Desconto INSS: R$ {profissional.INSS:F2}");
            Console.WriteLine($"Salario base: R$ {profissional.SalarioBase:F2}");

            profissional.CalcularIRRF();
            Console.WriteLine($"Salario descontando dependentes: R$ {profissional.SalarioDep:F2}");
            Console.WriteLine($"Desconto IRRF: R$ {profissional.IRRF:F2}");
            Console.WriteLine($"Salario liquido: R$ {profissional.SalarioLiquido:F2}");


        }
    }
}
