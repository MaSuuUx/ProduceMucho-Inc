/*
 GUIA: #10
EJERCICIO: #9
NOMBRES: HECTOR MARCELO MONGE CABALLERO Y GRABRIEL ALEJANDRO BLANCO PALACIOS 
CARNETS: MC23084 Y BP23007
GL: #12
INTRUCTORA: LIZETH CARMELINE GOCHEZ DE PENATE

-----------------------------------------------------------------------------------------------------------------------------------------

    9. La empresa “ProduceMucho” registra el consumo energético en que generan sus
       3 plantas de producción en en los primeros seis meses del año:

                | ENERO | FEBRERO | MARZO | ABRIL | MAYO | JUNIO |
        PLANTA 1| 150   | 220     | 140   | 300   | 521  | 120   |
        PLANTA 2| 125   | 140     | 110   | 175   | 560  | 320   |
        PLANTA 3| 250   | 220     | 260   | 236   | 680  | 400   |

        Según los datos dados se requiere saber:
            a) Total de energía gastado por cada mes
            b) Mes en el que se gastó más energía
            c) Total de energía por cada planta de producción
            d) Planta que consume menos energía
            e) Promedio de consumo energético por planta
            f) Promedio de consume energético por mes
            g) Sabiendo que 1 MW hora cuesta $129.7 cuanto tiene que pagar la empresa en
                cada mes en concepto de pago de energía eléctrica
            h) Sabiendo que el costo de energía eléctrica disminuirá en un 4%, y considerando
                que las tendencias de consumo permanecen exactamente iguales para el próximo
                semestre cual será el ahorro mensual que tendrá la empresa.

    NOTA IMPORTANTISIMA==> HAY UNOS MODULOS QUE SE ENCUENTRAN COMENTADOS PARA QUE LOS DESCOMENTEN YA QUE EN LA CREACION DEL PROYECTO
                              HUBIERON UNOS PROBLEMAS YA QUE LA CONSOLA NO LOGRABA IMPRIMIR MÁS ALLA DEL MODULO "TotalEnergia", 
                              PARA IMPRIMIR LOS DEMAS MODULOS IR COMENTANDO OTROS MODULOS.

-----------------------------------------------------------------------------------------------------------------------------------------
 */

using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Timers;

