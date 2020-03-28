using System;
using System.Threading.Tasks;

namespace procesamiento_asincrono_VillanoR2 {
    class Example {
        static void Main (string[] args) {
            Console.WriteLine (
                PercentageChangeAsync (100, 50).Result
            );

            Console.Read ();
        }

        /// <summary>
        /// Este metodo nos permite calcular la variación porcentual de 2 montos. La clase Task cambia la lógica del código para que vuelva asíncrona.
        /// Nuestro método retorna una tarea del tipo entero y le especificamos que es un asíncrona mediante el uso de async.
        /// Para convertir nuestra lógica a asíncrona hacemos uso de la clase Task.Run, lo que va dentro será una tarea asíncrona y mediante el await le decimos que queremos esperar a que la tarea finalice.
        /// Para hacer uso del await nuestro método donde se esta ejecutando deberá ser async. 
        /// </summary>
        /// <param name="mount1"></param>
        /// <param name="mount2"></param>
        /// <returns></returns>
        static async Task<decimal> PercentageChangeAsync (decimal mount1, decimal mount2) {
            var result = await Task.Run (() => {
                return (mount2 - mount1) / mount1;
            });

            return result * 100;
        }
    }
}