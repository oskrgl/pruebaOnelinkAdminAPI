using pruebaEmpleadoAPI.Domain.Dto;
using pruebaEmpleadoAPI.Domain.Entities;
using pruebaEmpleadoAPI.Domain.Helpers;
using pruebaEmpleadoAPI.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace pruebaEmpleadoAPI.DataAccess.Repositories
{
    public class SaveEmpleadoRepository : ISaveEmpleadoRepository
    {
        private readonly EmpleadoDbContext _context;
        private readonly AppSettingGlobal _settings;
        public SaveEmpleadoRepository(EmpleadoDbContext context,AppSettingGlobal settings)
        {
            this._context = context;
            this._settings = settings;
        }

        public async Task<Result<int>> SaveEmpleadoAsync(EmpleadosDto disposition)
        {
            Result<int> result = new Result<int>() { result = 0, message = "" };
            try
            {
                string sp = this._settings.GetValue("insertEmpleadoSP");
                using(var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sp;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@numIdentificacion", disposition.numIdentificacion));
                    command.Parameters.Add(new SqlParameter("@Nombres", disposition.Nombres));
                    command.Parameters.Add(new SqlParameter("@Apellidos", disposition.Apellidos));
                    command.Parameters.Add(new SqlParameter("@Username", disposition.Username));
                    command.Parameters.Add(new SqlParameter("@Password", disposition.Password));
                    command.Parameters.Add(new SqlParameter("@isActive", disposition.isActive));
                    command.Parameters.Add(new SqlParameter("@isAdmin", disposition.isAdmin));
                    command.Parameters.Add(new SqlParameter("@Tipo", disposition.Tipo));
                    command.Parameters.Add(new SqlParameter("@Estado", disposition.Estado));
                    command.Parameters.Add(new SqlParameter("@Cargo", disposition.Cargo));
                    _context.Database.OpenConnection();
                    var res =(Int32) command.ExecuteScalar();
                    result.result = res;
                    _context.Database.CloseConnection();
                    return result;
                }
            }
            catch(Exception ex)
            {
                result.result = 0;
                result.message = ex.Message;
                return result;
            }           
        }
        public async Task<Result<int>> UpdateEmpleadoAsync(EmpleadosUpdateDto disposition)
        {
            Result<int> result = new Result<int>() { result = 0, message = "" };
            try
            {
                string sp = this._settings.GetValue("UpdateEmpleadoSP");
                using(var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sp;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idEmpleado", disposition.idEmpleado));
                    command.Parameters.Add(new SqlParameter("@numIdentificacion", disposition.numIdentificacion));
                    command.Parameters.Add(new SqlParameter("@Nombres", disposition.Nombres));
                    command.Parameters.Add(new SqlParameter("@Apellidos", disposition.Apellidos));
                    command.Parameters.Add(new SqlParameter("@Username", disposition.Username));
                    command.Parameters.Add(new SqlParameter("@Password", disposition.Password));
                    command.Parameters.Add(new SqlParameter("@isActive", disposition.isActive));
                    command.Parameters.Add(new SqlParameter("@isAdmin", disposition.isAdmin));
                    command.Parameters.Add(new SqlParameter("@Tipo", disposition.Tipo));
                    command.Parameters.Add(new SqlParameter("@Estado", disposition.Estado));
                    command.Parameters.Add(new SqlParameter("@Cargo", disposition.Cargo));
                    _context.Database.OpenConnection();
                    var res =(int)((Int64) command.ExecuteScalar());
                    result.result = res;
                    _context.Database.CloseConnection();
                    return result;
                }
            }
            catch(Exception ex)
            {
                result.result = 0;
                result.message = ex.Message;
                return result;
            }           
        }

        public async Task<Result<List<Empleado>>> GetEmpleadoAsync()
        {
            Result<List<Empleado>> result = new Result<List<Empleado>>();
            result.result = new List<Empleado>();
            try
            {
                List<Empleado> questionList = new List<Empleado>();
                var data = _context.empleado.Where(q => q.id > 0).ToList();
                result.result = data;
                return result;
            }
            catch (Exception ex)
            {
                result.result = null;
                result.message = ex.Message;
                return result;
            }
        }

        public async Task<Result<List<Empleado>>> GetEmpleadosbyIdAsync(long idEmpleado)
        {
            Result<List<Empleado>> result = new Result<List<Empleado>>();
            result.result = new List<Empleado>();
            try
            {
                List<Empleado> questionList = new List<Empleado>();
                var data = _context.empleado.Where(q => q.id == idEmpleado).ToList();
                result.result = data;
                return result;
            }
            catch (Exception ex)
            {
                result.result = null;
                result.message = ex.Message;
                return result;
            }
        }

    }
}
