using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Ejercicio1_4.Models;
using System.Threading.Tasks;

namespace Ejercicio1_4.Controllers
{
    public class EmpleadosDB
    {
        readonly SQLiteAsyncConnection dbase;
        public EmpleadosDB(String dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

             dbase.CreateTableAsync<Empleados>(); 


        }

        #region OperacionesEmple
 
        public Task<int> EmpleSave(Empleados emple)
        {
            if (emple.codigo != 0)
            {
                return dbase.UpdateAsync(emple);  
            }
            else
            {
                return dbase.InsertAsync(emple); ; 
            }
        }

        
        public Task<List<Empleados>> obtenerListaEmple()
        {
            return dbase.Table<Empleados>().ToListAsync();
        }

         public Task<Empleados> obtenerEmple(int pid)
        {
            return dbase.Table<Empleados>()
                .Where(i => i.codigo == pid)
                .FirstOrDefaultAsync();
        }

         public Task<int> EmpleDelete(Empleados emple)
        {
            return dbase.DeleteAsync(emple);
        }

        #endregion OperacionesEmple
    }
}
