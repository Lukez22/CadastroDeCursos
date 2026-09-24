using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace web_api_cursos.Repository
{
    public class CursoRepository : ICursoRepository<Model.Curso>
    {
        private readonly string connectionString;

        public CursoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<Model.Curso> CreateAsync(Model.Curso curso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into curso(nome, cargahoraria, valor, datainicio, [online], ativo) values (@nome, @cargahoraria, @valor, @datainicio, @online, @ativo); select convert(int, scope_identity());";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = curso.Nome;
                    command.Parameters.Add(new SqlParameter("@cargahoraria", System.Data.SqlDbType.Int)).Value = curso.CargaHoraria;
                    command.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = curso.Valor;

                    if (curso.DataInicio != null)
                     command.Parameters.Add(new SqlParameter("@datainicio", System.Data.SqlDbType.DateTime)).Value = curso.DataInicio?.ToString("yyyy-MM-dd");
                    else
                        command.Parameters.Add(new SqlParameter("@datainicio", System.Data.SqlDbType.DateTime)).Value = DBNull.Value;
                    command.Parameters.Add(new SqlParameter("@online", System.Data.SqlDbType.Bit)).Value = curso.Online;
                    command.Parameters.Add(new SqlParameter("@ativo", System.Data.SqlDbType.Bit)).Value = curso.Ativo;

                    curso.Id = Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }

            return curso;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int affectedRows = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from curso where id = @id and ativo = 0;";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
            return affectedRows == 1;
        }

        public async Task<List<Model.Curso>> ReadAsync()
        {
            List<Model.Curso> cursos = new List<Model.Curso>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id, nome, cargahoraria, valor, datainicio, [online], ativo from curso";

                    SqlDataReader dr = await command.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        Model.Curso curso = new Model.Curso();

                        curso.Id = Convert.ToInt32(dr["id"]);
                        curso.Nome = (string)dr["nome"];
                        curso.CargaHoraria = Convert.ToInt32(dr["cargahoraria"]);
                        curso.Valor = Convert.ToDecimal(dr["valor"]);

                        if (dr["datainicio"] != DBNull.Value)
                            curso.DataInicio = Convert.ToDateTime(dr["datainicio"]);

                        curso.Online = Convert.ToBoolean(dr["online"]);
                        curso.Ativo = Convert.ToBoolean(dr["ativo"]);

                        cursos.Add(curso);

                    }
                }
            }
            return cursos;
        }

        public async Task<Model.Curso> ReadAsync(int id)
        {
            Model.Curso curso = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id, nome, cargahoraria, valor, datainicio, [online], ativo from curso where id = @id";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = await command.ExecuteReaderAsync();

                    if (await dr.ReadAsync())
                    {
                        curso = new Model.Curso();

                        curso.Id = Convert.ToInt32(dr["id"]);
                        curso.Nome = (string)dr["nome"];
                        curso.CargaHoraria = Convert.ToInt32(dr["cargahoraria"]);
                        curso.Valor = Convert.ToDecimal(dr["valor"]);

                        if (dr["datainicio"] != DBNull.Value)
                            curso.DataInicio = Convert.ToDateTime(dr["datainicio"]);
 
                        curso.Online = Convert.ToBoolean(dr["online"]);
                        curso.Ativo = Convert.ToBoolean(dr["ativo"]);

                    }
                }
            }
            return curso;
        }

        public async Task<bool> UpdateAsync(Model.Curso curso)
        {
            int affectedRows = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update curso set nome = @nome, cargahoraria = @cargahoraria, valor = @valor, datainicio = @datainicio, [online] = @online, ativo = @ativo where id = @id;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = curso.Nome;
                    command.Parameters.Add(new SqlParameter("@cargahoraria", System.Data.SqlDbType.Int)).Value = curso.CargaHoraria;
                    command.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = curso.Valor;

                    if (curso.DataInicio != null)
                        command.Parameters.Add(new SqlParameter("@datainicio", System.Data.SqlDbType.DateTime)).Value = curso.DataInicio?.ToString("yyyy-MM-dd");
                    else
                        command.Parameters.Add(new SqlParameter("@datainicio", System.Data.SqlDbType.DateTime)).Value = DBNull.Value;

                    command.Parameters.Add(new SqlParameter("@online", System.Data.SqlDbType.Bit)).Value = curso.Online;
                    command.Parameters.Add(new SqlParameter("@ativo", System.Data.SqlDbType.Bit)).Value = curso.Ativo;

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = curso.Id;

                    affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
            return affectedRows == 1;
        }
    }
}