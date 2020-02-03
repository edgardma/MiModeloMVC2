using System;
using System.Collections.Generic;

using openalprnet;

namespace ConsoleAppOpenAlprExample
{
    class Program
    {
        private const string RUTA_CONF = "D:\\Lib\\openalpr-2.1.0-win-64bit\\openalpr.conf";
        private const string RUTA_RUNTIME_DATA = "D:\\Lib\\openalpr-2.1.0-win-64bit\\runtime_data";
        private const string DEFAULT_PAIS = "us";
        private const string DEFAULT_REGION = "md";

        private const string IMAGEN_PLACA_EJEMPLO = "D:\\placa.jpg";

        private const string MENSAJE_ERROR_CARGA = "¡Falla al cargar 'OpenAlpr'!";
        private const string MENSAJE_INICIO_RESULTADO = "Placa {0}: {1} resultado(s)";
        private const string MENSAJE_TIEMPO_PROCESAMIENTO = "  Tiempo de procesamiento: {0} msec(s)";
        private const string MENSAJE_RESULTADO_FINAL = "  - {0}\t Confianza: {1}\tCoincidencia: {2}";

        static void Main(string[] args)
        {
            var alpr = new AlprNet(DEFAULT_PAIS, RUTA_CONF, RUTA_RUNTIME_DATA);
            
            if (!alpr.isLoaded())
            {
                Console.WriteLine(MENSAJE_ERROR_CARGA);
                return;
            }

            // Opcional, configurar el patron para una region en particular
            alpr.DefaultRegion = DEFAULT_REGION;

            var resultados = alpr.recognize(IMAGEN_PLACA_EJEMPLO);
            int i = 0;

            foreach (var resultado in resultados.plates)
            {
                Console.WriteLine(MENSAJE_INICIO_RESULTADO, i++, resultado.topNPlates.Count);
                Console.WriteLine(MENSAJE_TIEMPO_PROCESAMIENTO, resultado.processing_time_ms);

                foreach (var placa in resultado.topNPlates)
                {
                    Console.WriteLine(MENSAJE_RESULTADO_FINAL, placa.characters,
                                      placa.overall_confidence, placa.matches_template);
                }
            }

            Console.ReadKey();
        }
    }
}
