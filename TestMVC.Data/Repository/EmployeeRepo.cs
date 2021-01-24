using TestMVC.Service.Entities;
using TestMVC.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestMVC.Data.Repository
{
    public class EmployeeRepo: IEmployeeRepo
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Ctro repo empleyee->
        /// </summary>
        /// <param name="httpClient"></param>
        public EmployeeRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Metodo para retornar los empleados de la api ->
        /// </summary>
        /// <returns></returns>
        async Task<List<Employee>> IEmployeeRepo.EmployeesGet()
        {
            try
            {
                var urlEmployees = $"Employees";
                var response = await _httpClient.GetAsync(urlEmployees);
                response.EnsureSuccessStatusCode();
                var responseTask = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Employee>>(responseTask);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~EmployeeRepo() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}