using System;
using System.IO;
using System.Threading.Tasks;

namespace web_api_cursos.Logger
{
    public class Log
    {
        private readonly string fullPath;
        public Log(string fullPath)
        {
            this.fullPath = fullPath;
        }

        public async Task WriteAsync(Exception ex)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("========================================\n");
            sb.Append("Categoria: Exception\n");
            sb.Append($"Data/Hora: {DateTime.Now: dd/MM/yyyy HH : mm : ss}\n");
            sb.Append($"Tipo da exceção: {ex.GetType().Name}\n");
            sb.Append($"Mensagem: {ex.Message}\n");
            sb.Append($"StackTrace: {ex.StackTrace}\n");
            sb.Append("========================================\n");

            await _WriteAsync(sb.ToString());
        }

        private async Task _WriteAsync(string message)
        {
            using (StreamWriter writer = new StreamWriter(fullPath, append: true))
            {
                await writer.WriteLineAsync(message);
            }
        }
    }
}