class Program
{
    //PRECIO DEL 1 MW/h
    const double precio = 129.7;
    static void Main(string[] args)
    {
        Console.WriteLine("------------------ ProduceMucho Inc. ------------------");

        //VECTOR DE LOS MESES
        string[] meses = { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO"};
        //MATRICES DE EL NUMERO DE PLANTAS Y SUS CONSUMOS
        string[,] plantas = new string[1, 3];
        plantas[0, 0] = "Planta1";
        plantas[0, 1] = "Planta2";
        plantas[0, 2] = "Planta3";

        int[,] tabla = new int[3, 6]{
            { 150, 220,140,300,521,120 },
            { 125,140,110,175,560,320 },
            { 250,220,260,236,680,400 }
        };

        //LLAMDO A LOS METODOS
         ImprimirMes(tabla, meses);
         MasEnergia(tabla, meses, plantas);
         TotalEnergia(tabla, plantas);
         MenosEnergia(tabla, plantas, meses);
         Promedio(tabla);
         PromedioMes(tabla);
         CostoEnergia(plantas, tabla, meses, precio);
         AhorroMensual(tabla, meses, plantas, precio);


    }
     static void ImprimirMes(int[,] tabla, string[] meses)
     {
         Console.WriteLine("------------------------------------------------------------------------------------");
         Console.WriteLine("NOTA: *Las filas despues de la fila de los peses corresponde a una planta de las 3 *");
         Console.WriteLine("------------------------------------------------------------------------------------");

         //BUCLE PARA IMPRIMIR LOS 6 MESES
         for (int a = 0; a < meses.GetLength(0); a++)
         {
             Console.Write("| "+ meses[a] + " |");
         }
         Console.WriteLine();

         //BUCLE PARA IMPRIMIR LOS DATOS DE LA MATRIZ TABLA
         for (int x = 0; x < tabla.GetLength(0); x++)
         {
             for (int y = 0; y < tabla.GetLength(1); y++)
             {
                 Console.Write("|   " + tabla[x, y] + "  |");
             }
             Console.WriteLine();
         }
         Console.WriteLine();
     }
      static void MasEnergia(int[,] tabla, string[] meses, string[,] plantas)
      {
          //VARIABLES PARA ALMACENAR CUAL FUE 
          //EL MES DE MAYOR CONSUMO DE CADA PLANTA
          int max1 = 0, max2 = 0, max3 = 0;
          int mes1 = 0, mes2 = 0, mes3 = 0;

          //BUCLE PARA OPERACIONES 
          for (int y = 0; y < tabla.GetLength(1); y++)
          {
              //ALMACENAR EL MES CON MAYOR
              //CONSUMO DE LA PLANTA 1
              if (tabla[0, y] > max1)
              {
                  max1 = tabla[0, y];
                  mes1 = y;
              }

              //ALMACENAR EL MES CON MAYOR
              //CONSUMO DE LA PLANTA 2
              if (tabla[1, y] > max2)
              {
                  max2 = tabla[1, y];
                  mes2 = y;
              }

              //ALMACENAR EL MES CON MAYOR
              //CONSUMO DE LA PLANTA 3
              if (tabla[2, y] > max3)
              {
                  max3 = tabla[2, y];
                  mes3 = y;
              }
          }
          //IMPRESION DE LOS DATOS 
          Console.WriteLine("------------------------------------------------------------------------------------");
          Console.WriteLine("El mes que más energia se gasto en la Planta  fue " + meses[mes1] + " con un total de  " + max1);
          Console.WriteLine("El mes que más energia se gasto en la Planta  fue " + meses[mes2] + " con un total de  " + max2);
          Console.WriteLine("El mes que más energia se gasto en la Planta  fue " + meses[mes3] + " con un total de  " + max3);
      }
      static void TotalEnergia(int[,] tabla, string[,] plantas)
      {
          Console.WriteLine("------------------------------------------------------------------------------------");
          Console.WriteLine("El total de energia de cada planta de produccion:");

          //BUCLE PARA ALMACENAR EL TOTAL DE CADA PLANTA
          for (int x=0; x<tabla.GetLength(1); x++)
          {
              int total = 0;

              //En este bucle nos movemos por (x,y) y se van almacenando
              //el total para cada planta
              for (int y = 0; y < tabla.GetLength(1); y++)
              {
                  total += tabla[x, y];
              }
              //IMPRESION DE LOS DATOS
              Console.WriteLine($"El total de energia usada en la {plantas[0, x]} en los primeros 6 meses es de {total}");
          }
          Console.WriteLine();
      }
      static void MenosEnergia(int[,] tabla, string[,] plantas, string[] meses)
      {
          Console.WriteLine("------------------------------------------------------------------------------------");

        //BUCLE PARA RECORRER LAS FILAS DE LA MATRIZ TABLAS
        for (int x = 0; x < tabla.GetLength(0); x++)
          {
              int total = 0;
              int menorValor = 10000;

              //BUCLE PARA RECORRER LAS COLUMNAS DE LA MATRIZ TABLAS
              for (int y = 0; y < tabla.GetLength(1); y++)
              {
                  total += tabla[x, y];
                  if (tabla[x, y] < menorValor)  menorValor = tabla[x, y];
              }

              Console.WriteLine($"La planta que menos energía ha consumido es la {plantas[x, 0]} con un total de {total}");
          }
      }
    static void Promedio(int[,] tabla)
    {
        Console.WriteLine("------------------------------------------------------------------------------------");

        //BUCLE PARA RECORRER LAS FILAS DE LA MATRIZ
        for (int x = 0; x < tabla.GetLength(0); x++)
        {
            //VARIABLE PARA IR SUMANDO LOS CONSUMOS
            //DEL SEMETRE DE CADA PLANTA
            int suma = 0;

            //BUCLE PARA RECORRER LAS COLUMNAS DE LA MATRIZ TABLAS 
            //Y QUE SUME LOS DATOS DE LA FILA Y COLUMNA
            for (int y = 0; y < tabla.GetLength(1); y++)
            {
                suma += tabla[x, y];
            }

            //CALCULA EL PROMEDIO DEL SEMESTRE
            double promedio = (double)suma / tabla.GetLength(1);
            Console.WriteLine($"El promedio de consumo de energía de la Planta {x + 1} es de: {promedio}");
        }
    }
    static void PromedioMes(int[,] tabla)
    {
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("Promedio de consumo energético por mes:");

        //BUCLE PARA RECORRER LAS COLUMNAS DE LA MATRIZ TABLAS
        for (int x = 0; x < tabla.GetLength(1); x++)
        {

            //VARIABLE PARA IR SUMANDO LOS CONSUMOS
            //DEL MES DE LAS 3 PLANTAS
            int suma = 0;

            //BUCLE PARA RECORRER LAS FILAS DE LA MATRIZ TABLAS 
            //Y QUE SUME LOS DATOS DE LA COLUMNA Y FILA
            for (int y = 0; y < tabla.GetLength(0); y++)
            {
                suma += tabla[y, x];
            }

            //CALCULA EL PROMEDIO DEL MES PARA LAS TRES PLANTAS
            double promedio = (double)suma / 3;

            Console.WriteLine($"El consumo energético mensual de las tres plantas en el {x+1}° mes es de: {promedio}");
        }
    }
    static void CostoEnergia(string[,] plantas, int[,] tabla, string[] meses, double precio)
    {
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("NOTA: EL EL PUNTO ES IGUAL A UNA COMA POR ENDE LOS RESULTADOS ESTAN EN MILES 00.000 = 00,000\n");


        // BLUCLE PARA RECCORER LAS PLANTAS
        for (int i = 0; i < plantas.GetLength(1); i++)
        {
            Console.WriteLine("Costo mensual de energía eléctrica para la planta " + plantas[0, i]);

            // BUCLE PARA RECCORER LOS MESES
            for (int j = 0; j < meses.Length; j++)
            {
                //CALCULAR EL CONSUMO MENSUAL
                double consumoMensual = tabla[i, j] / 1000.0;

                // CALCULAR EL COSTO MENSUAL DE ENRGIA ELECTRICA
                double costoMensual = consumoMensual * precio;

                Console.WriteLine(meses[j] + ": $" + costoMensual.ToString(".000 USD"));
            }
            Console.WriteLine();
        }
    }
    static void AhorroMensual(int[,] tabla, string[] meses, string[,] plantas, double precio)
    {
        
        double descuentoPorcentaje = 4.0 / 100.0;
        double nuevoCostoPorMW = precio * (1.0 - descuentoPorcentaje);

        double ahorroMensual = 0.0;

        //BUCLE PARA RECORRER LAS PLANTAS
        for (int i = 0; i < plantas.GetLength(1); i++)
        {
            //BUCLE PARA RECORRER LOS MESES
            for (int j = 0; j < meses.Length; j++)
            {
                // CALCULAR EL CONSUMO MENSUAL EN MW HORA
                double consumoMensual = tabla[i, j] / 1000.0;

               
                // CALCULAR EL COSTO MENSUAL DE ENERGÍA ELÉCTRICA ANTES DEL DESCUENTO
                double costoMensualAntesDescuento = consumoMensual * precio;

                // CALCULAR EL COSTO MENSUAL DE ENERGÍA ELÉCTRICA DESPUÉS DEL DESCUENTO
                double costoMensualDespuesDescuento = consumoMensual * nuevoCostoPorMW;

                // CALCULAR EL AHORRO MENSUAL
                double ahorroMensualPlanta = costoMensualAntesDescuento - costoMensualDespuesDescuento;

                ahorroMensual += ahorroMensualPlanta;
            }
        }

        Console.WriteLine("El ahorro mensual por el descuento del 4% es de: $" + ahorroMensual.ToString(",0.00"));
    }
}
