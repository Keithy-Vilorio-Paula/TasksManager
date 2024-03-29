﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TasksManager
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TaskManagerDBEntities : DbContext
    {
        public TaskManagerDBEntities()
            : base("name=TaskManagerDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Task> Tasks { get; set; }
    
        public virtual int CreateTask(string descripcion, string estado, Nullable<int> prioridad)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var prioridadParameter = prioridad.HasValue ?
                new ObjectParameter("Prioridad", prioridad) :
                new ObjectParameter("Prioridad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTask", descripcionParameter, estadoParameter, prioridadParameter);
        }
    
        public virtual int DeleteTask(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTask", iDParameter);
        }
    
        public virtual ObjectResult<GetTask_Result> GetTask()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTask_Result>("GetTask");
        }
    
        public virtual int UpdateTask(Nullable<int> iD, string descripcion, string estado, Nullable<int> prioridad)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var prioridadParameter = prioridad.HasValue ?
                new ObjectParameter("Prioridad", prioridad) :
                new ObjectParameter("Prioridad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTask", iDParameter, descripcionParameter, estadoParameter, prioridadParameter);
        }
    }
}
